YÊU CẦU
Ứng dụng quản lý cửa hàng bán gạo/ Chỉ sử dụng Visual C#, Sql server, ….

Các nghiệp vụ chung:
-	Đăng nhâp, đăng xuất, đổi mật khẩu, cấu hình hệ thống, các chức năng danh mục (thêm xoá sửa tìm kiếm cho những table ít thay đổi)


1. Tầng DTO (Data Transfer Object)
  Chứa các class mô tả dữ liệu của hệ thống.
  Giống như “bản vẽ” của từng bảng trong CSDL.
2. Tầng DAO (Data Access Object)
  Đây là tầng truy xuất dữ liệu – làm việc trực tiếp với SQL Server thông qua DataProvider.
3. Tầng BLL (Business Logic Layer)
  Xử lý logic nghiệp vụ giữa GUI và DAO.
4. Tầng GUI (Giao diện người dùng)
  Đây là WinForms Layer – chứa các Form .cs + .Designer.cs.
