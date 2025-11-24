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


CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    TenSanPham NVARCHAR(255) NOT NULL,
    BaseUnitID INT NOT NULL, -- Đơn vị tính cơ sở (luôn là 'kg')
    TonKhoToiThieu FLOAT DEFAULT 0,
    CONSTRAINT FK_Products_BaseUnit FOREIGN KEY (BaseUnitID) REFERENCES Units(UnitID)
);

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


/* -------- merge lần 1 by TP --------
    Thêm các dòng lệnh còn thiếu cho các lần cập nhật ngày 15 và ngày 17 từ repo TP local
*/ 

---- Thực hiện chỉnh sửa ngày 15/11/2025--------------------------------------------!!!!!!!
ALTER TABLE CustomerPayments
ALTER COLUMN InvoiceID INT NOT NULL;
---- Thực hiện test tính năng:
/* ================================================================
BÁO CÁO TỔNG HỢP CÔNG NỢ PHẢI TRẢ NHÀ CUNG CẤP
================================================================
*/

-- Thiết lập kỳ báo cáo (ví dụ: Tháng 11/2025)
DECLARE @StartDate DATE = '2025-11-01';
DECLARE @EndDate DATE = '2025-11-30';

-- 1. Tính toán số dư Nợ Đầu Kỳ (trước @StartDate)
WITH DauKy AS (
    SELECT 
        SupplierID,
        SUM(SoTien) AS NoDauKy
    FROM (
        -- Tổng tiền hàng đã nhập (Nợ tăng)
        SELECT 
            SupplierID, 
            TongTien AS SoTien
        FROM GoodsReceipts
        WHERE NgayNhap < @StartDate
        
        UNION ALL
        
        -- Tổng tiền đã trả (Nợ giảm)
        SELECT 
            SupplierID, 
            -SoTien AS SoTien -- Dùng số âm
        FROM SupplierPayments
        WHERE NgayThanhToan < @StartDate
    ) AS GiaoDichDauKy
    GROUP BY SupplierID
),

-- 2. Tính toán phát sinh Tăng/Giảm Trong Kỳ (từ @StartDate đến @EndDate)
TrongKy AS (
    SELECT 
        SupplierID,
        SUM(CASE WHEN GiaoDich = 'MuaHang' THEN SoTien ELSE 0 END) AS PhatSinhTang,
        SUM(CASE WHEN GiaoDich = 'TraTien' THEN SoTien ELSE 0 END) AS PhatSinhGiam
    FROM (
        -- Giao dịch mua hàng
        SELECT 
            SupplierID, 
            TongTien AS SoTien, 
            'MuaHang' AS GiaoDich
        FROM GoodsReceipts
        WHERE NgayNhap BETWEEN @StartDate AND @EndDate
        
        UNION ALL
        
        -- Giao dịch trả tiền
        SELECT 
            SupplierID, 
            SoTien AS SoTien, 
            'TraTien' AS GiaoDich
        FROM SupplierPayments
        WHERE NgayThanhToan BETWEEN @StartDate AND @EndDate
    ) AS GiaoDichTrongKy
    GROUP BY SupplierID
)

-- 3. Tổng hợp báo cáo
SELECT 
    S.SupplierID,
    S.TenNhaCungCap,
    ISNULL(DK.NoDauKy, 0) AS NoDauKy,
    ISNULL(TK.PhatSinhTang, 0) AS PhatSinhTang,
    ISNULL(TK.PhatSinhGiam, 0) AS PhatSinhGiam,
    -- Công thức: Nợ Cuối Kỳ = Đầu Kỳ + Tăng - Giảm
    (ISNULL(DK.NoDauKy, 0) + ISNULL(TK.PhatSinhTang, 0) - ISNULL(TK.PhatSinhGiam, 0)) AS NoCuoiKy
FROM 
    Suppliers AS S
LEFT JOIN 
    DauKy AS DK ON S.SupplierID = DK.SupplierID
LEFT JOIN 
    TrongKy AS TK ON S.SupplierID = TK.SupplierID
WHERE 
    -- Lọc ra các nhà cung cấp có nợ đầu kỳ HOẶC có phát sinh trong kỳ
    ISNULL(DK.NoDauKy, 0) != 0 
    OR ISNULL(TK.PhatSinhTang, 0) != 0 
    OR ISNULL(TK.PhatSinhGiam, 0) != 0
