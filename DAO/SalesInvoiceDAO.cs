using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DoubleTRice.DT;
using Newtonsoft.Json;

namespace DoubleTRice.DAO
{
    /// <summary>
    /// Data Access Object cho Hóa đơn bán hàng
    /// </summary>
    public class SalesInvoiceDAO
    {
        #region Singleton Pattern
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
        #endregion

        #region 1. READ Operations

        /// <summary>
        /// Lấy danh sách hóa đơn theo khoảng thời gian
        /// </summary>
        public List<SalesInvoices> GetSalesInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            List<SalesInvoices> list = new List<SalesInvoices>();

            try
            {
                string query = @"
                    SELECT 
                        si.InvoiceID,
                        si.MaHoaDon,
                        si.CustomerID,
                        si.UserID,
                        si.NgayBan,
                        si.TongTien,
                        c.TenKhachHang AS CustomerName,
                        u.HoTen AS UserName,
                        ISNULL(SUM(cp.SoTien), 0) AS SoTienDaTra,
                        (si.TongTien - ISNULL(SUM(cp.SoTien), 0)) AS ConLai,
                        CASE 
                            WHEN (si.TongTien - ISNULL(SUM(cp.SoTien), 0)) <= 0 THEN N'Đã thanh toán'
                            ELSE N'Ghi nợ'
                        END AS TrangThaiThanhToan
                    FROM SalesInvoices si
                    LEFT JOIN Customers c ON si.CustomerID = c.CustomerID
                    LEFT JOIN Users u ON si.UserID = u.UserID
                    LEFT JOIN CustomerPayments cp ON si.InvoiceID = cp.InvoiceID
                    WHERE CONVERT(DATE, si.NgayBan) BETWEEN @StartDate AND @EndDate
                    GROUP BY si.InvoiceID, si.MaHoaDon, si.CustomerID, si.UserID, 
                             si.NgayBan, si.TongTien, c.TenKhachHang, u.HoTen
                    ORDER BY si.NgayBan DESC";

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    query,
                    new object[] { startDate, endDate }
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new SalesInvoices(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách hóa đơn: {ex.Message}");
            }

            return list;
        }

