using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Customers
    /// </summary>
    public class CustomerDAO
    {
        #region Singleton
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerDAO();
                return instance;
            }
        }

        private CustomerDAO() { }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Lấy tất cả khách hàng
        /// </summary>
        public List<Customers> GetAllCustomers()
        {
            try
            {
                string procName = "sp_GetAllCustomers";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                List<Customers> customers = new List<Customers>();
                foreach (DataRow row in data.Rows)
                {
                    customers.Add(new Customers(row));
                }

                return customers;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllCustomers error: {ex.Message}");
                return new List<Customers>();
            }
        }

        /// <summary>
        /// Lấy thông tin 1 khách hàng
        /// </summary>
        public Customers GetCustomerByID(int customerID)
        {
            try
            {
                string procName = "sp_GetCustomerByID";
                object[] parameters = { customerID };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                if (data.Rows.Count > 0)
                {
                    return new Customers(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetCustomerByID error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        public (int result, int newCustomerID) InsertCustomer(
            string tenKhachHang,
            string soDienThoai,
            string diaChi)
        {
            try
            {
                string procName = "sp_InsertCustomer";

                var inputParams = new Dictionary<string, object>
                {
                    { "@TenKhachHang", tenKhachHang },
                    { "@SoDienThoai", soDienThoai ?? (object)DBNull.Value },
                    { "@DiaChi", diaChi ?? (object)DBNull.Value }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int },
                    { "@NewCustomerID", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                int resultCode = result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
                int newCustomerID = result["@NewCustomerID"] != null ? Convert.ToInt32(result["@NewCustomerID"]) : 0;

                return (resultCode, newCustomerID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertCustomer error: {ex.Message}");
                return (-99, 0);
            }
        }

        /// <summary>
        /// Cập nhật khách hàng
        /// </summary>
        public int UpdateCustomer(
            int customerID,
            string tenKhachHang,
            string soDienThoai,
            string diaChi)
        {
            try
            {
                string procName = "sp_UpdateCustomer";

                var inputParams = new Dictionary<string, object>
                {
                    { "@CustomerID", customerID },
                    { "@TenKhachHang", tenKhachHang },
                    { "@SoDienThoai", soDienThoai ?? (object)DBNull.Value },
                    { "@DiaChi", diaChi ?? (object)DBNull.Value }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateCustomer error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        public int DeleteCustomer(int customerID)
        {
            try
            {
                string procName = "sp_DeleteCustomer";

                var inputParams = new Dictionary<string, object>
                {
                    { "@CustomerID", customerID }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                return result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteCustomer error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng
        /// </summary>
        public List<Customers> SearchCustomers(string keyword)
        {
            try
            {
                string procName = "sp_SearchCustomers";
                object[] parameters = { keyword };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                List<Customers> customers = new List<Customers>();
                foreach (DataRow row in data.Rows)
                {
                    customers.Add(new Customers(row));
                }

                return customers;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchCustomers error: {ex.Message}");
                return new List<Customers>();
            }
        }

        #endregion
    }
}