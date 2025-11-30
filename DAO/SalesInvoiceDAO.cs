using System;
using System.Collections.Generic;
using System.Data;
using DoubleTRice.DT;

namespace DoubleTRice.DAO
{
    public class SalesInvoiceDAO
    {
        private static SalesInvoiceDAO instance;

        public static SalesInvoiceDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SalesInvoiceDAO();
                return instance;
            }
        }

        private SalesInvoiceDAO() { }

        #region Get Methods

        /// <summary>
        /// Lấy tất cả hóa đơn bán hàng
        /// </summary>
        public List<SalesInvoices> GetAllInvoices()
        {
            List<SalesInvoices> list = new List<SalesInvoices>();
            string query = @"
                SELECT InvoiceID, MaHoaDon, CustomerID, UserID, 
                       NgayBan, TongTien, TrangThai 
                FROM SalesInvoices 
                ORDER BY NgayBan DESC";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                list.Add(new SalesInvoices(row));
            }
            return list;
        }

        /// <summary>
        /// Lấy hóa đơn theo khoảng thời gian
        /// </summary>
        public List<SalesInvoices> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<SalesInvoices> list = new List<SalesInvoices>();
            string query = @"
                SELECT InvoiceID, MaHoaDon, CustomerID, UserID, 
                       NgayBan, TongTien, TrangThai 
                FROM SalesInvoices 
                WHERE CAST(NgayBan AS DATE) BETWEEN @startDate AND @endDate
                ORDER BY NgayBan DESC";

            object[] parameters = new object[] { startDate, endDate };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new SalesInvoices(row));
            }
            return list;
        }

        /// <summary>
        /// Lấy hóa đơn theo ID
        /// </summary>
        public SalesInvoices GetInvoiceByID(int invoiceID)
        {
            string query = @"
                SELECT InvoiceID, MaHoaDon, CustomerID, UserID, 
                       NgayBan, TongTien, TrangThai 
                FROM SalesInvoices 
                WHERE InvoiceID = @invoiceID";

            object[] parameters = new object[] { invoiceID };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (data.Rows.Count > 0)
                return new SalesInvoices(data.Rows[0]);
            return null;
        }

        /// <summary>
        /// Lấy chi tiết hóa đơn
        /// </summary>
        public List<SalesInvoiceDetails> GetInvoiceDetails(int invoiceID)
        {
            List<SalesInvoiceDetails> list = new List<SalesInvoiceDetails>();
            string query = @"
                SELECT InvoiceDetailID, InvoiceID, ProductID, UnitID, 
                       SoLuong, DonGiaBan, ThanhTien 
                FROM SalesInvoiceDetails 
                WHERE InvoiceID = @invoiceID";

            object[] parameters = new object[] { invoiceID };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            foreach (DataRow row in data.Rows)
            {
                list.Add(new SalesInvoiceDetails(row));
            }
            return list;
        }

        #endregion

        #region Insert Methods

        /// <summary>
        /// Tạo hóa đơn mới
        /// Return: (resultCode, newInvoiceID)
        /// 0: Success, -1: Customer not found, -99: Error
        /// </summary>
        public (int, int) InsertSalesInvoice(int customerID, int userID, DateTime ngayBan, string trangThai = "Đã thanh toán")
        {
            try
            {
                string query = @"
                    INSERT INTO SalesInvoices (CustomerID, UserID, NgayBan, TrangThai)
                    VALUES (@customerID, @userID, @ngayBan, @trangThai);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                object[] parameters = new object[] { customerID, userID, ngayBan, trangThai };

                object result = DataProvider.Instance.ExecuteScalar(query,
                    new Dictionary<string, object>
                    {
                        { "@customerID", customerID },
                        { "@userID", userID },
                        { "@ngayBan", ngayBan },
                        { "@trangThai", trangThai }
                    });

                if (result != null && int.TryParse(result.ToString(), out int newID))
                {
                    return (0, newID);
                }
                return (-99, 0);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertSalesInvoice error: {ex}");
                return (-99, 0);
            }
        }

        /// <summary>
        /// Thêm chi tiết hóa đơn
        /// </summary>
        public int InsertInvoiceDetail(int invoiceID, int productID, int unitID,
            double soLuong, decimal donGiaBan)
        {
            try
            {
                string query = @"
                    INSERT INTO SalesInvoiceDetails 
                    (InvoiceID, ProductID, UnitID, SoLuong, DonGiaBan, ThanhTien)
                    VALUES (@invoiceID, @productID, @unitID, @soLuong, @donGiaBan, 
                            @soLuong * @donGiaBan)";

                object[] parameters = new object[]
                {
                    invoiceID, productID, unitID, soLuong, donGiaBan
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                return result > 0 ? 0 : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"InsertInvoiceDetail error: {ex}");
                return -99;
            }
        }

        #endregion

        #region Update Methods

        /// <summary>
        /// Cập nhật tổng tiền hóa đơn
        /// </summary>
        public int UpdateInvoiceTotalAmount(int invoiceID)
        {
            try
            {
                string query = @"
                    UPDATE SalesInvoices
                    SET TongTien = (
                        SELECT ISNULL(SUM(ThanhTien), 0)
                        FROM SalesInvoiceDetails
                        WHERE InvoiceID = @invoiceID
                    )
                    WHERE InvoiceID = @invoiceID";

                object[] parameters = new object[] { invoiceID };
                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                return result > 0 ? 0 : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateInvoiceTotalAmount error: {ex}");
                return -99;
            }
        }

        /// <summary>
        /// Cập nhật trạng thái hóa đơn
        /// </summary>
        public int UpdateInvoiceStatus(int invoiceID, string trangThai)
        {
            try
            {
                string query = @"
                    UPDATE SalesInvoices
                    SET TrangThai = @trangThai
                    WHERE InvoiceID = @invoiceID";

                object[] parameters = new object[] { trangThai, invoiceID };
                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                return result > 0 ? 0 : -1;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"UpdateInvoiceStatus error: {ex}");
                return -99;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// Xóa hóa đơn (chỉ cho phép trong ngày)
        /// </summary>
        public int DeleteInvoice(int invoiceID)
        {
            try
            {
                // Kiểm tra ngày tạo
                string checkQuery = @"
                    SELECT CAST(NgayBan AS DATE) 
                    FROM SalesInvoices 
                    WHERE InvoiceID = @invoiceID";

                object[] checkParams = new object[] { invoiceID };
                DataTable dt = DataProvider.Instance.ExecuteQuery(checkQuery, checkParams);

                if (dt.Rows.Count == 0)
                    return -1; // Không tìm thấy

                DateTime ngayBan = Convert.ToDateTime(dt.Rows[0][0]);
                if (ngayBan.Date != DateTime.Now.Date)
                    return -2; // Không cho phép xóa

                // Xóa chi tiết trước
                string deleteDetailsQuery = @"
                    DELETE FROM SalesInvoiceDetails 
                    WHERE InvoiceID = @invoiceID";
                DataProvider.Instance.ExecuteNonQuery(deleteDetailsQuery, checkParams);

                // Xóa hóa đơn
                string deleteQuery = @"
                    DELETE FROM SalesInvoices 
                    WHERE InvoiceID = @invoiceID";
                int result = DataProvider.Instance.ExecuteNonQuery(deleteQuery, checkParams);

                return result > 0 ? 0 : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DeleteInvoice error: {ex}");
                return -99;
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Tự động trừ kho sau khi thanh toán
        /// </summary>
        public int ProcessInventoryDeduction(int invoiceID)
        {
            try
            {
                string query = @"
                    UPDATE PI
                    SET PI.SoLuongTon = PI.SoLuongTon - (
                        SID.SoLuong * PUC.GiaTriQuyDoi
                    )
                    FROM ProductInventory PI
                    INNER JOIN SalesInvoiceDetails SID ON PI.ProductID = SID.ProductID
                    INNER JOIN ProductUnitConversions PUC 
                        ON SID.ProductID = PUC.ProductID AND SID.UnitID = PUC.UnitID
                    WHERE SID.InvoiceID = @invoiceID";

                object[] parameters = new object[] { invoiceID };
                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
                return result > 0 ? 0 : -99;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ProcessInventoryDeduction error: {ex}");
                return -99;
            }
        }

        /// <summary>
        /// Kiểm tra tồn kho trước khi bán
        /// </summary>
        public bool CheckInventoryAvailability(int productID, int unitID, double soLuong)
        {
            try
            {
                string query = @"
                    SELECT 
                        CASE 
                            WHEN PI.SoLuongTon >= (@soLuong * PUC.GiaTriQuyDoi) 
                            THEN 1 
                            ELSE 0 
                        END AS IsAvailable
                    FROM ProductInventory PI
                    INNER JOIN ProductUnitConversions PUC 
                        ON PI.ProductID = PUC.ProductID
                    WHERE PI.ProductID = @productID 
                        AND PUC.UnitID = @unitID";

                object[] parameters = new object[] { soLuong, productID, unitID };
                DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["IsAvailable"]) == 1;
                }
                return false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CheckInventoryAvailability error: {ex}");
                return false;
            }
        }

        #endregion
    }
}