        /// <summary>
        /// Lấy thông tin chi tiết 1 hóa đơn theo ID
        /// </summary>
        public SalesInvoices GetSalesInvoiceByID(int invoiceID)
        {
            try
            {
                string query = @"
                    SELECT 
                        si.InvoiceID,
                        si.MaHoaDon,
                        si.CustomerID,
                        si.UserID,
                        si.NgayBan,
                        si.TongTien,
                        c.TenKhachHang AS CustomerName,
                        u.HoTen AS UserName,
                        ISNULL(SUM(cp.SoTien), 0) AS SoTienDaTra,
                        (si.TongTien - ISNULL(SUM(cp.SoTien), 0)) AS ConLai,
                        CASE 
                            WHEN (si.TongTien - ISNULL(SUM(cp.SoTien), 0)) <= 0 THEN N'Đã thanh toán'
                            ELSE N'Ghi nợ'
                        END AS TrangThaiThanhToan
                    FROM SalesInvoices si
                    LEFT JOIN Customers c ON si.CustomerID = c.CustomerID
                    LEFT JOIN Users u ON si.UserID = u.UserID
                    LEFT JOIN CustomerPayments cp ON si.InvoiceID = cp.InvoiceID
                    WHERE si.InvoiceID = @InvoiceID
                    GROUP BY si.InvoiceID, si.MaHoaDon, si.CustomerID, si.UserID, 
                             si.NgayBan, si.TongTien, c.TenKhachHang, u.HoTen";

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    query,
                    new object[] { invoiceID }
                );

                if (data.Rows.Count > 0)
                {
                    return new SalesInvoices(data.Rows[0]);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin hóa đơn: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy chi tiết sản phẩm của 1 hóa đơn
        /// </summary>
        public List<SalesInvoiceDetails> GetInvoiceDetails(int invoiceID)
        {
            List<SalesInvoiceDetails> list = new List<SalesInvoiceDetails>();

            try
            {
                string query = @"
                    SELECT 
                        sid.InvoiceDetailID,
                        sid.InvoiceID,
                        sid.ProductID,
                        sid.UnitID,
                        sid.SoLuong,
                        sid.DonGiaBan,
                        sid.ThanhTien,
                        p.TenSanPham AS ProductName,
                        u.TenDVT AS UnitName,
                        puc.GiaTriQuyDoi
                    FROM SalesInvoiceDetails sid
                    INNER JOIN Products p ON sid.ProductID = p.ProductID
                    INNER JOIN Units u ON sid.UnitID = u.UnitID
                    INNER JOIN ProductUnitConversions puc 
                        ON sid.ProductID = puc.ProductID AND sid.UnitID = puc.UnitID
                    WHERE sid.InvoiceID = @InvoiceID
                    ORDER BY sid.InvoiceDetailID";

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    query,
                    new object[] { invoiceID }
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new SalesInvoiceDetails(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy chi tiết hóa đơn: {ex.Message}");
            }

            return list;
        }

        #endregion

        #region 2. CREATE Operations

        /// <summary>
        /// Tạo hóa đơn mới với chi tiết
        /// </summary>
        /// <param name="customerID">ID khách hàng</param>
        /// <param name="userID">ID nhân viên bán</param>
        /// <param name="tongTien">Tổng tiền hóa đơn</param>
        /// <param name="details">Danh sách chi tiết sản phẩm</param>
        /// <param name="newInvoiceID">OUTPUT: ID hóa đơn mới tạo</param>
        /// <returns>0: Thành công, -3: Không tìm thấy quy đổi, -4: Không đủ hàng, -99: Lỗi hệ thống</returns>
        public int InsertSalesInvoice(int customerID, int userID, decimal tongTien,
            List<SalesInvoiceDetails> details, out int newInvoiceID)
        {
            newInvoiceID = 0;

            try
            {
                // Convert details list sang JSON
                var detailsList = new List<object>();
                foreach (var detail in details)
                {
                    detailsList.Add(new
                    {
                        ProductID = detail.ProductID,
                        UnitID = detail.UnitID,
                        SoLuong = detail.SoLuong,
                        DonGiaBan = detail.DonGiaBan
                    });
                }
                string jsonDetails = JsonConvert.SerializeObject(detailsList);

                // Gọi Stored Procedure
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_InsertSalesInvoice",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@CustomerID", customerID },
                        { "@UserID", userID },
                        { "@TongTien", tongTien },
                        { "@Details", jsonDetails }
                    },
                    outputParams: new Dictionary<string, SqlDbType>
                    {
                        { "@Result", SqlDbType.Int },
                        { "@NewInvoiceID", SqlDbType.Int }
                    }
                );

                int result = outputs["@Result"] != DBNull.Value ? (int)outputs["@Result"] : -99;
                newInvoiceID = outputs["@NewInvoiceID"] != DBNull.Value ? (int)outputs["@NewInvoiceID"] : 0;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tạo hóa đơn: {ex.Message}");
            }
        }

        #endregion

        #region 3. DELETE Operations

        /// <summary>
        /// Xóa hóa đơn (chỉ cho phép trong ngày)
        /// </summary>
        /// <returns>0: Thành công, -1: Không tồn tại, -2: Quá thời gian, -99: Lỗi hệ thống</returns>
        public int DeleteSalesInvoice(int invoiceID)
        {
            try
            {
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_DeleteSalesInvoice",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@InvoiceID", invoiceID }
                    },
                    outputParams: new Dictionary<string, SqlDbType>
                    {
                        { "@Result", SqlDbType.Int }
                    }
                );

