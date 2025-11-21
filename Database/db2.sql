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
DELETE FROM Users;
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