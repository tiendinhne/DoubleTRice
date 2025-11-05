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