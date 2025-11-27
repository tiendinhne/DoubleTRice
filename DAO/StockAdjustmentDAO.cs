using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho StockAdjustments (Phiếu điều chỉnh kho)
    /// </summary>
    public class StockAdjustmentDAO
    {
        #region Singleton
        private static StockAdjustmentDAO instance;
        public static StockAdjustmentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StockAdjustmentDAO();
                return instance;
            }
        }

        private StockAdjustmentDAO() { }
        #endregion

        #region CRUD Methods

        /// <summary>
        /// Lấy tất cả phiếu điều chỉnh theo khoảng thời gian
        /// </summary>
        public List<StockAdjustments> GetStockAdjustmentsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                string query = @"
                    SELECT * FROM StockAdjustments 
                    WHERE CONVERT(DATE, NgayDieuChinh) BETWEEN @StartDate AND @EndDate
                    ORDER BY NgayDieuChinh DESC";

                object[] parameters = { startDate, endDate };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

                List<StockAdjustments> adjustments = new List<StockAdjustments>();
                foreach (DataRow row in data.Rows)
                {
                    adjustments.Add(new StockAdjustments(row));
                }

                return adjustments;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetStockAdjustmentsByDateRange error: {ex.Message}");
                return new List<StockAdjustments>();
            }
        }

        /// <summary>
        /// Lấy thông tin 1 phiếu điều chỉnh
        /// </summary>
        public StockAdjustments GetStockAdjustmentByID(int adjustmentID)
        {
            try
            {
                string query = "SELECT * FROM StockAdjustments WHERE AdjustmentID = @AdjustmentID";
                object[] parameters = { adjustmentID };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

                if (data.Rows.Count > 0)
                {
                    return new StockAdjustments(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetStockAdjustmentByID error: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Thêm phiếu điều chỉnh mới
        /// Lưu ý: 
        /// - MaPhieu sẽ được trigger tự động tạo
        /// - SoLuongDieuChinh: số âm là XUẤT (PX), số dương là NHẬP (PN)
        /// - Trigger sẽ tự động cập nhật ProductInventory
        /// </summary>
        public (int result, int newAdjustmentID) InsertStockAdjustment(
            int productID,
            int userID,
            DateTime ngayDieuChinh,
            double soLuongDieuChinh,
            string lyDo)
        {
            try
            {
                // Validate
                if (string.IsNullOrWhiteSpace(lyDo))
                {
                    return (-2, 0); // Lý do không được trống
                }

                string query = @"
                    INSERT INTO StockAdjustments 
                    (ProductID, UserID, NgayDieuChinh, SoLuongDieuChinh, LyDo)
                    VALUES (@ProductID, @UserID, @NgayDieuChinh, @SoLuongDieuChinh, @LyDo);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                object result = DataProvider.Instance.ExecuteScalar(query,
                    new Dictionary<string, object>
                    {
                        { "@ProductID", productID },
                        { "@UserID", userID },
                        { "@NgayDieuChinh", ngayDieuChinh },
                        { "@SoLuongDieuChinh", soLuongDieuChinh },
                        { "@LyDo", lyDo }
                    }, false);

                int newAdjustmentID = result != null ? Convert.ToInt32(result) : 0;
                return (0, newAdjustmentID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertStockAdjustment error: {ex.Message}");
                return (-99, 0);
            }
        }

        /// <summary>
        /// Xóa phiếu điều chỉnh (chỉ cho phép trong ngày)
        /// Lưu ý: Cần hoàn tác số lượng đã điều chỉnh
        /// </summary>
        public int DeleteStockAdjustment(int adjustmentID)
        {
            try
            {
                // Kiểm tra phiếu có tồn tại không
                var adjustment = GetStockAdjustmentByID(adjustmentID);
                if (adjustment == null)
                {
                    return -1; // Phiếu không tồn tại
                }

                // Kiểm tra thời gian: chỉ cho phép xóa trong ngày
                if (adjustment.NgayDieuChinh.HasValue &&
                    adjustment.NgayDieuChinh.Value.Date != DateTime.Now.Date)
                {
                    return -2; // Không thể xóa phiếu quá hạn
                }

                // Hoàn tác số lượng (trừ đi số đã điều chỉnh)
                string revertQuery = @"
                    UPDATE ProductInventory
                    SET SoLuongTon = SoLuongTon - @SoLuongDieuChinh
                    WHERE ProductID = @ProductID";

                DataProvider.Instance.ExecuteNonQuery(revertQuery,
                    new object[] { adjustment.SoLuongDieuChinh, adjustment.ProductID });

                // Xóa phiếu
                string deleteQuery = "DELETE FROM StockAdjustments WHERE AdjustmentID = @AdjustmentID";
                int result = DataProvider.Instance.ExecuteNonQuery(deleteQuery,
                    new object[] { adjustmentID });

                return result > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteStockAdjustment error: {ex.Message}");
                return -99;
            }
        }

        /// <summary>
        /// Lấy lịch sử điều chỉnh của 1 sản phẩm
        /// </summary>
        public List<StockAdjustments> GetAdjustmentHistoryByProduct(int productID, int limit = 10)
        {
            try
            {
                string query = @"
                    SELECT TOP (@Limit) * FROM StockAdjustments 
                    WHERE ProductID = @ProductID
                    ORDER BY NgayDieuChinh DESC";

                object[] parameters = { limit, productID };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

                List<StockAdjustments> adjustments = new List<StockAdjustments>();
                foreach (DataRow row in data.Rows)
                {
                    adjustments.Add(new StockAdjustments(row));
                }

                return adjustments;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAdjustmentHistoryByProduct error: {ex.Message}");
                return new List<StockAdjustments>();
            }
        }

        /// <summary>
        /// Thống kê tổng số lượng xuất hủy/nhập thừa theo thời gian
        /// </summary>
        public (double tongXuatHuy, double tongNhapThua) GetAdjustmentSummary(
            DateTime startDate, DateTime endDate)
        {
            try
            {
                string query = @"
                    SELECT 
                        SUM(CASE WHEN SoLuongDieuChinh < 0 THEN ABS(SoLuongDieuChinh) ELSE 0 END) AS TongXuatHuy,
                        SUM(CASE WHEN SoLuongDieuChinh > 0 THEN SoLuongDieuChinh ELSE 0 END) AS TongNhapThua
                    FROM StockAdjustments
                    WHERE CONVERT(DATE, NgayDieuChinh) BETWEEN @StartDate AND @EndDate";

                object[] parameters = { startDate, endDate };
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

                if (data.Rows.Count > 0)
                {
                    double tongXuatHuy = data.Rows[0]["TongXuatHuy"] != DBNull.Value ?
                        Convert.ToDouble(data.Rows[0]["TongXuatHuy"]) : 0;
                    double tongNhapThua = data.Rows[0]["TongNhapThua"] != DBNull.Value ?
                        Convert.ToDouble(data.Rows[0]["TongNhapThua"]) : 0;

                    return (tongXuatHuy, tongNhapThua);
                }

                return (0, 0);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GetAdjustmentSummary error: {ex.Message}");
                return (0, 0);
            }
        }

        #endregion
    }
}