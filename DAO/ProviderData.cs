using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoubleTRice.DAO
{
    internal class DataProvider
    {
        private static DataProvider instance;

        //instance dùng chung
        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return DataProvider.instance;
            }
            private set
            {
                DataProvider.instance = value;
            }
        }
        private string connStr = "Data Source=E14G3;Initial Catalog=QuanLyBanGao;Integrated Security=True; TrustServerCertificate=True;";
       // private string masterConnStr = "Data Source=E14G3;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";
        private DataProvider() { }

        // ham dung cho select
        public DataTable ExecuteQuery(string query, object[] parameters = null, bool isStoredProc = false)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (isStoredProc)
                        {
                            command.CommandType = CommandType.StoredProcedure;
                        }
                        if (parameters != null)
                        {
                            SqlCommandBuilder.DeriveParameters(command);
                            int paramIndex = 0;

                            foreach (SqlParameter param in command.Parameters)
                            {
                                if (param.ParameterName != "@RETURN_VALUE")
                                {
                                    param.Value = parameters[paramIndex] ?? DBNull.Value;
                                    paramIndex++;
                                }
                            }
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(data);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi SQL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            }
            return data;
        }

        //dùng cho INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query, object[] parameters)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        MatchCollection matches = Regex.Matches(query, @"@\w+");
                        if (matches.Count != parameters.Length)
                        {
                            throw new ArgumentException("Số lượng tham số không khớp với câu lệnh SQL.");
                        }

                        for (int i = 0; i < matches.Count; i++)
                        {
                            string paramName = matches[i].Value;
                            command.Parameters.AddWithValue(paramName, parameters[i] ?? DBNull.Value);
                        }
                    }
                    data = command.ExecuteNonQuery();
                }
            }
            return data;
        }
        //dùng khi chỉ cần 1 giá trị (ô duy nhất)
        public object ExecuteScalar(string query, Dictionary<string, object> parameters = null, bool isStoredProcedure = false)
        {
            object data = null;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = isStoredProcedure ? CommandType.StoredProcedure : CommandType.Text;
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    data = command.ExecuteScalar();
                }
            }
            return data;
        }

        //dùng cho Stored Procedure có tham số OUTPUT
        public object ExecuteProcedureWithOutput(string procName, Dictionary<string, object> inputParams, string outputParamName)
        {
            object outputValue = null;
            using (SqlConnection connection = new SqlConnection(connStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(procName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (inputParams != null)
                    {
                        foreach (var param in inputParams)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }
                    SqlParameter outputParam = new SqlParameter(outputParamName, SqlDbType.VarChar, 10);
                    outputParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputParam);
                    command.ExecuteNonQuery();
                    outputValue = outputParam.Value;
                }
            }
            return outputValue;
        }
        //public void BackupDatabase(string backupFilePath)
        //{
        //    using (SqlConnection connection = new SqlConnection(connStr))
        //    {
        //        connection.Open();
        //        string backupQuery = $"BACKUP DATABASE [{connection.Database}] TO DISK = '{backupFilePath}' WITH INIT";
        //        using (SqlCommand command = new SqlCommand(backupQuery, connection))
        //        {
        //            command.CommandTimeout = 300;
        //            command.ExecuteNonQuery();
        //        }
        //    }
        //}
        //public void RestoreDatabase(string backupFilePath)
        //{
        //    using (SqlConnection connection = new SqlConnection(masterConnStr))
        //    {
        //        connection.Open();

        //        string killConnections = @"
        //            DECLARE @kill varchar(8000) = '';
        //            SELECT @kill = @kill + 'KILL ' + CAST(spid AS varchar(10)) + ';'
        //            FROM sys.sysprocesses
        //            WHERE DB_NAME(dbid) = 'QUAN_LY_DON_HANG_MOI_TRUONG' AND spid > 50;
        //            EXEC(@kill);";
        //        using (SqlCommand cmd = new SqlCommand(killConnections, connection))
        //        {
        //            cmd.CommandTimeout = 300;
        //            cmd.ExecuteNonQuery();
        //        }

        //        string setSingleUser = $"ALTER DATABASE [QUAN_LY_DON_HANG_MOI_TRUONG] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
        //        using (SqlCommand cmd = new SqlCommand(setSingleUser, connection))
        //        {
        //            cmd.CommandTimeout = 300;
        //            cmd.ExecuteNonQuery();
        //        }

        //        string restoreQuery = $"RESTORE DATABASE [QUAN_LY_DON_HANG_MOI_TRUONG] FROM DISK = '{backupFilePath}' WITH REPLACE";
        //        using (SqlCommand cmd = new SqlCommand(restoreQuery, connection))
        //        {
        //            cmd.CommandTimeout = 300;
        //            cmd.ExecuteNonQuery();
        //        }

        //        string setMultiUser = $"ALTER DATABASE [QUAN_LY_DON_HANG_MOI_TRUONG] SET MULTI_USER";
        //        using (SqlCommand cmd = new SqlCommand(setMultiUser, connection))
        //        {
        //            cmd.CommandTimeout = 300;
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //}
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //public bool CheckDatabaseConnections()
        //{
        //    using (SqlConnection connection = new SqlConnection(masterConnStr))
        //    {
        //        connection.Open();
        //        string query = @"
        //    SELECT COUNT(*) 
        //    FROM sys.sysprocesses 
        //    WHERE DB_NAME(dbid) = 'QUAN_LY_DON_HANG_MOI_TRUONG' AND spid > 50;";
        //        using (SqlCommand cmd = new SqlCommand(query, connection))
        //        {
        //            int connectionCount = (int)cmd.ExecuteScalar();
        //            return connectionCount == 0;
        //        }
        //    }
        //}
    }
}