                return outputs["@Result"] != DBNull.Value ? (int)outputs["@Result"] : -99;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa hóa đơn: {ex.Message}");
            }
        }

        #endregion

        #region 4. STOCK CHECKING Operations

        /// <summary>
        /// Kiểm tra tồn kho có đủ để bán không
        /// </summary>
        /// <param name="productID">ID sản phẩm</param>
        /// <param name="unitID">ID đơn vị tính</param>
        /// <param name="soLuong">Số lượng muốn bán</param>
        /// <param name="soLuongTonHienTai">OUTPUT: Số lượng tồn hiện tại (theo kg)</param>
        /// <returns>true: Đủ hàng, false: Không đủ</returns>
        public bool CheckStockAvailability(int productID, int unitID, double soLuong, out double soLuongTonHienTai)
        {
            soLuongTonHienTai = 0;

            try
            {
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_CheckStockAvailability",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@ProductID", productID },
                        { "@UnitID", unitID },
                        { "@SoLuong", soLuong }
                    },
                    outputParams: new Dictionary<string, SqlDbType>
                    {
                        { "@IsAvailable", SqlDbType.Bit },
                        { "@SoLuongTonHienTai", SqlDbType.Float }
                    }
                );

                bool isAvailable = outputs["@IsAvailable"] != DBNull.Value ? (bool)outputs["@IsAvailable"] : false;
                soLuongTonHienTai = outputs["@SoLuongTonHienTai"] != DBNull.Value ? (double)outputs["@SoLuongTonHienTai"] : 0;

                return isAvailable;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi kiểm tra tồn kho: {ex.Message}");
            }
        }

        #endregion

        #region 5. PAYMENT Operations

        /// <summary>
        /// Thêm thanh toán mới
        /// </summary>
        /// <returns>0: Thành công, -2: Số tiền không hợp lệ, -99: Lỗi hệ thống</returns>
        public int InsertCustomerPayment(int customerID, int invoiceID, decimal soTien, string phuongThuc)
        {
            try
            {
                var outputs = DataProvider.Instance.ExecuteProcedureWithMultipleOutputs(
                    "sp_InsertCustomerPayment",
                    inputParams: new Dictionary<string, object>
                    {
                        { "@CustomerID", customerID },
                        { "@InvoiceID", invoiceID },
                        { "@SoTien", soTien },
                        { "@PhuongThuc", phuongThuc }
                    },
                    outputParams: new Dictionary<string, SqlDbType>
                    {
                        { "@Result", SqlDbType.Int }
                    }
                );

                return outputs["@Result"] != DBNull.Value ? (int)outputs["@Result"] : -99;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm thanh toán: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy lịch sử thanh toán của 1 hóa đơn
        /// </summary>
        public List<CustomerPayments> GetPaymentsByInvoiceID(int invoiceID)
        {
            List<CustomerPayments> list = new List<CustomerPayments>();

            try
            {
                string query = @"
                    SELECT 
                        cp.PaymentID,
                        cp.CustomerID,
                        cp.InvoiceID,
                        cp.NgayThanhToan,
                        cp.SoTien,
                        cp.PhuongThuc,
                        c.TenKhachHang AS CustomerName,
                        si.MaHoaDon
                    FROM CustomerPayments cp
                    LEFT JOIN Customers c ON cp.CustomerID = c.CustomerID
                    LEFT JOIN SalesInvoices si ON cp.InvoiceID = si.InvoiceID
                    WHERE cp.InvoiceID = @InvoiceID
                    ORDER BY cp.NgayThanhToan DESC";

                DataTable data = DataProvider.Instance.ExecuteQuery(
                    query,
                    new object[] { invoiceID }
                );

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new CustomerPayments(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy lịch sử thanh toán: {ex.Message}");
            }

            return list;
        }

        /// <summary>
        /// Tính công nợ của khách hàng
        /// </summary>
        /// <param name="customerID">ID khách hàng</param>
        /// <param name="tongMuaHang">OUTPUT: Tổng tiền đã mua</param>
        /// <param name="tongDaTra">OUTPUT: Tổng tiền đã trả</param>
        /// <param name="congNoHienTai">OUTPUT: Công nợ hiện tại</param>
        public void GetCustomerDebt(int customerID, out decimal tongMuaHang,
            out decimal tongDaTra, out decimal congNoHienTai)
        {
            tongMuaHang = 0;
            tongDaTra = 0;
            congNoHienTai = 0;

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(
                    "sp_GetCustomerDebt",
                    new object[] { customerID },
                    isStoredProc: true
                );

                if (data.Rows.Count > 0)
                {
                    DataRow row = data.Rows[0];
                    tongMuaHang = row["TongMuaHang"] != DBNull.Value ? (decimal)row["TongMuaHang"] : 0;
                    tongDaTra = row["TongDaTra"] != DBNull.Value ? (decimal)row["TongDaTra"] : 0;
                    congNoHienTai = row["CongNoHienTai"] != DBNull.Value ? (decimal)row["CongNoHienTai"] : 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tính công nợ: {ex.Message}");
            }
        }

        #endregion

        #region 6. SEARCH & FILTER Operations

        /// <summary>
        /// Tìm kiếm hóa đơn theo từ khóa
        /// </summary>
        public List<SalesInvoices> SearchInvoices(string keyword, DateTime? startDate = null, DateTime? endDate = null)
        {
            List<SalesInvoices> list = new List<SalesInvoices>();

            try
            {
                string query = @"
                    SELECT 
                        si.InvoiceID,
                        si.MaHoaDon,
                        si.CustomerID,
                        si.UserID,
                        si.NgayBan,
                        si.TongTien,
                        c.TenKhachHang AS CustomerName,
                        u.HoTen AS UserName,
                        ISNULL(SUM(cp.SoTien), 0) AS SoTienDaTra,
                        (si.TongTien - ISNULL(SUM(cp.SoTien), 0)) AS ConLai,
                        CASE 
                            WHEN (si.TongTien - ISNULL(SUM(cp.SoTien), 0)) <= 0 THEN N'Đã thanh toán'
                            ELSE N'Ghi nợ'
                        END AS TrangThaiThanhToan
                    FROM SalesInvoices si
                    LEFT JOIN Customers c ON si.CustomerID = c.CustomerID
                    LEFT JOIN Users u ON si.UserID = u.UserID
                    LEFT JOIN CustomerPayments cp ON si.InvoiceID = cp.InvoiceID
                    WHERE (si.MaHoaDon LIKE N'%' + @Keyword + '%' 
                           OR c.TenKhachHang LIKE N'%' + @Keyword + '%')";

                if (startDate.HasValue && endDate.HasValue)
                {
                    query += " AND CONVERT(DATE, si.NgayBan) BETWEEN @StartDate AND @EndDate";
                }

                query += @"
                    GROUP BY si.InvoiceID, si.MaHoaDon, si.CustomerID, si.UserID, 
                             si.NgayBan, si.TongTien, c.TenKhachHang, u.HoTen
                    ORDER BY si.NgayBan DESC";

                DataTable data;
                if (startDate.HasValue && endDate.HasValue)
                {
                    data = DataProvider.Instance.ExecuteQuery(
                        query,
                        new object[] { keyword, startDate.Value, endDate.Value }
                    );
                }
                else
                {
                    data = DataProvider.Instance.ExecuteQuery(
                        query,
                        new object[] { keyword }
                    );
                }

                foreach (DataRow row in data.Rows)
                {
                    list.Add(new SalesInvoices(row));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm hóa đơn: {ex.Message}");
            }

            return list;
        }

        #endregion
    }
}

//using System;
//using System.Collections.Generic;
//using System.Data;
//using DoubleTRice.DT;

//namespace DoubleTRice.DAO
//{
//    public class SalesInvoiceDAO
//    {
//        private static SalesInvoiceDAO instance;

//        public static SalesInvoiceDAO Instance
//        {
//            get
//            {
//                if (instance == null)
//                    instance = new SalesInvoiceDAO();
//                return instance;
//            }
//        }

//        private SalesInvoiceDAO() { }

//        #region Get Methods

//        /// <summary>
//        /// Lấy tất cả hóa đơn bán hàng
//        /// </summary>
//        public List<SalesInvoices> GetAllInvoices()
//        {
//            List<SalesInvoices> list = new List<SalesInvoices>();
//            string query = @"
//                SELECT InvoiceID, MaHoaDon, CustomerID, UserID, 
//                       NgayBan, TongTien, TrangThai 
//                FROM SalesInvoices 
//                ORDER BY NgayBan DESC";

//            DataTable data = DataProvider.Instance.ExecuteQuery(query);
//            foreach (DataRow row in data.Rows)
//            {
//                list.Add(new SalesInvoices(row));
//            }
//            return list;
//        }

//        /// <summary>
//        /// Lấy hóa đơn theo khoảng thời gian
//        /// </summary>
//        public List<SalesInvoices> GetInvoicesByDateRange(DateTime startDate, DateTime endDate)
//        {
//            List<SalesInvoices> list = new List<SalesInvoices>();
//            string query = @"
//                SELECT InvoiceID, MaHoaDon, CustomerID, UserID, 
//                       NgayBan, TongTien, TrangThai 
//                FROM SalesInvoices 
//                WHERE CAST(NgayBan AS DATE) BETWEEN @startDate AND @endDate
//                ORDER BY NgayBan DESC";

//            object[] parameters = new object[] { startDate, endDate };
//            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

//            foreach (DataRow row in data.Rows)
//            {
//                list.Add(new SalesInvoices(row));
//            }
//            return list;
//        }

//        /// <summary>
//        /// Lấy hóa đơn theo ID
//        /// </summary>
//        public SalesInvoices GetInvoiceByID(int invoiceID)
//        {
//            string query = @"
//                SELECT InvoiceID, MaHoaDon, CustomerID, UserID, 
//                       NgayBan, TongTien, TrangThai 
//                FROM SalesInvoices 
//                WHERE InvoiceID = @invoiceID";

//            object[] parameters = new object[] { invoiceID };
//            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

//            if (data.Rows.Count > 0)
//                return new SalesInvoices(data.Rows[0]);
//            return null;
//        }

//        /// <summary>
//        /// Lấy chi tiết hóa đơn
//        /// </summary>
//        public List<SalesInvoiceDetails> GetInvoiceDetails(int invoiceID)
//        {
//            List<SalesInvoiceDetails> list = new List<SalesInvoiceDetails>();
//            string query = @"
//                SELECT InvoiceDetailID, InvoiceID, ProductID, UnitID, 
//                       SoLuong, DonGiaBan, ThanhTien 
//                FROM SalesInvoiceDetails 
//                WHERE InvoiceID = @invoiceID";

//            object[] parameters = new object[] { invoiceID };
//            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

//            foreach (DataRow row in data.Rows)
//            {
//                list.Add(new SalesInvoiceDetails(row));
//            }
//            return list;
//        }

//        #endregion

//        #region Insert Methods

//        /// <summary>
//        /// Tạo hóa đơn mới
//        /// Return: (resultCode, newInvoiceID)
//        /// 0: Success, -1: Customer not found, -99: Error
//        /// </summary>
//        public (int, int) InsertSalesInvoice(int customerID, int userID, DateTime ngayBan, string trangThai = "Đã thanh toán")
//        {
//            try
//            {
//                string query = @"
//                    INSERT INTO SalesInvoices (CustomerID, UserID, NgayBan, TrangThai)
//                    VALUES (@customerID, @userID, @ngayBan, @trangThai);
//                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

//                object[] parameters = new object[] { customerID, userID, ngayBan, trangThai };

//                object result = DataProvider.Instance.ExecuteScalar(query,
//                    new Dictionary<string, object>
//                    {
//                        { "@customerID", customerID },
//                        { "@userID", userID },
//                        { "@ngayBan", ngayBan },
//                        { "@trangThai", trangThai }
//                    });

//                if (result != null && int.TryParse(result.ToString(), out int newID))
//                {
//                    return (0, newID);
//                }
//                return (-99, 0);
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"InsertSalesInvoice error: {ex}");
//                return (-99, 0);
//            }
//        }

//        /// <summary>
//        /// Thêm chi tiết hóa đơn
//        /// </summary>
//        public int InsertInvoiceDetail(int invoiceID, int productID, int unitID,
//            double soLuong, decimal donGiaBan)
//        {
//            try
//            {
//                string query = @"
//                    INSERT INTO SalesInvoiceDetails 
//                    (InvoiceID, ProductID, UnitID, SoLuong, DonGiaBan, ThanhTien)
//                    VALUES (@invoiceID, @productID, @unitID, @soLuong, @donGiaBan, 
//                            @soLuong * @donGiaBan)";

//                object[] parameters = new object[]
//                {
//                    invoiceID, productID, unitID, soLuong, donGiaBan
//                };

//                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
//                return result > 0 ? 0 : -99;
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"InsertInvoiceDetail error: {ex}");
//                return -99;
//            }
//        }

