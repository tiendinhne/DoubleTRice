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



CREATE TABLE  (
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
--select * from ProductUnitConversions 

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
--=============================xxxxxxx============= 24-11 tien dinh cho forgotpassword
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


-- ===================================================================
-- STORED PROCEDURES CHO QUẢN LÝ NHÀ CUNG CẤP & KHÁCH HÀNG
-- By:  - Date: 26/11/2025
-- ===================================================================

-- ===================================================================
-- PHẦN 1: NHÀ CUNG CẤP (SUPPLIERS)
-- ===================================================================

-- 1. Lấy tất cả nhà cung cấp
IF OBJECT_ID('sp_GetAllSuppliers', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllSuppliers;
GO

CREATE PROCEDURE sp_GetAllSuppliers
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        SupplierID,
        TenNhaCungCap,
        SoDienThoai,
        DiaChi
    FROM Suppliers
    ORDER BY TenNhaCungCap;
END
GO

-- 2. Lấy 1 nhà cung cấp theo ID
IF OBJECT_ID('sp_GetSupplierByID', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetSupplierByID;
GO

CREATE PROCEDURE sp_GetSupplierByID
    @SupplierID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        SupplierID,
        TenNhaCungCap,
        SoDienThoai,
        DiaChi
    FROM Suppliers
    WHERE SupplierID = @SupplierID;
END
GO

-- 3. Thêm nhà cung cấp mới
IF OBJECT_ID('sp_InsertSupplier', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertSupplier;
GO

CREATE PROCEDURE sp_InsertSupplier
    @TenNhaCungCap NVARCHAR(255),
    @SoDienThoai VARCHAR(20),
    @DiaChi NVARCHAR(500),
    @Result INT OUTPUT,
    @NewSupplierID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    SET @NewSupplierID = 0;
    
    -- Validate: Tên không được trống
    IF LTRIM(RTRIM(ISNULL(@TenNhaCungCap, ''))) = ''
    BEGIN
        SET @Result = -2; -- Tên trống
        RETURN;
    END
    
    -- Kiểm tra tên đã tồn tại chưa
    IF EXISTS(SELECT 1 FROM Suppliers WHERE TenNhaCungCap = @TenNhaCungCap)
    BEGIN
        SET @Result = -3; -- Tên đã tồn tại
        RETURN;
    END
    
    BEGIN TRY
        INSERT INTO Suppliers (TenNhaCungCap, SoDienThoai, DiaChi)
        VALUES (@TenNhaCungCap, @SoDienThoai, @DiaChi);
        
        SET @NewSupplierID = SCOPE_IDENTITY();
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 4. Cập nhật nhà cung cấp
IF OBJECT_ID('sp_UpdateSupplier', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateSupplier;
GO

CREATE PROCEDURE sp_UpdateSupplier
    @SupplierID INT,
    @TenNhaCungCap NVARCHAR(255),
    @SoDienThoai VARCHAR(20),
    @DiaChi NVARCHAR(500),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra tồn tại
    IF NOT EXISTS(SELECT 1 FROM Suppliers WHERE SupplierID = @SupplierID)
    BEGIN
        SET @Result = -1; -- Không tồn tại
        RETURN;
    END
    
    -- Validate tên
    IF LTRIM(RTRIM(ISNULL(@TenNhaCungCap, ''))) = ''
    BEGIN
        SET @Result = -2; -- Tên trống
        RETURN;
    END
    
    -- Kiểm tra tên trùng (trừ chính nó)
    IF EXISTS(SELECT 1 FROM Suppliers 
              WHERE TenNhaCungCap = @TenNhaCungCap 
              AND SupplierID != @SupplierID)
    BEGIN
        SET @Result = -3; -- Tên đã tồn tại
        RETURN;
    END
    
    BEGIN TRY
        UPDATE Suppliers
        SET TenNhaCungCap = @TenNhaCungCap,
            SoDienThoai = @SoDienThoai,
            DiaChi = @DiaChi
        WHERE SupplierID = @SupplierID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 5. Xóa nhà cung cấp
IF OBJECT_ID('sp_DeleteSupplier', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteSupplier;
GO

CREATE PROCEDURE sp_DeleteSupplier
    @SupplierID INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra tồn tại
    IF NOT EXISTS(SELECT 1 FROM Suppliers WHERE SupplierID = @SupplierID)
    BEGIN
        SET @Result = -1; -- Không tồn tại
        RETURN;
    END
    
    -- Kiểm tra có phiếu nhập liên quan không
    IF EXISTS(SELECT 1 FROM GoodsReceipts WHERE SupplierID = @SupplierID)
    BEGIN
        SET @Result = -4; -- Có giao dịch liên quan
        RETURN;
    END
    
    BEGIN TRY
        DELETE FROM Suppliers WHERE SupplierID = @SupplierID;
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 6. Tìm kiếm nhà cung cấp
IF OBJECT_ID('sp_SearchSuppliers', 'P') IS NOT NULL
    DROP PROCEDURE sp_SearchSuppliers;
GO

CREATE PROCEDURE sp_SearchSuppliers
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        SupplierID,
        TenNhaCungCap,
        SoDienThoai,
        DiaChi
    FROM Suppliers
    WHERE TenNhaCungCap LIKE '%' + @Keyword + '%'
       OR SoDienThoai LIKE '%' + @Keyword + '%'
       OR DiaChi LIKE '%' + @Keyword + '%'
    ORDER BY TenNhaCungCap;
END
GO

-- ===================================================================
-- PHẦN 2: KHÁCH HÀNG (CUSTOMERS)
-- ===================================================================

-- 1. Lấy tất cả khách hàng
IF OBJECT_ID('sp_GetAllCustomers', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetAllCustomers;
GO

CREATE PROCEDURE sp_GetAllCustomers
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CustomerID,
        TenKhachHang,
        SoDienThoai,
        DiaChi
    FROM Customers
    ORDER BY TenKhachHang;
END
GO

-- 2. Lấy 1 khách hàng theo ID
IF OBJECT_ID('sp_GetCustomerByID', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetCustomerByID;
GO

CREATE PROCEDURE sp_GetCustomerByID
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CustomerID,
        TenKhachHang,
        SoDienThoai,
        DiaChi
    FROM Customers
    WHERE CustomerID = @CustomerID;
END
GO

-- 3. Thêm khách hàng mới
IF OBJECT_ID('sp_InsertCustomer', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertCustomer;
GO

CREATE PROCEDURE sp_InsertCustomer
    @TenKhachHang NVARCHAR(255),
    @SoDienThoai VARCHAR(20),
    @DiaChi NVARCHAR(500),
    @Result INT OUTPUT,
    @NewCustomerID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    SET @NewCustomerID = 0;
    
    -- Validate tên
    IF LTRIM(RTRIM(ISNULL(@TenKhachHang, ''))) = ''
    BEGIN
        SET @Result = -2; -- Tên trống
        RETURN;
    END
    
    -- Kiểm tra tên đã tồn tại (trừ "Khách vãng lai")
    IF EXISTS(SELECT 1 FROM Customers 
              WHERE TenKhachHang = @TenKhachHang 
              AND TenKhachHang != N'Khách vãng lai')
    BEGIN
        SET @Result = -3; -- Tên đã tồn tại
        RETURN;
    END
    
    BEGIN TRY
        INSERT INTO Customers (TenKhachHang, SoDienThoai, DiaChi)
        VALUES (@TenKhachHang, @SoDienThoai, @DiaChi);
        
        SET @NewCustomerID = SCOPE_IDENTITY();
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 4. Cập nhật khách hàng
IF OBJECT_ID('sp_UpdateCustomer', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateCustomer;
GO

CREATE PROCEDURE sp_UpdateCustomer
    @CustomerID INT,
    @TenKhachHang NVARCHAR(255),
    @SoDienThoai VARCHAR(20),
    @DiaChi NVARCHAR(500),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra tồn tại
    IF NOT EXISTS(SELECT 1 FROM Customers WHERE CustomerID = @CustomerID)
    BEGIN
        SET @Result = -1; -- Không tồn tại
        RETURN;
    END
    
    -- Không cho sửa "Khách vãng lai"
    IF EXISTS(SELECT 1 FROM Customers 
              WHERE CustomerID = @CustomerID 
              AND TenKhachHang = N'Khách vãng lai')
    BEGIN
        SET @Result = -5; -- Không thể sửa khách vãng lai
        RETURN;
    END
    
    -- Validate tên
    IF LTRIM(RTRIM(ISNULL(@TenKhachHang, ''))) = ''
    BEGIN
        SET @Result = -2; -- Tên trống
        RETURN;
    END
    
    -- Kiểm tra tên trùng
    IF EXISTS(SELECT 1 FROM Customers 
              WHERE TenKhachHang = @TenKhachHang 
              AND CustomerID != @CustomerID)
    BEGIN
        SET @Result = -3; -- Tên đã tồn tại
        RETURN;
    END
    
    BEGIN TRY
        UPDATE Customers
        SET TenKhachHang = @TenKhachHang,
            SoDienThoai = @SoDienThoai,
            DiaChi = @DiaChi
        WHERE CustomerID = @CustomerID;
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 5. Xóa khách hàng
IF OBJECT_ID('sp_DeleteCustomer', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteCustomer;
GO

CREATE PROCEDURE sp_DeleteCustomer
    @CustomerID INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Kiểm tra tồn tại
    IF NOT EXISTS(SELECT 1 FROM Customers WHERE CustomerID = @CustomerID)
    BEGIN
        SET @Result = -1; -- Không tồn tại
        RETURN;
    END
    
    -- Không cho xóa "Khách vãng lai"
    IF EXISTS(SELECT 1 FROM Customers 
              WHERE CustomerID = @CustomerID 
              AND TenKhachHang = N'Khách vãng lai')
    BEGIN
        SET @Result = -5; -- Không thể xóa khách vãng lai
        RETURN;
    END
    
    -- Kiểm tra có hóa đơn liên quan không
    IF EXISTS(SELECT 1 FROM SalesInvoices WHERE CustomerID = @CustomerID)
    BEGIN
        SET @Result = -4; -- Có giao dịch liên quan
        RETURN;
    END
    
    BEGIN TRY
        DELETE FROM Customers WHERE CustomerID = @CustomerID;
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- 6. Tìm kiếm khách hàng
IF OBJECT_ID('sp_SearchCustomers', 'P') IS NOT NULL
    DROP PROCEDURE sp_SearchCustomers;
GO

CREATE PROCEDURE sp_SearchCustomers
    @Keyword NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        CustomerID,
        TenKhachHang,
        SoDienThoai,
        DiaChi
    FROM Customers
    WHERE TenKhachHang LIKE '%' + @Keyword + '%'
       OR SoDienThoai LIKE '%' + @Keyword + '%'
       OR DiaChi LIKE '%' + @Keyword + '%'
    ORDER BY TenKhachHang;
END
GO


-- ===================================================================
-- STORED PROCEDURES CHO QUẢN LÝ HÓA ĐƠN BÁN HÀNG
-- Date: 01/12/2025 by tiendinh 
-- ===================================================================

USE QuanLyBanGao;
GO

-- ===================================================================
-- 1. SP LẤY TẤT CẢ HÓA ĐƠN THEO KHOẢNG THỜI GIAN
-- ===================================================================
IF OBJECT_ID('sp_GetSalesInvoicesByDateRange', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetSalesInvoicesByDateRange;
GO
EXEC sp_GetSalesInvoicesByDateRange 
    @StartDate = '2025-12-01', 
    @EndDate = '2025-12-31'

CREATE PROCEDURE sp_GetSalesInvoicesByDateRange
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        InvoiceID,
        MaHoaDon,
        CustomerID,
        UserID,
        NgayBan,
        TongTien
    FROM SalesInvoices
    WHERE CONVERT(DATE, NgayBan) BETWEEN @StartDate AND @EndDate
    ORDER BY NgayBan DESC;
END
GO

-- ===================================================================
-- 2. SP LẤY CHI TIẾT HÓA ĐƠN THEO ID
-- ===================================================================
IF OBJECT_ID('sp_GetSalesInvoiceByID', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetSalesInvoiceByID;
GO

CREATE PROCEDURE sp_GetSalesInvoiceByID
    @InvoiceID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Lấy thông tin header
    SELECT 
        InvoiceID,
        MaHoaDon,
        CustomerID,
        UserID,
        NgayBan,
        TongTien
    FROM SalesInvoices
    WHERE InvoiceID = @InvoiceID;
    
    -- Lấy chi tiết
    SELECT 
        InvoiceDetailID,
        InvoiceID,
        ProductID,
        UnitID,
        SoLuong,
        DonGiaBan,
        ThanhTien
    FROM SalesInvoiceDetails
    WHERE InvoiceID = @InvoiceID;
END
GO

-- ===================================================================
-- 3. SP TẠO HÓA ĐƠN MỚI (TRANSACTION)
-- ===================================================================
IF OBJECT_ID('sp_InsertSalesInvoice', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertSalesInvoice;
GO

CREATE PROCEDURE sp_InsertSalesInvoice
    @CustomerID INT,
    @UserID INT,
    @TongTien DECIMAL(18,2),
    @Details NVARCHAR(MAX), -- JSON string: [{"ProductID":1,"UnitID":1,"SoLuong":2,"DonGiaBan":25000}]
    @Result INT OUTPUT,
    @NewInvoiceID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    
    SET @Result = -1;
    SET @NewInvoiceID = 0;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. Insert Invoice Header
        INSERT INTO SalesInvoices (CustomerID, UserID, NgayBan, TongTien)
        VALUES (@CustomerID, @UserID, GETDATE(), @TongTien);
        
        SET @NewInvoiceID = SCOPE_IDENTITY();
        
        -- 2. Parse JSON và insert details
        DECLARE @ProductID INT, @UnitID INT, @SoLuong FLOAT, @DonGiaBan DECIMAL(18,2);
        DECLARE @GiaTriQuyDoi FLOAT, @SoLuongTon FLOAT;
        
        -- Tạo temp table để lưu details từ JSON
        CREATE TABLE #TempDetails (
            ProductID INT,
            UnitID INT,
            SoLuong FLOAT,
            DonGiaBan DECIMAL(18,2)
        );
        
        -- Parse JSON (SQL Server 2016+)
        INSERT INTO #TempDetails (ProductID, UnitID, SoLuong, DonGiaBan)
        SELECT 
            JSON_VALUE(value, '$.ProductID'),
            JSON_VALUE(value, '$.UnitID'),
            JSON_VALUE(value, '$.SoLuong'),
            JSON_VALUE(value, '$.DonGiaBan')
        FROM OPENJSON(@Details);
        
        -- 3. Validate tồn kho và insert details
        DECLARE detail_cursor CURSOR FOR 
        SELECT ProductID, UnitID, SoLuong, DonGiaBan FROM #TempDetails;
        
        OPEN detail_cursor;
        FETCH NEXT FROM detail_cursor INTO @ProductID, @UnitID, @SoLuong, @DonGiaBan;
        
        WHILE @@FETCH_STATUS = 0
        BEGIN
            -- Lấy giá trị quy đổi
            SELECT @GiaTriQuyDoi = GiaTriQuyDoi 
            FROM ProductUnitConversions 
            WHERE ProductID = @ProductID AND UnitID = @UnitID;
            
            IF @GiaTriQuyDoi IS NULL
            BEGIN
                SET @Result = -3; -- Không tìm thấy quy đổi
                ROLLBACK TRANSACTION;
                RETURN;
            END
            
            -- Kiểm tra tồn kho
            SELECT @SoLuongTon = SoLuongTon 
            FROM ProductInventory 
            WHERE ProductID = @ProductID;
            
            IF @SoLuongTon < (@SoLuong * @GiaTriQuyDoi)
            BEGIN
                SET @Result = -4; -- Không đủ hàng
                ROLLBACK TRANSACTION;
                RETURN;
            END
            
            -- Insert detail
            INSERT INTO SalesInvoiceDetails (InvoiceID, ProductID, UnitID, SoLuong, DonGiaBan)
            VALUES (@NewInvoiceID, @ProductID, @UnitID, @SoLuong, @DonGiaBan);
            
            FETCH NEXT FROM detail_cursor INTO @ProductID, @UnitID, @SoLuong, @DonGiaBan;
        END
        
        CLOSE detail_cursor;
        DEALLOCATE detail_cursor;
        DROP TABLE #TempDetails;
        
        -- 4. Trigger sẽ tự động trừ kho (đã có sẵn: trg_UpdateStockOnSale)
        
        COMMIT TRANSACTION;
        SET @Result = 0; -- Thành công
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- ===================================================================
-- 4. SP XÓA HÓA ĐƠN (CHỈ TRONG NGÀY)
-- ===================================================================
IF OBJECT_ID('sp_DeleteSalesInvoice', 'P') IS NOT NULL
    DROP PROCEDURE sp_DeleteSalesInvoice;
GO

CREATE PROCEDURE sp_DeleteSalesInvoice
    @InvoiceID INT,
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    
    SET @Result = -1;
    
    DECLARE @NgayBan DATETIME;
    
    -- Kiểm tra hóa đơn tồn tại
    SELECT @NgayBan = NgayBan
    FROM SalesInvoices
    WHERE InvoiceID = @InvoiceID;
    
    IF @NgayBan IS NULL
    BEGIN
        SET @Result = -1; -- Không tồn tại
        RETURN;
    END
    
    -- Chỉ cho phép xóa trong ngày
    IF CONVERT(DATE, @NgayBan) != CONVERT(DATE, GETDATE())
    BEGIN
        SET @Result = -2; -- Quá thời gian cho phép
        RETURN;
    END
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- 1. Cộng lại kho (reverse trigger effect)
        UPDATE pi
        SET pi.SoLuongTon = pi.SoLuongTon + (sid.SoLuong * puc.GiaTriQuyDoi)
        FROM ProductInventory pi
        INNER JOIN SalesInvoiceDetails sid ON pi.ProductID = sid.ProductID
        INNER JOIN ProductUnitConversions puc ON sid.ProductID = puc.ProductID 
            AND sid.UnitID = puc.UnitID
        WHERE sid.InvoiceID = @InvoiceID;
        
        -- 2. Xóa details
        DELETE FROM SalesInvoiceDetails WHERE InvoiceID = @InvoiceID;
        
        -- 3. Xóa payments
        DELETE FROM CustomerPayments WHERE InvoiceID = @InvoiceID;
        
        -- 4. Xóa invoice
        DELETE FROM SalesInvoices WHERE InvoiceID = @InvoiceID;
        
        COMMIT TRANSACTION;
        SET @Result = 0; -- Thành công
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- ===================================================================
-- 5. SP TÍNH CÔNG NỢ KHÁCH HÀNG
-- ===================================================================
IF OBJECT_ID('sp_GetCustomerDebt', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetCustomerDebt;
GO

CREATE PROCEDURE sp_GetCustomerDebt
    @CustomerID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Tổng tiền hàng đã mua
    DECLARE @TongMuaHang DECIMAL(18,2) = 0;
    SELECT @TongMuaHang = ISNULL(SUM(TongTien), 0)
    FROM SalesInvoices
    WHERE CustomerID = @CustomerID;
    
    -- Tổng tiền đã trả
    DECLARE @TongDaTra DECIMAL(18,2) = 0;
    SELECT @TongDaTra = ISNULL(SUM(SoTien), 0)
    FROM CustomerPayments
    WHERE CustomerID = @CustomerID;
    
    -- Công nợ hiện tại
    SELECT 
        @CustomerID AS CustomerID,
        @TongMuaHang AS TongMuaHang,
        @TongDaTra AS TongDaTra,
        (@TongMuaHang - @TongDaTra) AS CongNoHienTai;
END
GO

-- ===================================================================
-- 6. SP TRẢ NỢ
-- ===================================================================
IF OBJECT_ID('sp_InsertCustomerPayment', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertCustomerPayment;
GO

CREATE PROCEDURE sp_InsertCustomerPayment
    @CustomerID INT,
    @InvoiceID INT,
    @SoTien DECIMAL(18,2),
    @PhuongThuc NVARCHAR(100),
    @Result INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    SET @Result = -1;
    
    -- Validate
    IF @SoTien <= 0
    BEGIN
        SET @Result = -2; -- Số tiền không hợp lệ
        RETURN;
    END
    
    BEGIN TRY
        INSERT INTO CustomerPayments (CustomerID, InvoiceID, NgayThanhToan, SoTien, PhuongThuc)
        VALUES (@CustomerID, @InvoiceID, GETDATE(), @SoTien, @PhuongThuc);
        
        SET @Result = 0; -- Thành công
    END TRY
    BEGIN CATCH
        SET @Result = -99; -- Lỗi hệ thống
    END CATCH
END
GO

-- ===================================================================
-- 7. SP KIỂM TRA TỒN KHO TRƯỚC KHI BÁN
-- ===================================================================
IF OBJECT_ID('sp_CheckStockAvailability', 'P') IS NOT NULL
    DROP PROCEDURE sp_CheckStockAvailability;
GO

CREATE PROCEDURE sp_CheckStockAvailability
    @ProductID INT,
    @UnitID INT,
    @SoLuong FLOAT,
    @IsAvailable BIT OUTPUT,
    @SoLuongTonHienTai FLOAT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @GiaTriQuyDoi FLOAT;
    
    -- Lấy quy đổi
    SELECT @GiaTriQuyDoi = GiaTriQuyDoi
    FROM ProductUnitConversions
    WHERE ProductID = @ProductID AND UnitID = @UnitID;
    
    IF @GiaTriQuyDoi IS NULL
    BEGIN
        SET @IsAvailable = 0;
        SET @SoLuongTonHienTai = 0;
        RETURN;
    END
    
    -- Lấy tồn kho hiện tại
    SELECT @SoLuongTonHienTai = SoLuongTon
    FROM ProductInventory
    WHERE ProductID = @ProductID;
    
    -- So sánh
    IF @SoLuongTonHienTai >= (@SoLuong * @GiaTriQuyDoi)
        SET @IsAvailable = 1;
    ELSE
        SET @IsAvailable = 0;
END
GO

-- ===================================================================
-- 8. SP BỔ SUNG: LẤY GIÁ BÁN HIỆN TẠI CỦA SẢN PHẨM
-- ===================================================================
IF OBJECT_ID('sp_GetCurrentPrice', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetCurrentPrice;
GO

CREATE PROCEDURE sp_GetCurrentPrice
    @ProductID INT,
    @UnitID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT TOP 1 GiaBan
    FROM PriceList
    WHERE ProductID = @ProductID AND UnitID = @UnitID
    ORDER BY NgayApDung DESC;
END
GO

--PRINT '✅ STORED PROCEDURES CHO BÁN HÀNG ĐÃ ĐƯỢC TẠO THÀNH CÔNG!';



-- Test kiểm tra tồn kho
DECLARE @IsAvailable BIT, @TonHienTai FLOAT;

EXEC sp_CheckStockAvailability 
    @ProductID = 21,
    @UnitID = 1,
    @SoLuong = 2,
    @IsAvailable = @IsAvailable OUTPUT,
    @SoLuongTonHienTai = @TonHienTai OUTPUT;

SELECT @IsAvailable AS DuHang, @TonHienTai AS TonKho;

select * from Units
select * from ProductUnitConversions
select * from Products

select * from Pricelist

-- ===================================================================
-- Stored Procedure: Cập nhật Tổng tiền Phiếu nhập
-- ===================================================================
IF OBJECT_ID('sp_UpdateGoodsReceiptTotalAmount', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdateGoodsReceiptTotalAmount;
GO

CREATE PROCEDURE sp_UpdateGoodsReceiptTotalAmount
    @ReceiptID INT
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @TongTien DECIMAL(18, 2);
    
    -- Tính tổng từ chi tiết
    SELECT @TongTien = SUM(ThanhTien)
    FROM GoodsReceiptDetails
    WHERE ReceiptID = @ReceiptID;
    
    -- Cập nhật vào phiếu nhập
    UPDATE GoodsReceipts
    SET TongTien = ISNULL(@TongTien, 0)
    WHERE ReceiptID = @ReceiptID;
    
    -- Debug
    PRINT 'Updated ReceiptID: ' + CAST(@ReceiptID AS VARCHAR) + 
          ', TongTien: ' + CAST(ISNULL(@TongTien, 0) AS VARCHAR);
END
GO

-- ===================================================================
-- TRIGGER TỰ ĐỘNG CẬP NHẬT GIÁ BÁN KHI NHẬP HÀNG
-- Date: 02/12/2025
-- ===================================================================

USE QuanLyBanGao;
GO

-- ===================================================================
-- 1. DROP TRIGGER CŨ (NẾU CÓ)
-- ===================================================================
IF OBJECT_ID('trg_AutoUpdatePriceList', 'TR') IS NOT NULL
    DROP TRIGGER trg_AutoUpdatePriceList;
GO

-- ===================================================================
-- 2. TẠO TRIGGER MỚI
-- ===================================================================
CREATE TRIGGER trg_AutoUpdatePriceList
ON GoodsReceiptDetails
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Biến cấu hình markup (%)
    DECLARE @MarkupPercent FLOAT = 0.20; -- 20% lợi nhuận
    
    -- Duyệt qua từng dòng vừa insert
    DECLARE @ProductID INT, @UnitID INT, @DonGiaNhap DECIMAL(18,2);
    DECLARE @GiaBan DECIMAL(18,2);
    
    DECLARE detail_cursor CURSOR FOR 
    SELECT 
        i.ProductID, 
        i.UnitID, 
        i.DonGiaNhap
    FROM inserted i;
    
    OPEN detail_cursor;
    FETCH NEXT FROM detail_cursor INTO @ProductID, @UnitID, @DonGiaNhap;
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Tính giá bán = Giá nhập × (1 + markup)
        SET @GiaBan = @DonGiaNhap * (1 + @MarkupPercent);
        
        -- Làm tròn đến hàng nghìn (tùy chọn)
        SET @GiaBan = ROUND(@GiaBan / 1000, 0) * 1000;
        
        -- Kiểm tra đã có giá chưa
        IF EXISTS (
            SELECT 1 FROM PriceList 
            WHERE ProductID = @ProductID AND UnitID = @UnitID
        )
        BEGIN
            -- UPDATE giá cũ (nếu giá mới cao hơn)
            UPDATE PriceList
            SET GiaBan = @GiaBan,
                NgayApDung = GETDATE()
            WHERE ProductID = @ProductID 
              AND UnitID = @UnitID
              AND @GiaBan > GiaBan; -- Chỉ update nếu giá mới cao hơn
        END
        ELSE
        BEGIN
            -- INSERT giá mới
            INSERT INTO PriceList (ProductID, UnitID, GiaBan, NgayApDung)
            VALUES (@ProductID, @UnitID, @GiaBan, GETDATE());
        END
        
        FETCH NEXT FROM detail_cursor INTO @ProductID, @UnitID, @DonGiaNhap;
    END
    
    CLOSE detail_cursor;
    DEALLOCATE detail_cursor;
END
GO
/*
PRINT '✅ Trigger trg_AutoUpdatePriceList đã được tạo thành công!';
PRINT '';
PRINT '📌 Cách hoạt động:';
PRINT '1. Khi nhập hàng với giá 20,000đ/kg';
PRINT '2. Trigger tự động tính giá bán = 20,000 × 1.2 = 24,000đ';
PRINT '3. Tự động INSERT/UPDATE vào bảng PriceList';
PRINT '4. POS sẽ lấy giá này khi bán hàng';
PRINT '';
PRINT '⚙️ Cấu hình markup: 20% (có thể thay đổi trong trigger)';
GO */

-- ===================================================================
-- 3. STORED PROCEDURE: CẬP NHẬT GIÁ CHO SẢN PHẨM CŨ (MANUAL) - SQL SERVER
-- ===================================================================
IF OBJECT_ID('sp_UpdatePriceFromLastPurchase', 'P') IS NOT NULL
    DROP PROCEDURE sp_UpdatePriceFromLastPurchase;
GO

CREATE PROCEDURE sp_UpdatePriceFromLastPurchase
    @ProductID INT = NULL -- NULL = update tất cả sản phẩm
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @MarkupPercent FLOAT = 0.20;

    ;WITH LatestPurchase AS (
        SELECT 
            grd.ProductID,
            grd.UnitID,
            grd.DonGiaNhap,
            ROW_NUMBER() OVER (
                PARTITION BY grd.ProductID, grd.UnitID
                ORDER BY gr.NgayNhap DESC
            ) AS rn
        FROM GoodsReceiptDetails grd
        INNER JOIN GoodsReceipts gr 
            ON grd.ReceiptID = gr.ReceiptID
        WHERE (@ProductID IS NULL OR grd.ProductID = @ProductID)
    )
    MERGE PriceList AS target
    USING (
        SELECT 
            ProductID,
            UnitID,
            ROUND(DonGiaNhap * (1 + @MarkupPercent) / 1000, 0) * 1000 AS GiaBan,
            GETDATE() AS NgayApDung
        FROM LatestPurchase
        WHERE rn = 1
    ) AS src
    ON target.ProductID = src.ProductID 
       AND target.UnitID = src.UnitID
    WHEN MATCHED THEN
        UPDATE SET 
            GiaBan = src.GiaBan,
            NgayApDung = src.NgayApDung
    WHEN NOT MATCHED THEN
        INSERT (ProductID, UnitID, GiaBan, NgayApDung)
        VALUES (src.ProductID, src.UnitID, src.GiaBan, src.NgayApDung);

    PRINT '✅ Đã cập nhật giá bán từ phiếu nhập gần nhất!';
END
GO


-- ===================================================================
-- 4. TEST TRIGGER
-- ===================================================================
/*
-- Test: Thêm 1 phiếu nhập mới
INSERT INTO GoodsReceipts (SupplierID, UserID, NgayNhap, TongTien)
VALUES (1, 1, GETDATE(), 0);

DECLARE @ReceiptID INT = SCOPE_IDENTITY();

-- Thêm chi tiết (giá nhập 20,000đ)
INSERT INTO GoodsReceiptDetails (ReceiptID, ProductID, UnitID, SoLuong, DonGiaNhap)
VALUES (@ReceiptID, 1, 1, 10, 20000);

-- Kiểm tra PriceList (phải có giá bán = 24,000đ)
SELECT * FROM PriceList WHERE ProductID = 1;
*/

-- ===================================================================
-- 5. CẬP NHẬT GIÁ CHO DỮ LIỆU CŨ (CHẠY 1 LẦN)
-- ===================================================================

-- Cập nhật giá cho TẤT CẢ sản phẩm từ phiếu nhập gần nhất
--EXEC sp_UpdatePriceFromLastPurchase;

-- Hoặc cập nhật cho 1 sản phẩm cụ thể
--EXEC sp_UpdatePriceFromLastPurchase @ProductID = 1;

-- Xem giá bán đã được tạo chưa
/*SELECT 
    p.TenSanPham,
    u.TenDVT,
    pl.GiaBan,
    pl.NgayApDung
FROM PriceList pl
INNER JOIN Products p ON pl.ProductID = p.ProductID
INNER JOIN Units u ON pl.UnitID = u.UnitID
ORDER BY p.TenSanPham; */