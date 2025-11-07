using DoubleTRice.DT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DAO
{
    //internal class ProductDAO
    //{
    //}
    public class ProductDAO
    {
        // Singleton Pattern — chỉ tạo 1 đối tượng dùng chung
        private static ProductDAO instance;
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return instance;
            }
        }

        // constructor private để tránh tạo mới bên ngoài
        private ProductDAO() { }

        // 🟢 1️⃣ Lấy danh sách toàn bộ sản phẩm
        public List<Products> GetAllProducts()
        {
            string query = "EXEC sp_GetAllProducts";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            List<Products> list = new List<Products>();
            foreach (DataRow item in data.Rows)
                list.Add(new Products(item));

            return list;
        }

        public bool InsertProduct(string ten, int unitID, double tonKho)
        {
            string query = "EXEC sp_InsertProduct @TenSanPham, @BaseUnitID, @TonKhoToiThieu";
            object[] parameters = { ten, unitID, tonKho };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool UpdateProduct(int id, string ten, int unitID, double tonKho)
        {
            string query = "EXEC sp_UpdateProduct @ProductID, @TenSanPham, @BaseUnitID, @TonKhoToiThieu";
            object[] parameters = { id, ten, unitID, tonKho };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public bool DeleteProduct(int id)
        {
            string query = "EXEC sp_DeleteProduct @ProductID";
            object[] parameters = { id };
            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }

        public List<Products> SearchProducts(string keyword)
        {
            string query = "EXEC sp_SearchProducts @Keyword";
            object[] parameters = { keyword };
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            List<Products> list = new List<Products>();
            foreach (DataRow item in data.Rows)
                list.Add(new Products(item));

            return list;
        }

    }
}
