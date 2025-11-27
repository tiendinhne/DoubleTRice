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
