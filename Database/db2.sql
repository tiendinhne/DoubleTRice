-- Tạo database nếu chưa tồn tại
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'QuanLyBanGao')
BEGIN
    CREATE DATABASE QuanLyBanGao;
END
GO

USE QuanLyBanGao;
GO


-- them du liẹu cho san phẩm
INSERT INTO Products (TenSanPham, BaseUnitID, TonKhoToiThieu)
VALUES 
(N'Gạo ST25', 1, 50),
(N'Gạo Lài Sữa', 1, 30),
(N'Gạo Nàng Hương Chợ Đào', 1, 20),
(N'Gạo Tám Thơm Hải Hậu', 1, 40),
(N'Gạo Bắc Hương', 1, 25),
(N'Gạo Nhật Sushi', 1, 15),
(N'Gạo Thơm Jasmine', 1, 35),
(N'Gạo Nếp Cái Hoa Vàng', 1, 20);
select * from Products;


-- Chèn đơn vị tính
INSERT INTO Units (TenDVT) VALUES 
(N'kg'), 
(N'Bao 10kg'), 
(N'Bao 25kg'),
(N'Bao 50kg');

--select * from Units
--delete from Units

-- Chèn khách vãng lai
INSERT INTO Customers (TenKhachHang, SoDienThoai) VALUES
(N'Khách vãng lai', '000000000');

-- ===================================================================
-- 5. INSERT DỮ LIỆU MẪU (USER TEST)
-- Password: 123456 -> Hash: 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
-- ===================================================================

-- Xóa dữ liệu cũ nếu có
--DELETE FROM Users;
GO

