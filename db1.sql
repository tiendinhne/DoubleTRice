create database QuanLyBanGao; 
use QuanLyBanGao;
/* ================================================================
SCRIPT TẠO DATABASE QUẢN LÝ CỬA HÀNG GẠO
SQL SERVER (T-SQL)
================================================================
*/

/* ----------------------------------------------------------------
PHẦN 1: QUẢN LÝ CHUNG (CORE/MASTER DATA)
----------------------------------------------------------------
*/


CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(255) NOT NULL,
    TenDangNhap VARCHAR(100) NOT NULL,
    MatKhauHash VARCHAR(255) NOT NULL, -- Luôn lưu mật khẩu đã hash
    VaiTro NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_TenDangNhap UNIQUE(TenDangNhap),
    
);

CREATE TABLE Suppliers (
    SupplierID INT IDENTITY(1,1) PRIMARY KEY,
    TenNhaCungCap NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(20),
    DiaChi NVARCHAR(500)
);

CREATE TABLE Customers (
    CustomerID INT IDENTITY(1,1) PRIMARY KEY,
    TenKhachHang NVARCHAR(255) NOT NULL,
    SoDienThoai VARCHAR(20),
    DiaChi NVARCHAR(500)
);

/* ----------------------------------------------------------------
PHẦN 2: QUẢN LÝ SẢN PHẨM & KHO (INVENTORY)
----------------------------------------------------------------
*/

CREATE TABLE Units (
    UnitID INT IDENTITY(1,1) PRIMARY KEY,
    TenDVT NVARCHAR(50) NOT NULL -- Ví dụ: 'kg', 'Bao 10kg', 'Bao 25kg'
);

INSERT INTO Units (TenDVT)
VALUES 
(N'Kg'),
(N'Tạ'),
(N'Tấn'),
(N'Bao 25kg'),
(N'Bao 50kg');



CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    TenSanPham NVARCHAR(255) NOT NULL,
    BaseUnitID INT NOT NULL, -- Đơn vị tính cơ sở (luôn là 'kg')
    TonKhoToiThieu FLOAT DEFAULT 0,
    CONSTRAINT FK_Products_BaseUnit FOREIGN KEY (BaseUnitID) REFERENCES Units(UnitID)
);

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
--select * from Products;

--------------------Tạo Stored Procedure cho Product

--xem
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products;
END
GO

--them
CREATE PROCEDURE sp_InsertProduct
    @TenSanPham NVARCHAR(255),
    @BaseUnitID INT,
    @TonKhoToiThieu FLOAT
AS
BEGIN
    INSERT INTO Products (TenSanPham, BaseUnitID, TonKhoToiThieu)
    VALUES (@TenSanPham, @BaseUnitID, @TonKhoToiThieu);
END
GO

-- sua
CREATE PROCEDURE sp_UpdateProduct
    @ProductID INT,
    @TenSanPham NVARCHAR(255),
    @BaseUnitID INT,
    @TonKhoToiThieu FLOAT
AS
BEGIN
    UPDATE Products
    SET TenSanPham = @TenSanPham,
        BaseUnitID = @BaseUnitID,
        TonKhoToiThieu = @TonKhoToiThieu
    WHERE ProductID = @ProductID;
END
GO

-- xoa
CREATE PROCEDURE sp_DeleteProduct
    @ProductID INT
AS
BEGIN
    DELETE FROM Products
    WHERE ProductID = @ProductID;
END
GO

--tim keim theo ten
CREATE PROCEDURE sp_SearchProducts
    @Keyword NVARCHAR(255)
AS
BEGIN
    SELECT * FROM Products
    WHERE TenSanPham LIKE '%' + @Keyword + '%';
END
GO


CREATE TABLE ProductUnitConversions (
    ConversionID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    UnitID INT NOT NULL, -- Đơn vị tính quy đổi (ví dụ: 'Bao 25kg')
    GiaTriQuyDoi FLOAT NOT NULL, -- Ví dụ: 25.0 (so với BaseUnitID)
    CONSTRAINT FK_Conversions_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_Conversions_Unit FOREIGN KEY (UnitID) REFERENCES Units(UnitID),
    CONSTRAINT UQ_Product_Unit_Conversion UNIQUE(ProductID, UnitID)
);