ORDER BY
    S.TenNhaCungCap;


----- Điều chỉnh ngày 17/11/2025 ------------------------------------------------!!!!
/* ===============================================================================================================
    1. Xóa cột TrangThai (trong SalesInvoices): Đây là dữ liệu tính toán động, không được lưu trữ.
    Bổ sung Triggers để cập nhật ProductInventory: phải viết 3 trigger AFTER INSERT cho 3 bảng:
    2. SalesInvoiceDetails (để TRỪ kho khi bán)
    3. GoodsReceiptDetails (để CỘNG kho khi nhập)
    4. Và bổ sung logic cập nhật kho vào trigger trg_GenerateMaPhieuDieuChinh (để CỘNG/TRỪ kho khi điều chỉnh).
   ===============================================================================================================
*/ 

---1.
-- Kiểm tra xem ràng buộc mặc định (default constraint) có tồn tại không trước khi xóa
DECLARE @ConstraintName NVARCHAR(200)
SELECT @ConstraintName = C.name
FROM sys.default_constraints C
JOIN sys.columns S ON C.parent_object_id = S.object_id AND C.parent_column_id = S.column_id
WHERE C.parent_object_id = OBJECT_ID('SalesInvoices')
  AND S.name = 'TrangThai'

IF @ConstraintName IS NOT NULL
BEGIN
    EXEC('ALTER TABLE SalesInvoices DROP CONSTRAINT ' + @ConstraintName)
END

-- Sau khi xóa ràng buộc, tiến hành xóa cột
ALTER TABLE SalesInvoices
DROP COLUMN TrangThai;

GO

---2. 
CREATE TRIGGER trg_UpdateStockOnSale
ON SalesInvoiceDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật ProductInventory dựa trên các dòng vừa được chèn (bảng 'inserted')
    -- Đây là cách viết set-based, xử lý được cả trường hợp insert nhiều dòng cùng lúc
    UPDATE pi
    SET 
        pi.SoLuongTon = pi.SoLuongTon - (i.SoLuong * puc.GiaTriQuyDoi)
    FROM 
        ProductInventory AS pi
    JOIN 
        inserted AS i ON pi.ProductID = i.ProductID
    JOIN 
        ProductUnitConversions AS puc ON i.ProductID = puc.ProductID AND i.UnitID = puc.UnitID
    WHERE 
        pi.ProductID IN (SELECT ProductID FROM inserted);
END;
GO

---3. 
CREATE TRIGGER trg_UpdateStockOnPurchase
ON GoodsReceiptDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Cập nhật ProductInventory dựa trên các dòng vừa được chèn (bảng 'inserted')
    UPDATE pi
    SET 
        pi.SoLuongTon = pi.SoLuongTon + (i.SoLuong * puc.GiaTriQuyDoi)
    FROM 
        ProductInventory AS pi
    JOIN 
        inserted AS i ON pi.ProductID = i.ProductID
    JOIN 
        ProductUnitConversions AS puc ON i.ProductID = puc.ProductID AND i.UnitID = puc.UnitID
    WHERE 
        pi.ProductID IN (SELECT ProductID FROM inserted);
END;
GO