-- Insert users cơ bản
INSERT INTO Users (HoTen, TenDangNhap, MatKhauHash, VaiTro, IsLocked, FailedLoginAttempts)
VALUES 
(N'Administrator', 'admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Admin', 0, 0),
(N'Nguyễn Văn Thu Ngân', 'thungan', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Thu Ngân', 0, 0),
(N'Trần Thị Thủ Kho', 'thukho', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Thủ Kho', 0, 0),
(N'Lê Văn Kế Toán', 'ketoan', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Kế Toán', 0, 0),
(N'Test Locked User', 'locked', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Admin', 1, 5);
GO



-------- 21-11 23:58:xx co them 1 user Tien Dinh - tiendinh -123456

-------- 24-12 thêm Gạo Tiên Đinh ID20
--------- chỉnh sửa ID19 kg -> bao 25kg
-- xóa ID18 

---- 26-11 by tien dinh : thêm khách hàng Tiên Đinh - 1234567890- Long An 
-- Dữ liệu INSERT mẫu cho bảng Suppliers
SET IDENTITY_INSERT Suppliers ON; -- Cho phép chèn giá trị vào cột IDENTITY (nếu cần thiết)
GO

INSERT INTO Suppliers (SupplierID, TenNhaCungCap, SoDienThoai, DiaChi) VALUES
(1, N'Công ty Gạo Vàng', '0901112223', N'45 Lê Lợi, TP.HCM'),
(2, N'Hợp tác xã Lúa Mới', '0915444555', N'Thôn 3, Xã Tân Phong, Long An'),
(3, N'Doanh nghiệp Tư nhân Tấn Phát', '0987654321', N'203/A1 Quốc lộ 1, Tiền Giang'),
(4, N'Công ty CP Xuất nhập khẩu An Giang', '02963888999', N'123 Trần Hưng Đạo, Châu Đốc, An Giang'),
(5, N'Nhà cung cấp Sĩ Lẻ Minh Khang', '0909000111', N'Kho B, Chợ Đầu Mối Bình Điền');

GO
SET IDENTITY_INSERT Suppliers OFF;
GO

-- Kiểm tra lại dữ liệu
--SELECT * FROM Suppliers;

-- Dữ liệu INSERT mẫu cho bảng Customers
INSERT INTO Customers ( TenKhachHang, SoDienThoai, DiaChi) VALUES
(N'Nguyễn Văn A', '0912345678', N'789 Trường Chinh, Quận 10, TP.HCM'),
(N'Lê Thị B', '0908765432', N'12/3 Khu Phố 4, Thủ Đức, TP.HCM'),
(N'Quán ăn Tiên', '0977112233', N'22 Bến Vân Đồn, Quận 4, TP.HCM'),
(N'Anh Vũ', '0123456789', N'Tổ 15, Phường 2, Đà Lạt');

-- Kiểm tra lại dữ liệu
--SELECT * FROM Customers;

--- 30-11 
-- Thêm giá bán cho các sản phẩm
-- Giá theo kg
INSERT INTO PriceList (ProductID, UnitID, GiaBan, NgayApDung) VALUES
(1, 1, 25000, GETDATE()),  -- ST25 - kg - 25,000đ
(2, 1, 22000, GETDATE()),  -- Lài Sữa - kg - 22,000đ
(3, 1, 20000, GETDATE())  -- Nàng Hương - kg - 20,000đ
-- Kiểm tra
SELECT p.TenSanPham, u.TenDVT, pl.GiaBan
FROM PriceList pl
INNER JOIN Products p ON pl.ProductID = p.ProductID
INNER JOIN Units u ON pl.UnitID = u.UnitID
ORDER BY p.TenSanPham, u.TenDVT;


--BACKUP DATABASE QuanLyBanGao 
--TO DISK = 'D:\QuanLyBanGao_Backup.bak'

/* ===================================================================
   SCRIPT DỌN DẸP TOÀN DIỆN - XỬ LÝ TRÙNG LẶP NGHIÊM TRỌNG
   Ngày: 01/12/2025
   
   Vấn đề phát hiện:
   - Units trùng lặp: 20 bản ghi thay vì 4
   - Sản phẩm trùng tên: 8 loại gạo bị trùng 2-3 lần
   - Khách vãng lai trùng: 3 bản ghi
   
   ⚠️ QUAN TRỌNG: BACKUP DATABASE TRƯỚC KHI CHẠY!
   =================================================================== */

USE QuanLyBanGao;
GO

SET NOCOUNT ON;
GO

PRINT '========================================';
PRINT 'DỌN DẸP TOÀN DIỆN - PHIÊN BẢN CUỐI';
PRINT '========================================';
PRINT '';

-- ===================================================================
-- BƯỚC 1: BACKUP
-- ===================================================================
PRINT '>>> Bước 1: Tạo backup...';

IF OBJECT_ID('dbo.Backup_Units_20251201', 'U') IS NOT NULL 
    DROP TABLE dbo.Backup_Units_20251201;
SELECT * INTO dbo.Backup_Units_20251201 FROM Units;
PRINT 'Backup Units: ' + CAST(@@ROWCOUNT AS VARCHAR);

IF OBJECT_ID('dbo.Backup_Products_20251201', 'U') IS NOT NULL 
    DROP TABLE dbo.Backup_Products_20251201;
SELECT * INTO dbo.Backup_Products_20251201 FROM Products;
PRINT 'Backup Products: ' + CAST(@@ROWCOUNT AS VARCHAR);

IF OBJECT_ID('dbo.Backup_Customers_20251201', 'U') IS NOT NULL 
    DROP TABLE dbo.Backup_Customers_20251201;
SELECT * INTO dbo.Backup_Customers_20251201 FROM Customers;
PRINT 'Backup Customers: ' + CAST(@@ROWCOUNT AS VARCHAR);

PRINT '✓ Backup hoàn tất (bảng backup lưu trong database)';
PRINT '';
GO

-- ===================================================================
-- BƯỚC 2: PHÂN TÍCH
-- ===================================================================
PRINT '>>> Bước 2: Phân tích dữ liệu...';
PRINT '';

PRINT '--- UNITS TRÙNG LẶP ---';
SELECT TenDVT, COUNT(*) AS SoLuong, 
       MIN(UnitID) AS ID_GiuLai,
       STRING_AGG(CAST(UnitID AS VARCHAR), ', ') AS [Danh sách ID]
FROM Units
GROUP BY TenDVT
ORDER BY TenDVT;

PRINT '';
PRINT '--- SẢN PHẨM TRÙNG TÊN ---';
SELECT TenSanPham, COUNT(*) AS SoLuong,
       MIN(ProductID) AS ID_GiuLai
FROM Products
GROUP BY TenSanPham
HAVING COUNT(*) > 1;

PRINT '';
PRINT '--- KHÁCH VÃNG LAI ---';
SELECT CustomerID, TenKhachHang 
FROM Customers 
WHERE TenKhachHang = N'Khách vãng lai';

PRINT '';
GO

-- ===================================================================
-- BƯỚC 3: DỌN DẸP
-- ===================================================================
BEGIN TRY
    BEGIN TRANSACTION CleanupFinal;
    
    PRINT '>>> Bước 3: Bắt đầu dọn dẹp...';
    PRINT '';
    
    -- =================================================================
    -- 3.1: TẠO BẢNG ÁNH XẠ CHO UNITS
    -- =================================================================
    PRINT '  [3.1] Xử lý Units...';
    
    -- Tạo bảng ánh xạ: UnitID cũ -> UnitID mới (chuẩn)
    IF OBJECT_ID('tempdb..#UnitMapping') IS NOT NULL DROP TABLE #UnitMapping;
    
    CREATE TABLE #UnitMapping (
        OldUnitID INT,
        NewUnitID INT,
        TenDVT NVARCHAR(50)
    );
    
    -- Ánh xạ chuẩn (giữ lại ID nhỏ nhất của mỗi loại)
    INSERT INTO #UnitMapping (OldUnitID, NewUnitID, TenDVT)
    SELECT 
        u.UnitID AS OldUnitID,
        (SELECT MIN(UnitID) FROM Units WHERE TenDVT = u.TenDVT) AS NewUnitID,
        u.TenDVT
    FROM Units u
    WHERE u.UnitID != (SELECT MIN(UnitID) FROM Units WHERE TenDVT = u.TenDVT);
    
    DECLARE @UnitsToMap INT = @@ROWCOUNT;
    PRINT '  Số Units cần ánh xạ lại: ' + CAST(@UnitsToMap AS VARCHAR);
    
    -- Hiển thị chi tiết ánh xạ
    IF @UnitsToMap > 0
    BEGIN
        SELECT 'Ánh xạ Units' AS Info, * FROM #UnitMapping ORDER BY TenDVT, OldUnitID;
    END
    
    -- =================================================================
    -- 3.2: CẬP NHẬT BaseUnitID CỦA PRODUCTS
    -- =================================================================
    PRINT '';
    PRINT '  [3.2] Cập nhật BaseUnitID của Products...';
    
    -- Cập nhật Products.BaseUnitID về UnitID chuẩn của 'kg'
    DECLARE @StandardKgID INT;
    SELECT @StandardKgID = MIN(UnitID) FROM Units WHERE TenDVT = N'kg';
    
    UPDATE p
    SET p.BaseUnitID = @StandardKgID
    FROM Products p
    INNER JOIN #UnitMapping m ON p.BaseUnitID = m.OldUnitID
    WHERE m.TenDVT = N'kg';
    
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' Products.BaseUnitID';
    
    -- Đảm bảo tất cả Products đều dùng BaseUnitID chuẩn
    UPDATE Products
    SET BaseUnitID = @StandardKgID
    WHERE BaseUnitID != @StandardKgID;
    
    PRINT '  Đã chuẩn hóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' BaseUnitID về kg';
    
    -- =================================================================
    -- 3.3: CẬP NHẬT CÁC BẢNG LIÊN QUAN ĐẾN UNITS
    -- =================================================================
    PRINT '';
    PRINT '  [3.3] Cập nhật các bảng liên quan...';
    
    -- ProductUnitConversions
    UPDATE puc
    SET puc.UnitID = m.NewUnitID
    FROM ProductUnitConversions puc
    INNER JOIN #UnitMapping m ON puc.UnitID = m.OldUnitID;
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' ProductUnitConversions';
    
    -- Xóa trùng lặp trong ProductUnitConversions (sau khi ánh xạ có thể bị trùng)
    WITH DupConversions AS (
        SELECT ConversionID,
               ROW_NUMBER() OVER (PARTITION BY ProductID, UnitID ORDER BY ConversionID) AS RowNum
        FROM ProductUnitConversions
    )
    DELETE FROM DupConversions WHERE RowNum > 1;
    PRINT '  Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' conversion trùng';
    
    -- PriceList
    UPDATE pl
    SET pl.UnitID = m.NewUnitID
    FROM PriceList pl
    INNER JOIN #UnitMapping m ON pl.UnitID = m.OldUnitID;
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' PriceList';
    
    -- Xóa trùng lặp trong PriceList
    WITH DupPrices AS (
        SELECT PriceID,
               ROW_NUMBER() OVER (PARTITION BY ProductID, UnitID ORDER BY NgayApDung DESC) AS RowNum
        FROM PriceList
    )
    DELETE FROM DupPrices WHERE RowNum > 1;
    PRINT '  Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' giá trùng';
    
    -- GoodsReceiptDetails
    UPDATE grd
    SET grd.UnitID = m.NewUnitID
    FROM GoodsReceiptDetails grd
    INNER JOIN #UnitMapping m ON grd.UnitID = m.OldUnitID;
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' GoodsReceiptDetails';
    
    -- SalesInvoiceDetails
    UPDATE sid
    SET sid.UnitID = m.NewUnitID
    FROM SalesInvoiceDetails sid
    INNER JOIN #UnitMapping m ON sid.UnitID = m.OldUnitID;
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' SalesInvoiceDetails';
    
    -- =================================================================
    -- 3.4: XÓA UNITS TRÙNG LẶP
    -- =================================================================
    PRINT '';
    PRINT '  [3.4] Xóa Units trùng lặp...';
    
    DELETE FROM Units
    WHERE UnitID IN (SELECT OldUnitID FROM #UnitMapping);
    
    PRINT '  ✓ Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' Units trùng';
    
    -- Xóa các đơn vị không cần thiết (Ta, Tấn)
    DELETE FROM Units WHERE TenDVT IN (N'Ta', N'Tấn');
    IF @@ROWCOUNT > 0
        PRINT '  ✓ Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' đơn vị không cần (Ta, Tấn)';
    
    -- =================================================================
    -- 3.5: GỘP KHÁCH HÀNG TRÙNG
    -- =================================================================
    PRINT '';
    PRINT '  [3.5] Gộp khách hàng "Khách vãng lai"...';
    
    DECLARE @KeepCustomerID INT;
    SELECT @KeepCustomerID = MIN(CustomerID) 
    FROM Customers 
    WHERE TenKhachHang = N'Khách vãng lai';
    
    PRINT '  CustomerID giữ lại: ' + CAST(@KeepCustomerID AS VARCHAR);
    
    -- Cập nhật SalesInvoices
    UPDATE SalesInvoices
    SET CustomerID = @KeepCustomerID
    WHERE CustomerID IN (
        SELECT CustomerID 
        FROM Customers 
        WHERE TenKhachHang = N'Khách vãng lai' 
        AND CustomerID <> @KeepCustomerID
    );
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' hóa đơn';
    
    -- Cập nhật CustomerPayments
    UPDATE CustomerPayments
    SET CustomerID = @KeepCustomerID
    WHERE CustomerID IN (
        SELECT CustomerID 
        FROM Customers 
        WHERE TenKhachHang = N'Khách vãng lai' 
        AND CustomerID <> @KeepCustomerID
    );
    PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' thanh toán';
    
    -- Xóa khách trùng
    DELETE FROM Customers
    WHERE TenKhachHang = N'Khách vãng lai' 
    AND CustomerID <> @KeepCustomerID;
    
    PRINT '  ✓ Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' khách hàng trùng';
    
    -- =================================================================
    -- 3.6: GỘP SẢN PHẨM TRÙNG TÊN
    -- =================================================================
    PRINT '';
    PRINT '  [3.6] Gộp sản phẩm trùng tên...';
    
    -- Tạo bảng ánh xạ sản phẩm
    IF OBJECT_ID('tempdb..#ProductMapping') IS NOT NULL DROP TABLE #ProductMapping;
    
    WITH RankedProducts AS (
        SELECT 
            ProductID,
            TenSanPham,
            ROW_NUMBER() OVER (PARTITION BY TenSanPham ORDER BY ProductID) AS RowNum
        FROM Products
    )
    SELECT 
        p.ProductID AS OldProductID,
        r.ProductID AS NewProductID,
        p.TenSanPham
    INTO #ProductMapping
    FROM Products p
    INNER JOIN RankedProducts r ON p.TenSanPham = r.TenSanPham AND r.RowNum = 1
    WHERE p.ProductID <> r.ProductID;
    
    DECLARE @ProductsToMerge INT = @@ROWCOUNT;
    PRINT '  Số sản phẩm cần gộp: ' + CAST(@ProductsToMerge AS VARCHAR);
    
    IF @ProductsToMerge > 0
    BEGIN
        -- Hiển thị chi tiết
        SELECT 'Gộp sản phẩm' AS Info, 
               OldProductID AS [ID Xóa],
               NewProductID AS [ID Giữ],
               TenSanPham
        FROM #ProductMapping
        ORDER BY TenSanPham;
        
        -- Cập nhật GoodsReceiptDetails
        UPDATE grd
        SET grd.ProductID = m.NewProductID
        FROM GoodsReceiptDetails grd
        INNER JOIN #ProductMapping m ON grd.ProductID = m.OldProductID;
        PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' GoodsReceiptDetails';
        
        -- Cập nhật SalesInvoiceDetails
        UPDATE sid
        SET sid.ProductID = m.NewProductID
        FROM SalesInvoiceDetails sid
        INNER JOIN #ProductMapping m ON sid.ProductID = m.OldProductID;
        PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' SalesInvoiceDetails';
        
        -- Cập nhật StockAdjustments
        UPDATE sa
        SET sa.ProductID = m.NewProductID
        FROM StockAdjustments sa
        INNER JOIN #ProductMapping m ON sa.ProductID = m.OldProductID;
        PRINT '  Đã cập nhật ' + CAST(@@ROWCOUNT AS VARCHAR) + ' StockAdjustments';
        
        -- Gộp tồn kho (cộng dồn)
        UPDATE pi_keep
        SET pi_keep.SoLuongTon = pi_keep.SoLuongTon + ISNULL(pi_old.SoLuongTon, 0)
        FROM ProductInventory pi_keep
        INNER JOIN #ProductMapping m ON pi_keep.ProductID = m.NewProductID
        LEFT JOIN ProductInventory pi_old ON pi_old.ProductID = m.OldProductID;
        PRINT '  Đã gộp ' + CAST(@@ROWCOUNT AS VARCHAR) + ' tồn kho';
        
        -- Xóa các bảng liên quan của sản phẩm cũ
        DELETE puc
        FROM ProductUnitConversions puc
        INNER JOIN #ProductMapping m ON puc.ProductID = m.OldProductID;
        PRINT '  Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' ProductUnitConversions';
        
        DELETE pi
        FROM ProductInventory pi
        INNER JOIN #ProductMapping m ON pi.ProductID = m.OldProductID;
        PRINT '  Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' ProductInventory';
        
        DELETE pl
        FROM PriceList pl
        INNER JOIN #ProductMapping m ON pl.ProductID = m.OldProductID;
        PRINT '  Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' PriceList';
        
        -- Xóa sản phẩm trùng
        DELETE p
        FROM Products p
        INNER JOIN #ProductMapping m ON p.ProductID = m.OldProductID;
        
        PRINT '  ✓ Đã xóa ' + CAST(@@ROWCOUNT AS VARCHAR) + ' sản phẩm trùng';
    END
    ELSE
    BEGIN
        PRINT '  ✓ Không có sản phẩm trùng';
    END
    
    -- =================================================================
    -- COMMIT
    -- =================================================================
    COMMIT TRANSACTION CleanupFinal;
    
    PRINT '';
    PRINT '========================================';
    PRINT '✓✓✓ COMMIT THÀNH CÔNG ✓✓✓';
    PRINT '========================================';
    
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
    BEGIN
        ROLLBACK TRANSACTION CleanupFinal;
        
        PRINT '';
        PRINT '========================================';
        PRINT '✗✗✗ LỖI - ĐÃ ROLLBACK ✗✗✗';
        PRINT '========================================';
        PRINT 'Lỗi: ' + ERROR_MESSAGE();
        PRINT 'Dòng: ' + CAST(ERROR_LINE() AS VARCHAR);
        PRINT '';
        PRINT 'Dữ liệu backup:';
        PRINT '- dbo.Backup_Units_20251201';
        PRINT '- dbo.Backup_Products_20251201';
        PRINT '- dbo.Backup_Customers_20251201';
        PRINT '========================================';
    END
END CATCH;
GO

-- ===================================================================
-- BƯỚC 4: KIỂM TRA KẾT QUẢ
-- ===================================================================
PRINT '';
PRINT '========================================';
PRINT 'KIỂM TRA KẾT QUẢ';
PRINT '========================================';
PRINT '';

DECLARE @FinalUnits INT, @FinalProducts INT, @FinalCustomers INT;
SELECT @FinalUnits = COUNT(*) FROM Units;
SELECT @FinalProducts = COUNT(*) FROM Products;
SELECT @FinalCustomers = COUNT(*) FROM Customers WHERE TenKhachHang = N'Khách vãng lai';

PRINT 'Tổng kết:';
PRINT '- Units còn lại: ' + CAST(@FinalUnits AS VARCHAR) + ' (mong đợi: 4)';
PRINT '- Products còn lại: ' + CAST(@FinalProducts AS VARCHAR);
PRINT '- Khách vãng lai: ' + CAST(@FinalCustomers AS VARCHAR) + ' (mong đợi: 1)';
PRINT '';

PRINT '--- DANH SÁCH UNITS ---';
SELECT UnitID, TenDVT FROM Units ORDER BY UnitID;

PRINT '';
PRINT '--- KIỂM TRA SẢN PHẨM TRÙNG ---';
SELECT TenSanPham, COUNT(*) AS SoLuong
FROM Products
GROUP BY TenSanPham
HAVING COUNT(*) > 1;

IF @@ROWCOUNT = 0
    PRINT '✓ Không còn sản phẩm trùng tên';

PRINT '';
PRINT '--- KHÁCH VÃNG LAI ---';
SELECT CustomerID, TenKhachHang, SoDienThoai
FROM Customers
WHERE TenKhachHang = N'Khách vãng lai';

PRINT '';
PRINT '========================================';
PRINT 'HOÀN TẤT!';
PRINT '========================================';
GO