CREATE TABLE ProductInventory (
    ProductID INT PRIMARY KEY,
    SoLuongTon FLOAT NOT NULL DEFAULT 0, -- Luôn tính bằng BaseUnitID ('kg')
    CONSTRAINT FK_Inventory_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE StockAdjustments (
    AdjustmentID INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieu VARCHAR(20), -- Dùng cho PX... (Xuất hủy) hoặc PN... (Nhập nội bộ)
    ProductID INT NOT NULL,
    UserID INT NOT NULL,
    NgayDieuChinh DATETIME DEFAULT GETDATE(),
    SoLuongDieuChinh FLOAT NOT NULL, -- Số âm là XUẤT (PX), Số dương là NHẬP (PN)
    LyDo NVARCHAR(500),
    CONSTRAINT FK_Adjustments_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_Adjustments_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT UQ_MaPhieuDieuChinh UNIQUE(MaPhieu)
);

/* ----------------------------------------------------------------
PHẦN 3: NGHIỆP VỤ MUA HÀNG (PURCHASING)
----------------------------------------------------------------
*/

CREATE TABLE GoodsReceipts (
    ReceiptID INT IDENTITY(1,1) PRIMARY KEY,
    MaPhieuNhap VARCHAR(20), -- Mã hiển thị (PN...)
    SupplierID INT NOT NULL,
    UserID INT NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18, 2) DEFAULT 0,
    GhiChu NVARCHAR(500),
    CONSTRAINT FK_Receipts_Supplier FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    CONSTRAINT FK_Receipts_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT UQ_MaPhieuNhap UNIQUE(MaPhieuNhap)
);

CREATE TABLE GoodsReceiptDetails (
    ReceiptDetailID INT IDENTITY(1,1) PRIMARY KEY,
    ReceiptID INT NOT NULL,
    ProductID INT NOT NULL,
    UnitID INT NOT NULL, -- Đơn vị lúc nhập (ví dụ: 'Bao 25kg')
    SoLuong FLOAT NOT NULL,
    DonGiaNhap DECIMAL(18, 2) NOT NULL,
    ThanhTien AS (CAST(SoLuong * DonGiaNhap AS DECIMAL(18, 2))), -- Computed column
    CONSTRAINT FK_ReceiptDetails_Receipt FOREIGN KEY (ReceiptID) REFERENCES GoodsReceipts(ReceiptID),
    CONSTRAINT FK_ReceiptDetails_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_ReceiptDetails_Unit FOREIGN KEY (UnitID) REFERENCES Units(UnitID)
);

CREATE TABLE SupplierPayments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    SupplierID INT NOT NULL,
    ReceiptID INT, -- Có thể NULL nếu thanh toán gộp
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    SoTien DECIMAL(18, 2) NOT NULL,
    PhuongThuc NVARCHAR(100) DEFAULT N'Tiền mặt',
    CONSTRAINT FK_SupplierPayments_Supplier FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID),
    CONSTRAINT FK_SupplierPayments_Receipt FOREIGN KEY (ReceiptID) REFERENCES GoodsReceipts(ReceiptID)
);

/* ----------------------------------------------------------------
PHẦN 4: NGHIỆP VỤ BÁN HÀNG (SALES)
----------------------------------------------------------------
*/

CREATE TABLE PriceList (
    PriceID INT IDENTITY(1,1) PRIMARY KEY,
    ProductID INT NOT NULL,
    UnitID INT NOT NULL, -- Đơn vị tính bán
    GiaBan DECIMAL(18, 2) NOT NULL,
    NgayApDung DATE DEFAULT GETDATE(),
    CONSTRAINT FK_PriceList_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_PriceList_Unit FOREIGN KEY (UnitID) REFERENCES Units(UnitID),
    CONSTRAINT UQ_Product_Unit_Price UNIQUE(ProductID, UnitID)
);

CREATE TABLE SalesInvoices (
    InvoiceID INT IDENTITY(1,1) PRIMARY KEY,
    MaHoaDon VARCHAR(20), -- Mã hiển thị (HD...)
    CustomerID INT NOT NULL,
    UserID INT NOT NULL,
    NgayBan DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(18, 2) DEFAULT 0,
    TrangThai NVARCHAR(100) DEFAULT N'Đã thanh toán', -- 'Đã thanh toán', 'Ghi nợ'
    CONSTRAINT FK_Invoices_Customer FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Invoices_User FOREIGN KEY (UserID) REFERENCES Users(UserID),
    CONSTRAINT UQ_MaHoaDon UNIQUE(MaHoaDon)
);