---4. 
ALTER TRIGGER trg_GenerateMaPhieuDieuChinh
ON StockAdjustments
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    /* ================================================================
       PHẦN 1: LOGIC SINH MÃ PHIẾU (GIỮ NGUYÊN NHƯ FILE CỦA EM)
       *** Cảnh báo: Logic này không an toàn cho multi-row insert,
           nhưng giữ nguyên theo yêu cầu ban đầu.
    ================================================================
    */
    DECLARE @NewAdjustmentID INT;
    DECLARE @NgayDieuChinh DATETIME;
    DECLARE @SoLuong FLOAT;
    DECLARE @DateString VARCHAR(6);
    DECLARE @NextSeq INT;
    DECLARE @MaPhieu VARCHAR(20);
    DECLARE @Prefix VARCHAR(2);

    -- Giả sử trigger này chỉ chạy 1 dòng 1 lần (theo logic code cũ)
    SELECT @NewAdjustmentID = i.AdjustmentID, 
           @NgayDieuChinh = i.NgayDieuChinh,
           @SoLuong = i.SoLuongDieuChinh
    FROM inserted i;

    SET @Prefix = IIF(@SoLuong < 0, 'PX', 'PN');
    SET @DateString = FORMAT(@NgayDieuChinh, 'ddMMyy');

    SELECT @NextSeq = ISNULL(MAX(CAST(RIGHT(MaPhieu, 3) AS INT)), 0) + 1
    FROM StockAdjustments
    WHERE CONVERT(DATE, NgayDieuChinh) = CONVERT(DATE, @NgayDieuChinh)
      AND MaPhieu LIKE @Prefix + '%'
      AND MaPhieu IS NOT NULL;

    SET @MaPhieu = @Prefix + @DateString + FORMAT(@NextSeq, '000');

    UPDATE StockAdjustments
    SET MaPhieu = @MaPhieu
    WHERE AdjustmentID = @NewAdjustmentID;

    /* ================================================================
       PHẦN 2: LOGIC CẬP NHẬT KHO MỚI ĐƯỢC THÊM VÀO
    ================================================================
    */
    -- Logic này được viết an toàn (set-based)
    -- Nó sẽ cộng/trừ SoLuongDieuChinh (đã là số 'kg') vào kho
    UPDATE pi
    SET
        pi.SoLuongTon = pi.SoLuongTon + i.SoLuongDieuChinh
    FROM
        ProductInventory AS pi
    JOIN
        inserted AS i ON pi.ProductID = i.ProductID
    WHERE
        pi.ProductID IN (SELECT ProductID FROM inserted);

END;
GO


-- ===================================================================
-- STORED PROCEDURES CHO QUẢN LÝ NGƯỜI DÙNG (ADMIN)
----------------------------xxxxxxxxxxxxxxxxxxxxxxxxxxx-------------------21-11 by td
-- ===================================================================

