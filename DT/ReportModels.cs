using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleTRice.DT
{
    /// <summary>
    /// DTO cho báo cáo doanh thu
    /// </summary>
    /// 
    public class RevenueReportItem
    {
        public DateTime Ngay { get; set; }
        public decimal TongDoanhThu { get; set; }
        public decimal TongGiaVon { get; set; }
        public decimal LoiNhuan { get; set; }
        public int SoHoaDon { get; set; }

        public decimal TyLeLoiNhuan => TongDoanhThu > 0
            ? (LoiNhuan / TongDoanhThu) * 100
            : 0;
    }



    public class ReportModels
    {
        
    }

    /// <summary>
    /// DTO cho báo cáo tồn kho
    /// </summary>
    public class InventoryReportItem
    {
        public int ProductID { get; set; }
        public string TenSanPham { get; set; }
        public string DonViTinh { get; set; }
        public double SoLuongTon { get; set; }
        public double TonKhoToiThieu { get; set; }
        public decimal GiaTriTonKho { get; set; }
        public string TrangThai { get; set; }

        public bool CanCanhBao => SoLuongTon <= TonKhoToiThieu;
    }

    /// <summary>
    /// DTO cho báo cáo công nợ khách hàng
    /// </summary>
    public class CustomerDebtReportItem
    {
        public int CustomerID { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public decimal TongMuaHang { get; set; }
        public decimal TongDaTra { get; set; }
        public decimal CongNo { get; set; }
        public int SoHoaDonChuaTra { get; set; }
    }

    /// <summary>
    /// DTO cho báo cáo công nợ nhà cung cấp
    /// </summary>
    public class SupplierDebtReportItem
    {
        public int SupplierID { get; set; }
        public string TenNhaCungCap { get; set; }
        public string SoDienThoai { get; set; }
        public decimal TongNhapHang { get; set; }
        public decimal TongDaTra { get; set; }
        public decimal CongNo { get; set; }
        public int SoPhieuNhapChuaTra { get; set; }
    }

    /// <summary>
    /// DTO tổng hợp cho dashboard
    /// </summary>
    public class DashboardSummary
    {
        public decimal TongDoanhThuThang { get; set; }
        public decimal TongLoiNhuanThang { get; set; }
        public decimal TongCongNoKhach { get; set; }
        public decimal TongCongNoNCC { get; set; }
        public int SoSanPhamSapHet { get; set; }
        public int TongSoHoaDon { get; set; }
    }


}