CREATE TABLE SalesInvoiceDetails (
    InvoiceDetailID INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceID INT NOT NULL,
    ProductID INT NOT NULL,
    UnitID INT NOT NULL, -- Đơn vị lúc bán (ví dụ: 'kg')
    SoLuong FLOAT NOT NULL,
    DonGiaBan DECIMAL(18, 2) NOT NULL,
    ThanhTien AS (CAST(SoLuong * DonGiaBan AS DECIMAL(18, 2))), -- Computed column
    CONSTRAINT FK_InvoiceDetails_Invoice FOREIGN KEY (InvoiceID) REFERENCES SalesInvoices(InvoiceID),
    CONSTRAINT FK_InvoiceDetails_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    CONSTRAINT FK_InvoiceDetails_Unit FOREIGN KEY (UnitID) REFERENCES Units(UnitID)
);

CREATE TABLE CustomerPayments (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    CustomerID INT NOT NULL,
    InvoiceID INT, -- Có thể NULL nếu thanh toán gộp
    NgayThanhToan DATETIME DEFAULT GETDATE(),
    SoTien DECIMAL(18, 2) NOT NULL,
    PhuongThuc NVARCHAR(100) DEFAULT N'Tiền mặt',
    CONSTRAINT FK_CustomerPayments_Customer FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    CONSTRAINT FK_CustomerPayments_Invoice FOREIGN KEY (InvoiceID) REFERENCES SalesInvoices(InvoiceID)
);


-- Chèn đơn vị tính
INSERT INTO Units (TenDVT) VALUES 
(N'kg'), 
(N'Bao 10kg'), 
(N'Bao 25kg');

-- Chèn khách vãng lai
INSERT INTO Customers (TenKhachHang, SoDienThoai) VALUES
(N'Khách vãng lai', '000000000');


/* ================================================================
PHẦN 5: TRIGGERS TỰ ĐỘNG SINH MÃ HIỂN THỊ
================================================================
*/

-- 1. Trigger cho Hóa đơn bán hàng (SalesInvoices) - Định dạng: HDddmmyy00x
CREATE TRIGGER trg_GenerateMaHoaDon
ON SalesInvoices
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewInvoiceID INT;
    DECLARE @NgayBan DATETIME;
    DECLARE @DateString VARCHAR(6);
    DECLARE @NextSeq INT;
    DECLARE @MaHoaDon VARCHAR(20);

    -- Lấy ID và ngày từ dòng vừa được chèn
    SELECT @NewInvoiceID = i.InvoiceID, @NgayBan = i.NgayBan
    FROM inserted i;

    -- Lấy ngày theo định dạng ddMMyy
    SET @DateString = FORMAT(@NgayBan, 'ddMMyy');

    -- Tìm số thứ tự tiếp theo TRONG NGÀY HÔM ĐÓ
    -- *** Cảnh báo: Đây là điểm có thể xảy ra race condition ***
    SELECT @NextSeq = ISNULL(MAX(CAST(RIGHT(MaHoaDon, 3) AS INT)), 0) + 1
    FROM SalesInvoices
    WHERE CONVERT(DATE, NgayBan) = CONVERT(DATE, @NgayBan)
      AND MaHoaDon IS NOT NULL; -- Tránh chính bản ghi đang insert

    -- Tạo mã mới
    SET @MaHoaDon = 'HD' + @DateString + FORMAT(@NextSeq, '000');

    -- Cập nhật lại dòng vừa chèn với mã mới
    UPDATE SalesInvoices
    SET MaHoaDon = @MaHoaDon
    WHERE InvoiceID = @NewInvoiceID;
END;
GO

