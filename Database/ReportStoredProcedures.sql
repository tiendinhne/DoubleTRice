USE QuanLyBanGao;
GO

-- ===================================================================
-- 1. BÁO CÁO DOANH THU & LỢI NHUẬN THEO NGÀY
-- ===================================================================
IF OBJECT_ID('sp_GetRevenueReport', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueReport;
GO

--=======
/*

CREATE PROCEDURE sp_GetRevenueReport
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Doanh thu từ SalesInvoices
    ;WITH RevenueData AS (
        SELECT 
            CAST(si.NgayBan AS DATE) AS Ngay,
            COUNT(DISTINCT si.InvoiceID) AS SoHoaDon,
            SUM(si.TongTien) AS TongDoanhThu,
            -- Tính giá vốn từ chi tiết hóa đơn
            SUM(
                sid.SoLuong * puc.GiaTriQuyDoi * 
                (SELECT TOP 1 grd.DonGiaNhap 
                 FROM GoodsReceiptDetails grd
                 INNER JOIN GoodsReceipts gr ON grd.ReceiptID = gr.ReceiptID
                 WHERE grd.ProductID = sid.ProductID 
                   AND grd.UnitID = sid.UnitID
                   AND gr.NgayNhap <= si.NgayBan
                 ORDER BY gr.NgayNhap DESC)
            ) AS TongGiaVon
        FROM SalesInvoices si
        INNER JOIN SalesInvoiceDetails sid ON si.InvoiceID = sid.InvoiceID
        INNER JOIN ProductUnitConversions puc 
            ON sid.ProductID = puc.ProductID AND sid.UnitID = puc.UnitID
        WHERE CAST(si.NgayBan AS DATE) BETWEEN @StartDate AND @EndDate
        GROUP BY CAST(si.NgayBan AS DATE)
    )
    SELECT 
        Ngay,
        SoHoaDon,
        TongDoanhThu,
        ISNULL(TongGiaVon, 0) AS TongGiaVon,
        (TongDoanhThu - ISNULL(TongGiaVon, 0)) AS LoiNhuan
    FROM RevenueData
    ORDER BY Ngay;
END
GO
--=====
*/

CREATE PROCEDURE sp_GetRevenueReport
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;

    ;WITH RevenueData AS (
        SELECT
            CAST(si.NgayBan AS DATE) AS Ngay,
            COUNT(DISTINCT si.InvoiceID) AS SoHoaDon,
            SUM(si.TongTien) AS TongDoanhThu,
            SUM(sid.SoLuong * puc.GiaTriQuyDoi * ISNULL(grd_latest.DonGiaNhap, 0)) AS TongGiaVon
        FROM SalesInvoices si
        INNER JOIN SalesInvoiceDetails sid 
            ON si.InvoiceID = sid.InvoiceID
        INNER JOIN ProductUnitConversions puc
            ON sid.ProductID = puc.ProductID 
           AND sid.UnitID = puc.UnitID

        -- Lấy giá nhập gần nhất bằng OUTER APPLY (tốt nhất cho trường hợp TOP 1)
        OUTER APPLY (
            SELECT TOP 1 grd.DonGiaNhap
            FROM GoodsReceiptDetails grd
            INNER JOIN GoodsReceipts gr ON grd.ReceiptID = gr.ReceiptID
            WHERE grd.ProductID = sid.ProductID
              AND grd.UnitID = sid.UnitID
              AND gr.NgayNhap <= si.NgayBan
            ORDER BY gr.NgayNhap DESC
        ) AS grd_latest

        WHERE CAST(si.NgayBan AS DATE) BETWEEN @StartDate AND @EndDate
        GROUP BY CAST(si.NgayBan AS DATE)
    )
    SELECT 
        Ngay,
        SoHoaDon,
        TongDoanhThu,
        TongGiaVon,
        (TongDoanhThu - TongGiaVon) AS LoiNhuan
    FROM RevenueData
    ORDER BY Ngay;
END


-- ===================================================================
-- 2. BÁO CÁO TỒN KHO & CẢNH BÁO
-- ===================================================================
IF OBJECT_ID('sp_GetInventoryReport', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetInventoryReport;
GO

CREATE PROCEDURE sp_GetInventoryReport
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.ProductID,
        p.TenSanPham,
        u.TenDVT AS DonViTinh,
        ISNULL(pi.SoLuongTon, 0) AS SoLuongTon,
        p.TonKhoToiThieu,
        -- Giá trị tồn kho = Tồn x Giá nhập gần nhất
        ISNULL(pi.SoLuongTon, 0) * 
        ISNULL((
            SELECT TOP 1 grd.DonGiaNhap / puc.GiaTriQuyDoi
            FROM GoodsReceiptDetails grd
            INNER JOIN GoodsReceipts gr ON grd.ReceiptID = gr.ReceiptID
            INNER JOIN ProductUnitConversions puc 
                ON grd.ProductID = puc.ProductID AND grd.UnitID = puc.UnitID
            WHERE grd.ProductID = p.ProductID AND puc.UnitID = p.BaseUnitID
            ORDER BY gr.NgayNhap DESC
        ), 0) AS GiaTriTonKho,
        CASE 
            WHEN ISNULL(pi.SoLuongTon, 0) <= 0 THEN N'Hết hàng'
            WHEN ISNULL(pi.SoLuongTon, 0) <= p.TonKhoToiThieu THEN N'Sắp hết'
            ELSE N'Bình thường'
        END AS TrangThai
    FROM Products p
    LEFT JOIN ProductInventory pi ON p.ProductID = pi.ProductID
    INNER JOIN Units u ON p.BaseUnitID = u.UnitID
    ORDER BY 
        CASE 
            WHEN ISNULL(pi.SoLuongTon, 0) <= 0 THEN 1
            WHEN ISNULL(pi.SoLuongTon, 0) <= p.TonKhoToiThieu THEN 2
            ELSE 3
        END,
        p.TenSanPham;
END
GO

-- ===================================================================
-- 3. BÁO CÁO CÔNG NỢ KHÁCH HÀNG
-- ===================================================================
IF OBJECT_ID('sp_GetCustomerDebtReport', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetCustomerDebtReport;
GO

CREATE PROCEDURE sp_GetCustomerDebtReport
AS
BEGIN
    SET NOCOUNT ON;
    
    ;WITH CustomerDebts AS (
        SELECT 
            c.CustomerID,
            c.TenKhachHang,
            c.SoDienThoai,
            ISNULL(SUM(si.TongTien), 0) AS TongMuaHang,
            ISNULL(SUM(cp.SoTien), 0) AS TongDaTra,
            COUNT(DISTINCT CASE 
                WHEN (si.TongTien - ISNULL(paid.TongDaTra, 0)) > 0 
                THEN si.InvoiceID 
            END) AS SoHoaDonChuaTra
        FROM Customers c
        LEFT JOIN SalesInvoices si ON c.CustomerID = si.CustomerID
        LEFT JOIN CustomerPayments cp ON si.InvoiceID = cp.InvoiceID
        LEFT JOIN (
            SELECT InvoiceID, SUM(SoTien) AS TongDaTra
            FROM CustomerPayments
            GROUP BY InvoiceID
        ) paid ON si.InvoiceID = paid.InvoiceID
        WHERE c.TenKhachHang != N'Khách vãng lai'
        GROUP BY c.CustomerID, c.TenKhachHang, c.SoDienThoai
    )
    SELECT 
        CustomerID,
        TenKhachHang,
        SoDienThoai,
        TongMuaHang,
        TongDaTra,
        (TongMuaHang - TongDaTra) AS CongNo,
        SoHoaDonChuaTra
    FROM CustomerDebts
    WHERE (TongMuaHang - TongDaTra) > 0
    ORDER BY (TongMuaHang - TongDaTra) DESC;
END
GO

-- ===================================================================
-- 4. BÁO CÁO CÔNG NỢ NHÀ CUNG CẤP
-- ===================================================================
IF OBJECT_ID('sp_GetSupplierDebtReport', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetSupplierDebtReport;
GO

CREATE PROCEDURE sp_GetSupplierDebtReport
AS
BEGIN
    SET NOCOUNT ON;
    
    ;WITH SupplierDebts AS (
        SELECT 
            s.SupplierID,
            s.TenNhaCungCap,
            s.SoDienThoai,
            ISNULL(SUM(gr.TongTien), 0) AS TongNhapHang,
            ISNULL(SUM(sp.SoTien), 0) AS TongDaTra,
            COUNT(DISTINCT CASE 
                WHEN (gr.TongTien - ISNULL(paid.TongDaTra, 0)) > 0 
                THEN gr.ReceiptID 
            END) AS SoPhieuNhapChuaTra
        FROM Suppliers s
        LEFT JOIN GoodsReceipts gr ON s.SupplierID = gr.SupplierID
        LEFT JOIN SupplierPayments sp ON gr.ReceiptID = sp.ReceiptID
        LEFT JOIN (
            SELECT ReceiptID, SUM(SoTien) AS TongDaTra
            FROM SupplierPayments
            WHERE ReceiptID IS NOT NULL
            GROUP BY ReceiptID
        ) paid ON gr.ReceiptID = paid.ReceiptID
        GROUP BY s.SupplierID, s.TenNhaCungCap, s.SoDienThoai
    )
    SELECT 
        SupplierID,
        TenNhaCungCap,
        SoDienThoai,
        TongNhapHang,
        TongDaTra,
        (TongNhapHang - TongDaTra) AS CongNo,
        SoPhieuNhapChuaTra
    FROM SupplierDebts
    WHERE (TongNhapHang - TongDaTra) > 0
    ORDER BY (TongNhapHang - TongDaTra) DESC;
END
GO

-- ===================================================================
-- 5. DASHBOARD TỔNG QUAN
-- ===================================================================
IF OBJECT_ID('sp_GetDashboardSummary', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetDashboardSummary;
GO

/*
CREATE PROCEDURE sp_GetDashboardSummary
    @Month INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
    DECLARE @EndDate DATE = EOMONTH(@StartDate);
    
    -- Doanh thu tháng
    DECLARE @TongDoanhThu DECIMAL(18,2);
    SELECT @TongDoanhThu = ISNULL(SUM(TongTien), 0)
    FROM SalesInvoices
    WHERE CAST(NgayBan AS DATE) BETWEEN @StartDate AND @EndDate;
    
    -- Lợi nhuận tháng (tính gần đúng 20%)
    DECLARE @TongLoiNhuan DECIMAL(18,2) = @TongDoanhThu * 0.2;
    
    -- Công nợ khách
    DECLARE @CongNoKhach DECIMAL(18,2);
    SELECT @CongNoKhach = ISNULL(SUM(si.TongTien - ISNULL(cp.TongDaTra, 0)), 0)
    FROM SalesInvoices si
    LEFT JOIN (
        SELECT InvoiceID, SUM(SoTien) AS TongDaTra
        FROM CustomerPayments
        GROUP BY InvoiceID
    ) cp ON si.InvoiceID = cp.InvoiceID;
    
    -- Công nợ NCC
    DECLARE @CongNoNCC DECIMAL(18,2);
    SELECT @CongNoNCC = ISNULL(SUM(gr.TongTien - ISNULL(sp.TongDaTra, 0)), 0)
    FROM GoodsReceipts gr
    LEFT JOIN (
        SELECT ReceiptID, SUM(SoTien) AS TongDaTra
        FROM SupplierPayments
        WHERE ReceiptID IS NOT NULL
        GROUP BY ReceiptID
    ) sp ON gr.ReceiptID = sp.ReceiptID;
    
    -- Sản phẩm sắp hết
    DECLARE @SoSPSapHet INT;
    SELECT @SoSPSapHet = COUNT(*)
    FROM Products p
    LEFT JOIN ProductInventory pi ON p.ProductID = pi.ProductID
    WHERE ISNULL(pi.SoLuongTon, 0) <= p.TonKhoToiThieu;
    
    -- Số hóa đơn
    DECLARE @TongSoHD INT;
    SELECT @TongSoHD = COUNT(*)
    FROM SalesInvoices
    WHERE CAST(NgayBan AS DATE) BETWEEN @StartDate AND @EndDate;
    
    -- Trả kết quả
    SELECT 
        @TongDoanhThu AS TongDoanhThuThang,
        @TongLoiNhuan AS TongLoiNhuanThang,
        @CongNoKhach AS TongCongNoKhach,
        @CongNoNCC AS TongCongNoNCC,
        @SoSPSapHet AS SoSanPhamSapHet,
        @TongSoHD AS TongSoHoaDon;
END
GO
*/

--DROP PROCEDURE sp_GetDashboardSummary;
--GO


CREATE PROCEDURE sp_GetDashboardSummary
    @Month INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StartDate DATE = DATEFROMPARTS(@Year, @Month, 1);
    DECLARE @EndDate DATE = EOMONTH(@StartDate);
    
    -- 1. TÍNH TỔNG DOANH THU
    DECLARE @TongDoanhThu DECIMAL(18,2);
    SELECT @TongDoanhThu = ISNULL(SUM(TongTien), 0)
    FROM SalesInvoices
    WHERE CAST(NgayBan AS DATE) BETWEEN @StartDate AND @EndDate;
    
    -- 2. TÍNH TỔNG GIÁ VỐN (Logic giống báo cáo doanh thu)
    DECLARE @TongGiaVon DECIMAL(18,2);
    
    SELECT @TongGiaVon = ISNULL(SUM(
        sid.SoLuong * puc.GiaTriQuyDoi * ISNULL(grd_latest.DonGiaNhap, 0)
    ), 0)
    FROM SalesInvoices si
    INNER JOIN SalesInvoiceDetails sid ON si.InvoiceID = sid.InvoiceID
    INNER JOIN ProductUnitConversions puc ON sid.ProductID = puc.ProductID AND sid.UnitID = puc.UnitID
    -- Tìm giá nhập gần nhất
    OUTER APPLY (
        SELECT TOP 1 grd.DonGiaNhap
        FROM GoodsReceiptDetails grd
        INNER JOIN GoodsReceipts gr ON grd.ReceiptID = gr.ReceiptID
        WHERE grd.ProductID = sid.ProductID 
          -- Giả sử quy về đơn vị cơ sở để lấy giá, hoặc khớp UnitID nếu logic giá theo Unit
          AND gr.NgayNhap <= si.NgayBan
        ORDER BY gr.NgayNhap DESC
    ) AS grd_latest
    WHERE CAST(si.NgayBan AS DATE) BETWEEN @StartDate AND @EndDate;

    -- 3. TÍNH LỢI NHUẬN THỰC TẾ
    DECLARE @TongLoiNhuan DECIMAL(18,2) = @TongDoanhThu - ISNULL(@TongGiaVon, 0);
    
    -- 4. CÔNG NỢ KHÁCH (Logic cũ của bạn ổn)
    DECLARE @CongNoKhach DECIMAL(18,2);
    SELECT @CongNoKhach = ISNULL(SUM(si.TongTien - ISNULL(cp.TongDaTra, 0)), 0)
    FROM SalesInvoices si
    LEFT JOIN (
        SELECT InvoiceID, SUM(SoTien) AS TongDaTra
        FROM CustomerPayments
        GROUP BY InvoiceID
    ) cp ON si.InvoiceID = cp.InvoiceID;
    
    -- 5. CÔNG NỢ NCC (Logic cũ của bạn ổn)
    DECLARE @CongNoNCC DECIMAL(18,2);
    SELECT @CongNoNCC = ISNULL(SUM(gr.TongTien - ISNULL(sp.TongDaTra, 0)), 0)
    FROM GoodsReceipts gr
    LEFT JOIN (
        SELECT ReceiptID, SUM(SoTien) AS TongDaTra
        FROM SupplierPayments
        WHERE ReceiptID IS NOT NULL
        GROUP BY ReceiptID
    ) sp ON gr.ReceiptID = sp.ReceiptID;
    
    -- 6. SẢN PHẨM SẮP HẾT
    DECLARE @SoSPSapHet INT;
    SELECT @SoSPSapHet = COUNT(*)
    FROM Products p
    LEFT JOIN ProductInventory pi ON p.ProductID = pi.ProductID
    WHERE ISNULL(pi.SoLuongTon, 0) <= p.TonKhoToiThieu;
    
    -- 7. SỐ HÓA ĐƠN
    DECLARE @TongSoHD INT;
    SELECT @TongSoHD = COUNT(*)
    FROM SalesInvoices
    WHERE CAST(NgayBan AS DATE) BETWEEN @StartDate AND @EndDate;
    
    -- TRẢ KẾT QUẢ
    SELECT 
        @TongDoanhThu AS TongDoanhThuThang,
        @TongLoiNhuan AS TongLoiNhuanThang,
        @CongNoKhach AS TongCongNoKhach,
        @CongNoNCC AS TongCongNoNCC,
        @SoSPSapHet AS SoSanPhamSapHet,
        @TongSoHD AS TongSoHoaDon;
END
GO