-- 1. SP LẤY TẤT CẢ USERS (với thông tin chi tiết)
IF OBJECT_ID('sp_GetAllUsersAdmin', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllUsersAdmin;
GO

CREATE PROCEDURE sp_GetAllUsersAdmin
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        UserID,
        HoTen,
        TenDangNhap,
		MatKhauHash,
        VaiTro,
        ISNULL(IsLocked, 0) AS IsLocked,
        ISNULL(FailedLoginAttempts, 0) AS FailedLoginAttempts,
        LastLoginDate,
        CreatedDate
    FROM Users
    ORDER BY CreatedDate DESC;
END
GO

-- 2. SP THÊM USER MỚI
IF OBJECT_ID('sp_InsertUser', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertUser;
GO

CREATE PROCEDURE sp_InsertUser
    @HoTen NVARCHAR(255),
    @TenDangNhap VARCHAR(100),
    @MatKhauHash VARCHAR(255),
    @VaiTro NVARCHAR(100),
    @Result INT OUTPUT,
    @NewUserID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    SET @NewUserID = 0;
    
    -- Kiểm tra username đã tồn tại
    IF EXISTS(SELECT 1 FROM Users WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        SET @Result = -2; -- Username đã tồn tại
        RETURN;
    END
    
    -- Insert user mới
    BEGIN TRY
        INSERT INTO Users (HoTen, TenDangNhap, MatKhauHash, VaiTro, IsLocked, FailedLoginAttempts, CreatedDate)
        VALUES (@HoTen, @TenDangNhap, @MatKhauHash, @VaiTro, 0, 0, GETDATE());
        
        SET @NewUserID = SCOPE_IDENTITY();
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 3. SP CẬP NHẬT THÔNG TIN USER
IF OBJECT_ID('sp_UpdateUser', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateUser;
GO

CREATE PROCEDURE sp_UpdateUser
    @UserID INT,
    @HoTen NVARCHAR(255),
    @TenDangNhap VARCHAR(100),
    @VaiTro NVARCHAR(100),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra user có tồn tại
    IF NOT EXISTS(SELECT 1 FROM Users WHERE UserID = @UserID)
    BEGIN
        SET @Result = -1; -- User không tồn tại
        RETURN;
    END
    
    -- Kiểm tra username trùng (ngoại trừ chính nó)
    IF EXISTS(SELECT 1 FROM Users WHERE TenDangNhap = @TenDangNhap AND UserID != @UserID)
    BEGIN
        SET @Result = -2; -- Username đã tồn tại
        RETURN;
    END
    
    BEGIN TRY
        UPDATE Users
        SET HoTen = @HoTen,
            TenDangNhap = @TenDangNhap,
            VaiTro = @VaiTro
        WHERE UserID = @UserID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 4. SP XÓA USER
IF OBJECT_ID('sp_DeleteUser', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteUser;
GO

CREATE PROCEDURE sp_DeleteUser
    @UserID INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Không cho xóa user cuối cùng
    IF (SELECT COUNT(*) FROM Users) <= 1
    BEGIN
        SET @Result = -3; -- Không thể xóa user cuối cùng
        RETURN;
    END
    
    -- Kiểm tra user có tồn tại
    IF NOT EXISTS(SELECT 1 FROM Users WHERE UserID = @UserID)
    BEGIN
        SET @Result = -1; -- User không tồn tại
        RETURN;
    END
    
    BEGIN TRY
        DELETE FROM Users WHERE UserID = @UserID;
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống (có thể do foreign key constraint)
    END CATCH
END
GO

-- 5. SP RESET PASSWORD (ADMIN)
IF OBJECT_ID('sp_ResetPasswordAdmin', 'P') IS NOT NULL
    DROP PROCEDURE sp_ResetPasswordAdmin;
GO

CREATE PROCEDURE sp_ResetPasswordAdmin
    @UserID INT,
    @NewPasswordHash VARCHAR(255),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    IF NOT EXISTS(SELECT 1 FROM Users WHERE UserID = @UserID)
    BEGIN
        SET @Result = -1; -- User không tồn tại
        RETURN;
    END
    
    BEGIN TRY
        UPDATE Users
        SET MatKhauHash = @NewPasswordHash,
            FailedLoginAttempts = 0
        WHERE UserID = @UserID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 6. SP TOGGLE LOCK/UNLOCK USER
IF OBJECT_ID('sp_ToggleLockUser', 'P') IS NOT NULL
    DROP PROCEDURE sp_ToggleLockUser;
GO

CREATE PROCEDURE sp_ToggleLockUser
    @UserID INT,
    @IsLocked BIT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    IF NOT EXISTS(SELECT 1 FROM Users WHERE UserID = @UserID)
    BEGIN
        SET @Result = -1; -- User không tồn tại
        RETURN;
    END
    
    BEGIN TRY
        UPDATE Users
        SET IsLocked = @IsLocked,
            FailedLoginAttempts = 0
        WHERE UserID = @UserID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- ===================================================================
-- STORED PROCEDURES CHO QUẢN LÝ SẢN PHẨM (TỐI ƯU HÓA)
-- By: tiendinh - Date: 23/11/2025
-- ===================================================================

-- 1. TỐI ƯU SP_GetAllProducts - Thêm thông tin chi tiết
IF OBJECT_ID('sp_GetAllProductsDetail', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllProductsDetail;
GO

CREATE PROCEDURE sp_GetAllProductsDetail
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.ProductID,
        p.TenSanPham,
        p.BaseUnitID,
        u.TenDVT AS BaseUnitName,
        p.TonKhoToiThieu,
        ISNULL(pi.SoLuongTon, 0) AS SoLuongTon,
        -- Tính trạng thái tồn kho
        CASE 
            WHEN ISNULL(pi.SoLuongTon, 0) <= 0 THEN N'Hết hàng'
            WHEN ISNULL(pi.SoLuongTon, 0) <= p.TonKhoToiThieu THEN N'Sắp hết'
            ELSE N'Còn hàng'
        END AS TrangThaiTonKho
    FROM Products p
    LEFT JOIN Units u ON p.BaseUnitID = u.UnitID
    LEFT JOIN ProductInventory pi ON p.ProductID = pi.ProductID
    ORDER BY p.TenSanPham;
END
GO

-- 2. TỐI ƯU SP_InsertProduct - Thêm tự động tạo inventory & conversion
IF OBJECT_ID('sp_InsertProductEnhanced', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertProductEnhanced;
GO

CREATE PROCEDURE sp_InsertProductEnhanced
    @TenSanPham NVARCHAR(255),
    @BaseUnitID INT,
    @TonKhoToiThieu FLOAT,
    @Result INT OUTPUT,
    @NewProductID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    SET @NewProductID = 0;
    
    -- Kiểm tra tên sản phẩm đã tồn tại
    IF EXISTS(SELECT 1 FROM Products WHERE TenSanPham = @TenSanPham)
    BEGIN
        SET @Result = -2; -- Tên sản phẩm đã tồn tại
        RETURN;
    END
    
    -- Kiểm tra BaseUnitID có tồn tại
    IF NOT EXISTS(SELECT 1 FROM Units WHERE UnitID = @BaseUnitID)
    BEGIN
        SET @Result = -3; -- Đơn vị tính không tồn tại
        RETURN;
    END
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Insert product
        INSERT INTO Products (TenSanPham, BaseUnitID, TonKhoToiThieu)
        VALUES (@TenSanPham, @BaseUnitID, @TonKhoToiThieu);
        
        SET @NewProductID = SCOPE_IDENTITY();
        
        -- Tự động tạo bản ghi trong ProductInventory
        INSERT INTO ProductInventory (ProductID, SoLuongTon)
        VALUES (@NewProductID, 0);
        
        -- Tự động tạo quy đổi cho BaseUnit (1:1)
        INSERT INTO ProductUnitConversions (ProductID, UnitID, GiaTriQuyDoi)
        VALUES (@NewProductID, @BaseUnitID, 1.0);
        
        COMMIT TRANSACTION;
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO


-- 3. TỐI ƯU SP_UpdateProduct - Thêm validation
IF OBJECT_ID('sp_UpdateProductEnhanced', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateProductEnhanced;
GO

CREATE PROCEDURE sp_UpdateProductEnhanced
    @ProductID INT,
    @TenSanPham NVARCHAR(255),
    @BaseUnitID INT,
    @TonKhoToiThieu FLOAT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra product có tồn tại
    IF NOT EXISTS(SELECT 1 FROM Products WHERE ProductID = @ProductID)
    BEGIN
        SET @Result = -1; -- Sản phẩm không tồn tại
        RETURN;
    END
    
    -- Kiểm tra tên trùng (ngoại trừ chính nó)
    IF EXISTS(SELECT 1 FROM Products WHERE TenSanPham = @TenSanPham AND ProductID != @ProductID)
    BEGIN
        SET @Result = -2; -- Tên sản phẩm đã tồn tại
        RETURN;
    END
    
    -- Kiểm tra BaseUnitID
    IF NOT EXISTS(SELECT 1 FROM Units WHERE UnitID = @BaseUnitID)
    BEGIN
        SET @Result = -3; -- Đơn vị tính không tồn tại
        RETURN;
    END
    
    BEGIN TRY
        UPDATE Products
        SET TenSanPham = @TenSanPham,
            BaseUnitID = @BaseUnitID,
            TonKhoToiThieu = @TonKhoToiThieu
        WHERE ProductID = @ProductID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO


-- 4. TỐI ƯU SP_DeleteProduct - Thêm cascade delete
IF OBJECT_ID('sp_DeleteProductEnhanced', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteProductEnhanced;
GO

CREATE PROCEDURE sp_DeleteProductEnhanced
    @ProductID INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra product có tồn tại
    IF NOT EXISTS(SELECT 1 FROM Products WHERE ProductID = @ProductID)
    BEGIN
        SET @Result = -1; -- Sản phẩm không tồn tại
        RETURN;
    END
    
    -- Kiểm tra có giao dịch liên quan không
    IF EXISTS(SELECT 1 FROM GoodsReceiptDetails WHERE ProductID = @ProductID)
       OR EXISTS(SELECT 1 FROM SalesInvoiceDetails WHERE ProductID = @ProductID)
    BEGIN
        SET @Result = -4; -- Không thể xóa do có giao dịch liên quan
        RETURN;
    END
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Xóa các bản ghi liên quan
        DELETE FROM ProductUnitConversions WHERE ProductID = @ProductID;
        DELETE FROM ProductInventory WHERE ProductID = @ProductID;
        DELETE FROM PriceList WHERE ProductID = @ProductID;
        DELETE FROM StockAdjustments WHERE ProductID = @ProductID;
        
        -- Xóa product
        DELETE FROM Products WHERE ProductID = @ProductID;
        
        COMMIT TRANSACTION;
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 5. TỐI ƯU SP_SearchProducts - Thêm thông tin chi tiết
IF OBJECT_ID('sp_SearchProductsDetail', 'P') IS NOT NULL
    DROP PROCEDURE sp_SearchProductsDetail;
GO

CREATE PROCEDURE sp_SearchProductsDetail
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.ProductID,
        p.TenSanPham,
        p.BaseUnitID,
        u.TenDVT AS BaseUnitName,
        p.TonKhoToiThieu,
        ISNULL(pi.SoLuongTon, 0) AS SoLuongTon,
        CASE 
            WHEN ISNULL(pi.SoLuongTon, 0) <= 0 THEN N'Hết hàng'
            WHEN ISNULL(pi.SoLuongTon, 0) <= p.TonKhoToiThieu THEN N'Sắp hết'
            ELSE N'Còn hàng'
        END AS TrangThaiTonKho
    FROM Products p
    LEFT JOIN Units u ON p.BaseUnitID = u.UnitID
    LEFT JOIN ProductInventory pi ON p.ProductID = pi.ProductID
    WHERE p.TenSanPham LIKE '%' + @Keyword + '%'
    ORDER BY p.TenSanPham;
END
GO

-- 6. SP MỚI - Lấy thông tin 1 sản phẩm
IF OBJECT_ID('sp_GetProductByID', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetProductByID;
GO

CREATE PROCEDURE sp_GetProductByID
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        p.ProductID,
        p.TenSanPham,
        p.BaseUnitID,
        u.TenDVT AS BaseUnitName,
        p.TonKhoToiThieu,
        ISNULL(pi.SoLuongTon, 0) AS SoLuongTon
    FROM Products p
    LEFT JOIN Units u ON p.BaseUnitID = u.UnitID
    LEFT JOIN ProductInventory pi ON p.ProductID = pi.ProductID
    WHERE p.ProductID = @ProductID;
END
GO

-- ===================================================================
-- STORED PROCEDURES CHO QUẢN LÝ ĐƠN VỊ TÍNH
-- ===================================================================

-- 7. SP Lấy tất cả đơn vị tính
IF OBJECT_ID('sp_GetAllUnits', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllUnits;
GO

CREATE PROCEDURE sp_GetAllUnits
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT UnitID, TenDVT
    FROM Units
    ORDER BY TenDVT;
END
GO

-- 8. SP Lấy quy đổi đơn vị của sản phẩm
IF OBJECT_ID('sp_GetProductUnitConversions', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetProductUnitConversions;
GO

CREATE PROCEDURE sp_GetProductUnitConversions
    @ProductID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        puc.ConversionID,
        puc.ProductID,
        puc.UnitID,
        u.TenDVT AS UnitName,
        puc.GiaTriQuyDoi
    FROM ProductUnitConversions puc
    INNER JOIN Units u ON puc.UnitID = u.UnitID
    WHERE puc.ProductID = @ProductID
    ORDER BY puc.GiaTriQuyDoi;
END
GO

-- 9. SP Thêm quy đổi đơn vị
IF OBJECT_ID('sp_InsertUnitConversion', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertUnitConversion;
GO

CREATE PROCEDURE sp_InsertUnitConversion
    @ProductID INT,
    @UnitID INT,
    @GiaTriQuyDoi FLOAT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra đã tồn tại quy đổi này chưa
    IF EXISTS(SELECT 1 FROM ProductUnitConversions WHERE ProductID = @ProductID AND UnitID = @UnitID)
    BEGIN
        SET @Result = -2; -- Quy đổi đã tồn tại
        RETURN;
    END
    
    BEGIN TRY
        INSERT INTO ProductUnitConversions (ProductID, UnitID, GiaTriQuyDoi)
        VALUES (@ProductID, @UnitID, @GiaTriQuyDoi);
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 10. SP Cập nhật quy đổi
IF OBJECT_ID('sp_UpdateUnitConversion', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateUnitConversion;
GO

CREATE PROCEDURE sp_UpdateUnitConversion
    @ConversionID INT,
    @GiaTriQuyDoi FLOAT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    BEGIN TRY
        UPDATE ProductUnitConversions
        SET GiaTriQuyDoi = @GiaTriQuyDoi
        WHERE ConversionID = @ConversionID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 11. SP Xóa quy đổi
IF OBJECT_ID('sp_DeleteUnitConversion', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteUnitConversion;
GO

CREATE PROCEDURE sp_DeleteUnitConversion
    @ConversionID INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Không cho xóa quy đổi cơ sở (GiaTriQuyDoi = 1.0)
    IF EXISTS(SELECT 1 FROM ProductUnitConversions WHERE ConversionID = @ConversionID AND GiaTriQuyDoi = 1.0)
    BEGIN
        SET @Result = -3; -- Không thể xóa quy đổi cơ sở
        RETURN;
    END
    
    BEGIN TRY
        DELETE FROM ProductUnitConversions WHERE ConversionID = @ConversionID;
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO
------------------------------------------------
--===============================================
--=============================xxxxxxx============= 24-11 tien dinh
------------------------

-- Thêm cột SecurityQuestion và SecurityAnswer vào Users
ALTER TABLE Users
ADD SecurityQuestion NVARCHAR(255) NULL,
    SecurityAnswer NVARCHAR(255) NULL;

GO

-- Cập nhật câu hỏi bảo mật cho user admin (demo)
UPDATE Users
SET SecurityQuestion = N'Tên môn học?',
    SecurityAnswer = '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92' -- Hash của "123456"
where SecurityQuestion is null;
GO

-- Tạo Stored Procedure cho Forgot Password
IF OBJECT_ID('sp_VerifySecurityAnswer', 'P') IS NOT NULL
    DROP PROCEDURE sp_VerifySecurityAnswer;
GO
CREATE PROCEDURE sp_VerifySecurityAnswer
    @TenDangNhap VARCHAR(100),
    @SecurityAnswerHash VARCHAR(255),
    @Result INT OUTPUT,
    @SecurityQuestion NVARCHAR(255) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    SET @SecurityQuestion = NULL;
    
    DECLARE @StoredAnswerHash VARCHAR(255);
    
    -- Lấy câu hỏi và câu trả lời
    SELECT 
        @SecurityQuestion = SecurityQuestion,
        @StoredAnswerHash = SecurityAnswer
    FROM Users
    WHERE TenDangNhap = @TenDangNhap;
    
    -- Username không tồn tại
    IF @SecurityQuestion IS NULL
    BEGIN
        SET @Result = -1; -- User không tồn tại
        RETURN;
    END
    
    -- Kiểm tra câu trả lời
    IF @StoredAnswerHash = @SecurityAnswerHash
    BEGIN
        SET @Result = 0; -- Đúng
    END
    ELSE
    BEGIN
        SET @Result = -2; -- Sai câu trả lời
    END
END
GO

-- Tạo SP Reset Password
IF OBJECT_ID('sp_ResetPassword', 'P') IS NOT NULL
    DROP PROCEDURE sp_ResetPassword;
GO

CREATE PROCEDURE sp_ResetPassword
    @TenDangNhap VARCHAR(100),
    @NewPasswordHash VARCHAR(255),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra user tồn tại
    IF EXISTS(SELECT 1 FROM Users WHERE TenDangNhap = @TenDangNhap)
    BEGIN
        -- Reset password
        UPDATE Users
        SET MatKhauHash = @NewPasswordHash,
            IsLocked = 0,
            FailedLoginAttempts = 0
        WHERE TenDangNhap = @TenDangNhap;
        
        SET @Result = 0; -- Thành công
    END
    ELSE
    BEGIN
        SET @Result = -1; -- User không tồn tại
    END
END
GO

--- fix module Quản lý Sản phẩm
--...........................................
-- 1. DROP các SP cũ
IF OBJECT_ID('sp_InsertProduct', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertProduct;
IF OBJECT_ID('sp_UpdateProduct', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateProduct;
IF OBJECT_ID('sp_DeleteProduct', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteProduct;
IF OBJECT_ID('sp_SearchProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_SearchProducts;
IF OBJECT_ID('sp_GetAllProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllProducts;
GO