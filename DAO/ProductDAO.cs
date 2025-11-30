using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DoubleTRice.DAO
{
    public class ProductDAO
    {
        #region Singleton
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return instance;
            }
        }

        private ProductDAO() { }
        #endregion

        #region Product CRUD Methods

        /// <summary>
        /// Lấy tất cả sản phẩm với thông tin chi tiết
        /// </summary>
        public List<Products> GetAllProductsDetail()
        {
            try
            {
                string procName = "sp_GetAllProductsDetail";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                List<Products> products = new List<Products>();
                foreach (DataRow row in data.Rows)
                {
                    products.Add(new Products(row));
                }

                return products;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllProductsDetail error: {ex.Message}");
                return new List<Products>();
            }
        }

        /// <summary>
        /// Lấy thông tin 1 sản phẩm
        /// </summary>
        public Products GetProductByID(int productID)
        {
            try
            {
                string procName = "sp_GetProductByID";
                object[] parameters = { productID };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                if (data.Rows.Count > 0)
                {
                    return new Products(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetProductByID error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        public (int result, int newProductID) InsertProduct(string tenSanPham, int baseUnitID, double tonKhoToiThieu)
        {
            try
            {
                string procName = "sp_InsertProductEnhanced";

                var inputParams = new Dictionary<string, object>
                {
                    { "@TenSanPham", tenSanPham },
                    { "@BaseUnitID", baseUnitID },
                    { "@TonKhoToiThieu", tonKhoToiThieu }
                };

                var outputParams = new Dictionary<string, SqlDbType>
                {
                    { "@Result", SqlDbType.Int },
                    { "@NewProductID", SqlDbType.Int }
                };

                var result = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    procName, inputParams, outputParams);

                int resultCode = result["@Result"] != null ? Convert.ToInt32(result["@Result"]) : -99;
                int newProductID = result["@NewProductID"] != null ? Convert.ToInt32(result["@NewProductID"]) : 0;

                return (resultCode, newProductID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertProduct error: {ex.Message}");
                return (-99, 0);
            }
        }

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        public int UpdateProduct(int productID, string tenSanPham, int baseUnitID, double tonKhoToiThieu)
        {
            try
            {
                string procName = "sp_UpdateProductEnhanced";

                var inputParams = new Dictionary<string, object>
                {
                    { "@ProductID", productID },
                    { "@TenSanPham", tenSanPham },
                    { "@BaseUnitID", baseUnitID },
                    { "@TonKhoToiThieu", tonKhoToiThieu }
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
                System.Diagnostics.Debug.WriteLine($"UpdateProduct error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        public int DeleteProduct(int productID)
        {
            try
            {
                string procName = "sp_DeleteProductEnhanced";

                var inputParams = new Dictionary<string, object>
                {
                    { "@ProductID", productID }
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
                System.Diagnostics.Debug.WriteLine($"DeleteProduct error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        public List<Products> SearchProducts(string keyword)
        {
            try
            {
                string procName = "sp_SearchProductsDetail";
                object[] parameters = { keyword };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                List<Products> products = new List<Products>();
                foreach (DataRow row in data.Rows)
                {
                    products.Add(new Products(row));
                }

                return products;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"SearchProducts error: {ex.Message}");
                return new List<Products>();
            }
        }

        #endregion

        #region Unit Methods

        /// <summary>
        /// Lấy tất cả đơn vị tính
        /// </summary>
        public List<Units> GetAllUnits()
        {
            try
            {
                string procName = "sp_GetAllUnits";
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, null, true);

                List<Units> units = new List<Units>();
                foreach (DataRow row in data.Rows)
                {
                    units.Add(new Units(row));
                }

                return units;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAllUnits error: {ex.Message}");
                return new List<Units>();
            }
        }

        #endregion

        #region Unit Conversion Methods

        /// <summary>
        /// Lấy quy đổi đơn vị của sản phẩm
        /// </summary>
        public List<ProductUnitConversions> GetProductUnitConversions(int productID)
        {
            try
            {
                string procName = "sp_GetProductUnitConversions";
                object[] parameters = { productID };
                DataTable data = DataProvider.Instance.ExecuteQuery(procName, parameters, true);

                List<ProductUnitConversions> conversions = new List<ProductUnitConversions>();
                foreach (DataRow row in data.Rows)
                {
                    conversions.Add(new ProductUnitConversions(row));
                }

                return conversions;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetProductUnitConversions error: {ex.Message}");
                return new List<ProductUnitConversions>();
            }
        }

        /// <summary>
        /// Thêm quy đổi đơn vị
        /// </summary>
        public int InsertUnitConversion(int productID, int unitID, double giaTriQuyDoi)
        {
            try
            {
                string procName = "sp_InsertUnitConversion";

                var inputParams = new Dictionary<string, object>
                {
                    { "@ProductID", productID },
                    { "@UnitID", unitID },
                    { "@GiaTriQuyDoi", giaTriQuyDoi }
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
                System.Diagnostics.Debug.WriteLine($"InsertUnitConversion error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Cập nhật quy đổi
        /// </summary>
        public int UpdateUnitConversion(int conversionID, double giaTriQuyDoi)
        {
            try
            {
                string procName = "sp_UpdateUnitConversion";

                var inputParams = new Dictionary<string, object>
                {
                    { "@ConversionID", conversionID },
                    { "@GiaTriQuyDoi", giaTriQuyDoi }
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
                System.Diagnostics.Debug.WriteLine($"UpdateUnitConversion error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Xóa quy đổi
        /// </summary>
        public int DeleteUnitConversion(int conversionID)
        {
            try
            {
                string procName = "sp_DeleteUnitConversion";

                var inputParams = new Dictionary<string, object>
                {
                    { "@ConversionID", conversionID }
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
                System.Diagnostics.Debug.WriteLine($"DeleteUnitConversion error: {ex.Message}");
                return -99;
            }
        }

        #endregion

        /// <summary>
        /// Lấy giá bán theo sản phẩm và đơn vị
        /// </summary>
        public PriceList GetPriceByProductAndUnit(int productID, int unitID)
        {
            try
            {
                string query = @"
            SELECT TOP 1 PriceID, ProductID, UnitID, GiaBan, NgayApDung
            FROM PriceList
            WHERE ProductID = @productID AND UnitID = @unitID
            ORDER BY NgayApDung DESC";

                object[] parameters = new object[] { productID, unitID };
                DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters,false );

                if (dt.Rows.Count > 0)
                    return new PriceList(dt.Rows[0]);

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetPriceByProductAndUnit error: {ex}");
                return null;
            }
        }
    }
}