-- 2. Trigger cho Phiếu nhập kho (GoodsReceipts) - Định dạng: PNddmmyy00x
CREATE TRIGGER trg_GenerateMaPhieuNhap
ON GoodsReceipts
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewReceiptID INT;
    DECLARE @NgayNhap DATETIME;
    DECLARE @DateString VARCHAR(6);
    DECLARE @NextSeq INT;
    DECLARE @MaPhieuNhap VARCHAR(20);

    SELECT @NewReceiptID = i.ReceiptID, @NgayNhap = i.NgayNhap
    FROM inserted i;

    SET @DateString = FORMAT(@NgayNhap, 'ddMMyy');

    SELECT @NextSeq = ISNULL(MAX(CAST(RIGHT(MaPhieuNhap, 3) AS INT)), 0) + 1
    FROM GoodsReceipts
    WHERE CONVERT(DATE, NgayNhap) = CONVERT(DATE, @NgayNhap)
      AND MaPhieuNhap IS NOT NULL;

    SET @MaPhieuNhap = 'PN' + @DateString + FORMAT(@NextSeq, '000');

    UPDATE GoodsReceipts
    SET MaPhieuNhap = @MaPhieuNhap
    WHERE ReceiptID = @NewReceiptID;
END;
GO

-- 3. Trigger cho Phiếu điều chỉnh (StockAdjustments) - Định dạng: PX... (Xuất) hoặc PN... (Nhập)
CREATE TRIGGER trg_GenerateMaPhieuDieuChinh
ON StockAdjustments
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NewAdjustmentID INT;
    DECLARE @NgayDieuChinh DATETIME;
    DECLARE @SoLuong FLOAT;
    DECLARE @DateString VARCHAR(6);
    DECLARE @NextSeq INT;
    DECLARE @MaPhieu VARCHAR(20);
    DECLARE @Prefix VARCHAR(2);

    SELECT @NewAdjustmentID = i.AdjustmentID, 
           @NgayDieuChinh = i.NgayDieuChinh,
           @SoLuong = i.SoLuongDieuChinh
    FROM inserted i;

    -- Quyết định tiền tố: PX (Phiếu Xuất - Hủy) nếu là số âm, PN (Phiếu Nhập - Nội bộ) nếu là số dương
    SET @Prefix = IIF(@SoLuong < 0, 'PX', 'PN');
    SET @DateString = FORMAT(@NgayDieuChinh, 'ddMMyy');

    -- Tìm số thứ tự tiếp theo DỰA TRÊN TIỀN TỐ VÀ NGÀY
    SELECT @NextSeq = ISNULL(MAX(CAST(RIGHT(MaPhieu, 3) AS INT)), 0) + 1
    FROM StockAdjustments
    WHERE CONVERT(DATE, NgayDieuChinh) = CONVERT(DATE, @NgayDieuChinh)
      AND MaPhieu LIKE @Prefix + '%'
      AND MaPhieu IS NOT NULL;

    SET @MaPhieu = @Prefix + @DateString + FORMAT(@NextSeq, '000');

    UPDATE StockAdjustments
    SET MaPhieu = @MaPhieu
    WHERE AdjustmentID = @NewAdjustmentID;
END;
GO

--00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000
------------------------------------ 17-11 by td---------------------------------------------------
----------------------ttttttttttttttttttttttttttttttt---------------------------------------------
--------------------------------------------------------------------------------------------------


-- ===================================================================
-- SQL STORED PROCEDURES - HỆ THỐNG ĐĂNG NHẬP
-- ===================================================================

-- Thêm cột IsLocked vào bảng Users nếu chưa có
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'Users') AND name = 'IsLocked')
BEGIN
    ALTER TABLE Users ADD IsLocked BIT DEFAULT 0;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'Users') AND name = 'FailedLoginAttempts')
BEGIN
    ALTER TABLE Users ADD FailedLoginAttempts INT DEFAULT 0;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'Users') AND name = 'LastLoginDate')
BEGIN
    ALTER TABLE Users ADD LastLoginDate DATETIME NULL;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID(N'Users') AND name = 'CreatedDate')
BEGIN
    ALTER TABLE Users ADD CreatedDate DATETIME DEFAULT GETDATE();
END
GO

-- ===================================================================
-- 1. STORED PROCEDURE ĐĂNG NHẬP
-- ===================================================================
IF OBJECT_ID('sp_Login', 'P') IS NOT NULL
    DROP PROCEDURE sp_Login;
GO