//        #endregion

//        #region Update Methods

//        /// <summary>
//        /// Cập nhật tổng tiền hóa đơn
//        /// </summary>
//        public int UpdateInvoiceTotalAmount(int invoiceID)
//        {
//            try
//            {
//                string query = @"
//                    UPDATE SalesInvoices
//                    SET TongTien = (
//                        SELECT ISNULL(SUM(ThanhTien), 0)
//                        FROM SalesInvoiceDetails
//                        WHERE InvoiceID = @invoiceID
//                    )
//                    WHERE InvoiceID = @invoiceID";

//                object[] parameters = new object[] { invoiceID };
//                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
//                return result > 0 ? 0 : -99;
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"UpdateInvoiceTotalAmount error: {ex}");
//                return -99;
//            }
//        }

//        /// <summary>
//        /// Cập nhật trạng thái hóa đơn
//        /// </summary>
//        public int UpdateInvoiceStatus(int invoiceID, string trangThai)
//        {
//            try
//            {
//                string query = @"
//                    UPDATE SalesInvoices
//                    SET TrangThai = @trangThai
//                    WHERE InvoiceID = @invoiceID";

//                object[] parameters = new object[] { trangThai, invoiceID };
//                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
//                return result > 0 ? 0 : -1;
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"UpdateInvoiceStatus error: {ex}");
//                return -99;
//            }
//        }

