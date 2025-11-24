using DoubleTRice.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoubleTRice.DT;

namespace DoubleTRice
{
    internal class testDAO
    {
        public static void runtest()
        {
            try
            {
                MessageBox.Show("Bắt đầu test ProductDAO...", "Thông báo");

                // 1️⃣ Test đọc danh sách
                var list = ProductDAO.Instance.GetAllProductsDetail();
                string result = "Danh sách sản phẩm hiện có:\n";
                foreach (var p in list)
                {
                    result += $"{p.ProductID}: {p.TenSanPham} - Tồn kho tối thiểu: {p.TonKhoToiThieu}\n";
                }
                MessageBox.Show(result, "Test GetAllProducts()");

                // 2️⃣ Test thêm mới
                //bool insert = ProductDAO.Instance.InsertProduct("Gạo Test", 1, 10);
                //MessageBox.Show(insert ? "✅ Thêm sản phẩm thành công!" : "❌ Thêm sản phẩm thất bại!", "Test InsertProduct()");

                // 3️⃣ Test cập nhật
                var last = ProductDAO.Instance.GetAllProductsDetail();
                var lastProduct = last[last.Count - 1];
                //bool update = ProductDAO.Instance.UpdateProduct(lastProduct.ProductID, "Gạo Test Updated", 1, 15);
                //MessageBox.Show(update ? "✅ Cập nhật sản phẩm thành công!" : "❌ Cập nhật thất bại!", "Test UpdateProduct()");

                // 4️⃣ Test tìm kiếm
                var found = ProductDAO.Instance.SearchProducts("Test");
                string foundText = "Kết quả tìm kiếm:\n";
                foreach (var p in found)
                {
                    foundText += $"{p.ProductID}: {p.TenSanPham}\n";
                }
                MessageBox.Show(foundText, "Test SearchProducts()");

                // 5️⃣ Test xóa
                //bool delete = ProductDAO.Instance.DeleteProduct(lastProduct.ProductID);
                //MessageBox.Show(delete ? "✅ Xóa sản phẩm thành công!" : "❌ Xóa sản phẩm thất bại!", "Test DeleteProduct()");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi test ProductDAO: " + ex.Message);
            }
        }
    }

}