CREATE PROCEDURE sp_Login
    @TenDangNhap VARCHAR(100),
    @MatKhauHash VARCHAR(255),
    @Result INT OUTPUT,
    @UserID INT OUTPUT,
    @HoTen NVARCHAR(255) OUTPUT,
    @VaiTro NVARCHAR(100) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StoredPasswordHash VARCHAR(255);
    DECLARE @IsLocked BIT;
    DECLARE @FailedAttempts INT;
    
    -- Khởi tạo giá trị mặc định
    SET @Result = -99;
    SET @UserID = 0;
    SET @HoTen = NULL;
    SET @VaiTro = NULL;
    
    -- Kiểm tra tài khoản có tồn tại không
    SELECT 
        @UserID = UserID,
        @HoTen = HoTen,
        @VaiTro = VaiTro,
        @StoredPasswordHash = MatKhauHash,
        @IsLocked = ISNULL(IsLocked, 0),
        @FailedAttempts = ISNULL(FailedLoginAttempts, 0)
    FROM Users
    WHERE TenDangNhap = @TenDangNhap;
    
    -- Tài khoản không tồn tại
    IF @UserID IS NULL OR @UserID = 0
    BEGIN
        SET @Result = -1;
        SET @UserID = 0;
        SET @HoTen = NULL;
        SET @VaiTro = NULL;
        RETURN;
    END
    
    -- Kiểm tra tài khoản có bị khóa không
    IF @IsLocked = 1
    BEGIN
        SET @Result = -3;
        RETURN;
    END
    
    -- Kiểm tra mật khẩu
    IF @StoredPasswordHash = @MatKhauHash
    BEGIN
        SET @Result = 0;
        
        UPDATE Users
        SET FailedLoginAttempts = 0,
            LastLoginDate = GETDATE()
        WHERE UserID = @UserID;
    END
    ELSE
    BEGIN
        SET @Result = -2;
        SET @UserID = 0;
        SET @HoTen = NULL;
        SET @VaiTro = NULL;
        
        UPDATE Users
        SET FailedLoginAttempts = FailedLoginAttempts + 1
        WHERE UserID = @UserID;
        
        IF @FailedAttempts + 1 >= 5
        BEGIN
            UPDATE Users
            SET IsLocked = 1
            WHERE UserID = @UserID;
            
            SET @Result = -3;
        END
    END
END
GO
-- ===================================================================
-- 2. STORED PROCEDURE ĐỔI MẬT KHẨU
-- ===================================================================
IF OBJECT_ID('sp_ChangePassword', 'P') IS NOT NULL
    DROP PROCEDURE sp_ChangePassword;
GO

CREATE PROCEDURE sp_ChangePassword
    @UserID INT,
    @MatKhauCuHash VARCHAR(255),
    @MatKhauMoiHash VARCHAR(255),
    @Result INT OUTPUT  -- 0: Thành công, -1: Sai MK cũ, -2: MK mới trùng MK cũ, -3: User không tồn tại
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @StoredPasswordHash VARCHAR(255);
    
    SET @Result = -3;
    
    -- Lấy mật khẩu hiện tại
    SELECT @StoredPasswordHash = MatKhauHash
    FROM Users
    WHERE UserID = @UserID;
    
    -- Kiểm tra user có tồn tại không
    IF @StoredPasswordHash IS NULL
    BEGIN
        SET @Result = -3; -- User không tồn tại
        RETURN;
    END
    
    -- Kiểm tra mật khẩu cũ có đúng không
    IF @StoredPasswordHash <> @MatKhauCuHash
    BEGIN
        SET @Result = -1; -- Sai mật khẩu cũ
        RETURN;
    END
    
    -- Kiểm tra mật khẩu mới có trùng mật khẩu cũ không
    IF @MatKhauCuHash = @MatKhauMoiHash
    BEGIN
        SET @Result = -2; -- Mật khẩu mới trùng mật khẩu cũ
        RETURN;
    END
    
    -- Đổi mật khẩu
    UPDATE Users
    SET MatKhauHash = @MatKhauMoiHash
    WHERE UserID = @UserID;
    
    SET @Result = 0; -- Thành công
END
GO
-- ===================================================================
-- 3. STORED PROCEDURE MỞ KHÓA TÀI KHOẢN (CHO ADMIN)
-- ===================================================================
IF OBJECT_ID('sp_UnlockAccount', 'P') IS NOT NULL
    DROP PROCEDURE sp_UnlockAccount;
GO

CREATE PROCEDURE sp_UnlockAccount
    @UserID INT,
    @Result INT OUTPUT  -- 0: Thành công, -1: User không tồn tại
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS(SELECT 1 FROM Users WHERE UserID = @UserID)
    BEGIN
        UPDATE Users
        SET IsLocked = 0,
            FailedLoginAttempts = 0
        WHERE UserID = @UserID;
        
        SET @Result = 0;
    END
    ELSE
    BEGIN
        SET @Result = -1;
    END