//        #endregion

//        #region Delete Methods

//        /// <summary>
//        /// Xóa hóa đơn (chỉ cho phép trong ngày)
//        /// </summary>
//        public int DeleteInvoice(int invoiceID)
//        {
//            try
//            {
//                // Kiểm tra ngày tạo
//                string checkQuery = @"
//                    SELECT CAST(NgayBan AS DATE) 
//                    FROM SalesInvoices 
//                    WHERE InvoiceID = @invoiceID";

//                object[] checkParams = new object[] { invoiceID };
//                DataTable dt = DataProvider.Instance.ExecuteQuery(checkQuery, checkParams);

//                if (dt.Rows.Count == 0)
//                    return -1; // Không tìm thấy

//                DateTime ngayBan = Convert.ToDateTime(dt.Rows[0][0]);
//                if (ngayBan.Date != DateTime.Now.Date)
//                    return -2; // Không cho phép xóa

//                // Xóa chi tiết trước
//                string deleteDetailsQuery = @"
//                    DELETE FROM SalesInvoiceDetails 
//                    WHERE InvoiceID = @invoiceID";
//                DataProvider.Instance.ExecuteNonQuery(deleteDetailsQuery, checkParams);

//                // Xóa hóa đơn
//                string deleteQuery = @"
//                    DELETE FROM SalesInvoices 
//                    WHERE InvoiceID = @invoiceID";
//                int result = DataProvider.Instance.ExecuteNonQuery(deleteQuery, checkParams);

