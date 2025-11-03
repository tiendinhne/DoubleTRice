YÊU CẦU
Ứng dụng quản lý cửa hàng bán gạo/ Chỉ sử dụng Visual C#, Sql server, ….

Các nghiệp vụ chung:
-	Đăng nhâp, đăng xuất, đổi mật khẩu, cấu hình hệ thống, các chức năng danh mục (thêm xoá sửa tìm kiếm cho những table ít thay đổi)



CẤU TRÚC REPO
DoubleTRice/
│
├── BLL/                     → Tầng xử lý nghiệp vụ
├── DAO/                     → Tầng truy cập dữ liệu (SQL)
├── DTO/                     → Các lớp mô hình dữ liệu (Data Transfer Object)
├── GUI/                     → Giao diện người dùng (WinForms)
│
├── Properties/              → Thông tin cấu hình project (assembly info, settings,…)
├── Resources/               → Tài nguyên (ảnh, icon,…)
│
├── vosk-model-vn-0.4/       → Mô hình nhận dạng giọng nói tiếng Việt
│
├── App.config               → File cấu hình (chuỗi kết nối database)
├── Program.cs               → Điểm khởi động chương trình
├── data.sql                 → File SQL tạo cơ sở dữ liệu
├── baocao.csproj            → File cấu hình dự án C#
├── baocao.sln               → File Solution mở bằng Visual Studio
└── .git*, .vs/, bin/, obj/  → Thư mục hệ thống, build, và Git
****
1. Tầng DTO (Data Transfer Object)
  Chứa các class mô tả dữ liệu của hệ thống.
  Giống như “bản vẽ” của từng bảng trong CSDL.
2. Tầng DAO (Data Access Object)
  Đây là tầng truy xuất dữ liệu – làm việc trực tiếp với SQL Server thông qua DataProvider.
3. Tầng BLL (Business Logic Layer)
  Xử lý logic nghiệp vụ giữa GUI và DAO.
4. Tầng GUI (Giao diện người dùng)
  Đây là WinForms Layer – chứa các Form .cs + .Designer.cs.
