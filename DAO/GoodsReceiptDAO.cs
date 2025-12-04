using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho GoodsReceipts (Phiếu nhập kho)
    /// </summary>
    public class GoodsReceiptDAO
    {
        #region Singleton
        private static GoodsReceiptDAO instance;
        public static GoodsReceiptDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new GoodsReceiptDAO();
                return instance;
            }
        }

        private GoodsReceiptDAO() { }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Lấy tất cả phiếu nhập theo khoảng thời gian
        /// </summary>
        public List<GoodsReceipts> GetGoodsReceiptsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                string query = @"
                    SELECT * FROM GoodsReceipts 
                    WHERE CONVERT(DATE, NgayNhap) BETWEEN @StartDate AND @EndDate
                    ORDER BY NgayNhap DESC";

                object[] parameters = { startDate, endDate };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters, false);

                List<GoodsReceipts> receipts = new List<GoodsReceipts>();
                foreach (DataRow row in data.Rows)
                {
                    receipts.Add(new GoodsReceipts(row));
                }

                return receipts;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetGoodsReceiptsByDateRange error: {ex.Message}");
                return new List<GoodsReceipts>();
            }
        }

        /// <summary>
        /// Lấy thông tin 1 phiếu nhập
        /// </summary>
        public GoodsReceipts GetGoodsReceiptByID(int receiptID)
        {
            try
            {
                string query = "SELECT * FROM GoodsReceipts WHERE ReceiptID = @ReceiptID";
                object[] parameters = { receiptID };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters, false);

                if (data.Rows.Count > 0)
                {
                    return new GoodsReceipts(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetGoodsReceiptByID error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm phiếu nhập mới
        /// Lưu ý: MaPhieuNhap sẽ được trigger tự động tạo
        /// </summary>
        public (int result, int newReceiptID) InsertGoodsReceipt(
        int supplierID,
        int userID,
        DateTime ngayNhap,
        string ghiChu = null)
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine($"DAO.InsertGoodsReceipt - START");
                    System.Diagnostics.Debug.WriteLine($"  SupplierID: {supplierID}");
                    System.Diagnostics.Debug.WriteLine($"  UserID: {userID}");
                    System.Diagnostics.Debug.WriteLine($"  NgayNhap: {ngayNhap}");
                    System.Diagnostics.Debug.WriteLine($"  GhiChu: {ghiChu ?? "(null)"}");

                    string query = @"
                INSERT INTO GoodsReceipts (SupplierID, UserID, NgayNhap, GhiChu, TongTien)
                VALUES (@SupplierID, @UserID, @NgayNhap, @GhiChu, 0);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    // ✅ SỬA: Sử dụng Dictionary thay vì object[]
                    var parameters = new Dictionary<string, object>
            {
                { "@SupplierID", supplierID },
                { "@UserID", userID },
                { "@NgayNhap", ngayNhap },
                { "@GhiChu", ghiChu ?? (object)DBNull.Value }
            };

                    object result = DataProvider.Instance.ExecuteScalar(query, parameters, false); // ✅ Thêm false

                    int newReceiptID = result != null ? Convert.ToInt32(result) : 0;

                    System.Diagnostics.Debug.WriteLine($"  NewReceiptID: {newReceiptID}");
                    System.Diagnostics.Debug.WriteLine($"DAO.InsertGoodsReceipt - SUCCESS");

                    return (0, newReceiptID);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"❌ DAO.InsertGoodsReceipt ERROR: {ex.Message}");
                    System.Diagnostics.Debug.WriteLine($"   StackTrace: {ex.StackTrace}");
                    return (-99, 0);
                }
            }

        /// <summary>
        /// Thêm chi tiết phiếu nhập (sản phẩm)
        /// </summary>
        public int InsertGoodsReceiptDetail(
            int receiptID,
            int productID,
            int unitID,
            double soLuong,
            decimal donGiaNhap)
        {
            try
            {
                string query = @"
                    INSERT INTO GoodsReceiptDetails 
                    (ReceiptID, ProductID, UnitID, SoLuong, DonGiaNhap)
                    VALUES (@ReceiptID, @ProductID, @UnitID, @SoLuong, @DonGiaNhap)";

                object[] parameters = { receiptID, productID, unitID, soLuong, donGiaNhap };
                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                return result > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertGoodsReceiptDetail error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Cập nhật tổng tiền phiếu nhập
        /// </summary>
        public int UpdateGoodsReceiptTotalAmount(int receiptID)
        {
            try
            {
                string procName = "sp_UpdateGoodsReceiptTotalAmount";
                object[] parameters = { receiptID };

                // ✅ SỬA: Gọi ExecuteNonQuery với flag isStoredProc = true
                string query = procName;
                int result = DataProvider.Instance.ExecuteNonQuery(procName, parameters);

                // Debug
                System.Diagnostics.Debug.WriteLine($"[UpdateTotalAmount] ReceiptID: {receiptID}, Result: {result}");

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateGoodsReceiptTotalAmount error: {ex.Message}");
                MessageBox.Show($"Lỗi cập nhật tổng tiền: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -99;
            }
        }

        /// <summary>
        /// Lấy chi tiết phiếu nhập
        /// </summary>
        public List<GoodsReceiptDetails> GetGoodsReceiptDetails(int receiptID)
        {
            try
            {
                string query = "SELECT * FROM GoodsReceiptDetails WHERE ReceiptID = @ReceiptID";
                object[] parameters = { receiptID };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters, false);

                List<GoodsReceiptDetails> details = new List<GoodsReceiptDetails>();
                foreach (DataRow row in data.Rows)
                {
                    details.Add(new GoodsReceiptDetails(row));
                }

                return details;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetGoodsReceiptDetails error: {ex.Message}");
                return new List<GoodsReceiptDetails>();
            }
        }

        /// <summary>
        /// Xóa phiếu nhập (chỉ cho phép trong ngày)
        /// </summary>
        public int DeleteGoodsReceipt(int receiptID)
        {
            try
            {
                // Kiểm tra phiếu nhập có tồn tại không
                var receipt = GetGoodsReceiptByID(receiptID);
                if (receipt == null)
                {
                    return -1; // Phiếu nhập không tồn tại
                }

                // Kiểm tra thời gian: chỉ cho phép xóa trong ngày
                if (receipt.NgayNhap.HasValue && receipt.NgayNhap.Value.Date != DateTime.Now.Date)
                {
                    return -2; // Không thể xóa phiếu nhập quá hạn
                }

                // Xóa chi tiết trước
                string deleteDetailsQuery = "DELETE FROM GoodsReceiptDetails WHERE ReceiptID = @ReceiptID";
                DataProvider.Instance.ExecuteNonQuery(deleteDetailsQuery, new object[] { receiptID });

                // Xóa phiếu nhập
                string deleteReceiptQuery = "DELETE FROM GoodsReceipts WHERE ReceiptID = @ReceiptID";
                int result = DataProvider.Instance.ExecuteNonQuery(deleteReceiptQuery, new object[] { receiptID });

                return result > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteGoodsReceipt error: {ex.Message}");
                return -99;
            }
        }
        // Trong GoodsReceiptDAO.cs
        public List<GoodsReceipts> GetReceiptsBySupplier(int supplierID)
        {
            try
            {
                string query = @"
            SELECT * FROM GoodsReceipts
            WHERE SupplierID = @SupplierID
            ORDER BY NgayNhap DESC";

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    query,
                    new object[] { supplierID },
                    isStoredProc: false
                );

                List<GoodsReceipts> list = new List<GoodsReceipts>();
                foreach (DataRow row in data.Rows)
                {
                    list.Add(new GoodsReceipts(row));
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi: {ex.Message}");
            }
        }
        #endregion
    }
}