END
GO


-- ===================================================================
-- 4. STORED PROCEDURE KIỂM TRA USERNAME ĐÃ TỒN TẠI
-- ===================================================================
IF OBJECT_ID('sp_CheckUsernameExists', 'P') IS NOT NULL
    DROP PROCEDURE sp_CheckUsernameExists;
GO

CREATE PROCEDURE sp_CheckUsernameExists
    @TenDangNhap VARCHAR(100),
    @Exists BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    IF EXISTS(SELECT 1 FROM Users WHERE TenDangNhap = @TenDangNhap)
        SET @Exists = 1;
    ELSE
        SET @Exists = 0;
END
GO


-- ===================================================================
-- 5. INSERT DỮ LIỆU MẪU (USER TEST)
-- Password: 123456 -> Hash: 8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92
-- ===================================================================

-- Xóa dữ liệu cũ nếu có
DELETE FROM Users;
GO

-- Insert users mẫu (Password tất cả là: 123456)
INSERT INTO Users (HoTen, TenDangNhap, MatKhauHash, VaiTro, IsLocked, FailedLoginAttempts)
VALUES 
(N'Administrator', 'admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Admin', 0, 0),
(N'Nguyễn Văn Thu Ngân', 'thungan', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Thu Ngân', 0, 0),
(N'Trần Thị Thủ Kho', 'thukho', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Thủ Kho', 0, 0),
(N'Lê Văn Kế Toán', 'ketoan', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Kế Toán', 0, 0),
(N'Test Locked User', 'locked', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', N'Admin', 1, 5);
GO

/*
-- ===================================================================
-- TEST STORED PROCEDURES
-- ===================================================================

-- Test 1: Login thành công
--DECLARE @Result INT, @UserID INT, @HoTen NVARCHAR(255), @VaiTro NVARCHAR(100);
--EXEC sp_Login 'admin', '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', @Result OUTPUT, @UserID OUTPUT, @HoTen OUTPUT, @VaiTro OUTPUT;
PRINT 'Test Login - Result: ' + CAST(@Result AS VARCHAR) + ', UserID: ' + CAST(ISNULL(@UserID, 0) AS VARCHAR) + ', HoTen: ' + ISNULL(@HoTen, 'NULL');

-- Test 2: Đổi mật khẩu
DECLARE @ChangeResult INT;
EXEC sp_ChangePassword 1, '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92', 'new_hash_here', @ChangeResult OUTPUT;
PRINT 'Test Change Password - Result: ' + CAST(@ChangeResult AS VARCHAR);

-- Reset lại password
UPDATE Users SET MatKhauHash = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92' WHERE UserID = 1;
GO

PRINT 'STORED PROCEDURES CREATED SUCCESSFULLY!';
PRINT 'Test Users:';
PRINT 'Username: admin | Password: 123456 | Role: Admin';
PRINT 'Username: thungan | Password: 123456 | Role: Thu Ngân';
PRINT 'Username: thukho | Password: 123456 | Role: Thủ Kho';
PRINT 'Username: ketoan | Password: 123456 | Role: Kế Toán';
GO */

/*
SELECT 
    name AS [Stored Procedure],
    create_date AS [Created Date],
    modify_date AS [Modified Date]
FROM sys.procedures 
WHERE name = 'sp_Login';
GO
-- Test SP:
DECLARE @Result INT;
DECLARE @UserID INT;
DECLARE @HoTen NVARCHAR(255);
DECLARE @VaiTro NVARCHAR(100);

EXEC sp_Login 
    @TenDangNhap = 'admin',
    @MatKhauHash = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
    @Result = @Result OUTPUT,
    @UserID = @UserID OUTPUT,
    @HoTen = @HoTen OUTPUT,
    @VaiTro = @VaiTro OUTPUT;

SELECT @Result AS Result, @UserID AS UserID, @HoTen AS HoTen, @VaiTro AS VaiTro;
EXEC sp_helptext 'sp_Login';
GO

SELECT 
    UserID,
    HoTen,
    TenDangNhap,
    MatKhauHash,
    VaiTro,
    IsLocked,
    FailedLoginAttempts
FROM Users
WHERE TenDangNhap = 'admin';
*/