using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Suppliers
    /// </summary>
    public class SupplierDAO
    {
        #region Singleton
        private static SupplierDAO instance;
        public static SupplierDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SupplierDAO();
                return instance;
            }
        }

        private SupplierDAO() { }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Lấy tất cả nhà cung cấp
        /// </summary>
        public List<Suppliers> GetAllSuppliers()
        {
            try
            {
                string procName = "sp_GetAllSuppliers";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                List<Suppliers> suppliers = new List<Suppliers>();
                foreach (DataRow row in data.Rows)
                {
                    suppliers.Add(new Suppliers(row));
                }

                return suppliers;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllSuppliers error: {ex.Message}");
                return new List<Suppliers>();
            }
        }

        /// <summary>
        /// Lấy thông tin 1 nhà cung cấp
        /// </summary>
        public Suppliers GetSupplierByID(int supplierID)
        {
            try
            {
                string procName = "sp_GetSupplierByID";
                object[] parameters = { supplierID };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                if (data.Rows.Count > 0)
                {
                    return new Suppliers(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetSupplierByID error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm nhà cung cấp mới
        /// </summary>
        public (int result, int newSupplierID) InsertSupplier(
            string tenNhaCungCap,
            string soDienThoai,
            string diaChi)
        {
            try
            {
                string procName = "sp_InsertSupplier";

                var inputParams = new Dictionary<string, object>
                {
                    { "@TenNhaCungCap", tenNhaCungCap },
                    { "@SoDienThoai", soDienThoai ?? (object)DBNull.Value },
                    { "@DiaChi", diaChi ?? (object)DBNull.Value }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int },
                    { "@NewSupplierID", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                int resultCode = result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
                int newSupplierID = result["@NewSupplierID"] != null ? Convert.ToInt32(result["@NewSupplierID"]) : 0;

                return (resultCode, newSupplierID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertSupplier error: {ex.Message}");
                return (-99, 0);
            }
        }

        /// <summary>
        /// Cập nhật nhà cung cấp
        /// </summary>
        public int UpdateSupplier(
            int supplierID,
            string tenNhaCungCap,
            string soDienThoai,
            string diaChi)
        {
            try
            {
                string procName = "sp_UpdateSupplier";

                var inputParams = new Dictionary<string, object>
                {
                    { "@SupplierID", supplierID },
                    { "@TenNhaCungCap", tenNhaCungCap },
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
                System.Diagnostics.Debug.WriteLine($"UpdateSupplier error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Xóa nhà cung cấp
        /// </summary>
        public int DeleteSupplier(int supplierID)
        {
            try
            {
                string procName = "sp_DeleteSupplier";

                var inputParams = new Dictionary<string, object>
                {
                    { "@SupplierID", supplierID }
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
                System.Diagnostics.Debug.WriteLine($"DeleteSupplier error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Tìm kiếm nhà cung cấp
        /// </summary>
        public List<Suppliers> SearchSuppliers(string keyword)
        {
            try
            {
                string procName = "sp_SearchSuppliers";
                object[] parameters = { keyword };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                List<Suppliers> suppliers = new List<Suppliers>();
                foreach (DataRow row in data.Rows)
                {
                    suppliers.Add(new Suppliers(row));
                }

                return suppliers;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchSuppliers error: {ex.Message}");
                return new List<Suppliers>();
            }
        }

        #endregion
    }
}