//                return result > 0 ? 0 : -99;
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"DeleteInvoice error: {ex}");
//                return -99;
//            }
//        }

//        #endregion

//        #region Helper Methods

//        /// <summary>
//        /// Tự động trừ kho sau khi thanh toán
//        /// </summary>
//        public int ProcessInventoryDeduction(int invoiceID)
//        {
//            try
//            {
//                string query = @"
//                    UPDATE PI
//                    SET PI.SoLuongTon = PI.SoLuongTon - (
//                        SID.SoLuong * PUC.GiaTriQuyDoi
//                    )
//                    FROM ProductInventory PI
//                    INNER JOIN SalesInvoiceDetails SID ON PI.ProductID = SID.ProductID
//                    INNER JOIN ProductUnitConversions PUC 
//                        ON SID.ProductID = PUC.ProductID AND SID.UnitID = PUC.UnitID
//                    WHERE SID.InvoiceID = @invoiceID";

//                object[] parameters = new object[] { invoiceID };
//                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
//                return result > 0 ? 0 : -99;
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"ProcessInventoryDeduction error: {ex}");
//                return -99;
//            }
//        }

//        /// <summary>
//        /// Kiểm tra tồn kho trước khi bán
//        /// </summary>
//        public bool CheckInventoryAvailability(int productID, int unitID, double soLuong)
//        {
//            try
//            {
//                string query = @"
//                    SELECT 
//                        CASE 
//                            WHEN PI.SoLuongTon >= (@soLuong * PUC.GiaTriQuyDoi) 
//                            THEN 1 
//                            ELSE 0 
//                        END AS IsAvailable
//                    FROM ProductInventory PI
//                    INNER JOIN ProductUnitConversions PUC 
//                        ON PI.ProductID = PUC.ProductID
//                    WHERE PI.ProductID = @productID 
//                        AND PUC.UnitID = @unitID";

//                object[] parameters = new object[] { soLuong, productID, unitID };
//                DataTable dt = DataProvider.Instance.ExecuteQuery(query, parameters);

//                if (dt.Rows.Count > 0)
//                {
//                    return Convert.ToInt32(dt.Rows[0]["IsAvailable"]) == 1;
//                }
//                return false;
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"CheckInventoryAvailability error: {ex}");
//                return false;
//            }
//        }

//        #endregion
//    }
//}