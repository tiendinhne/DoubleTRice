using DoubleTRice.DAO;
using DoubleTRice.DT;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.IO;
using System.Linq;

namespace DoubleTRice.LOGIC
{
    /// <summary>
    /// Class tạo hóa đơn PDF cho hệ thống bán gạo
    /// </summary>
    public class InvoicePDFGenerator
    {
        #region Constants - Thông tin cửa hàng
        private const string SHOP_NAME = "DoubleTRice";
        private const string SHOP_ADDRESS = "19, Nguyễn Hữu Thọ, Tân Phong, Quận 7, TP.HCM";
        private const string SHOP_PHONE = "0987654321";
        #endregion

        #region Fonts - Hỗ trợ tiếng Việt
        private static BaseFont baseFont;
        private static Font fontTitle;
        private static Font fontHeader;
        private static Font fontNormal;
        private static Font fontBold;
        private static Font fontSmall;

        static InvoicePDFGenerator()
        {
            try
            {
                // Sử dụng font Arial hỗ trợ tiếng Việt
                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                fontTitle = new Font(baseFont, 20, Font.BOLD, BaseColor.BLACK);
                fontHeader = new Font(baseFont, 14, Font.BOLD, BaseColor.BLACK);
                fontNormal = new Font(baseFont, 11, Font.NORMAL, BaseColor.BLACK);
                fontBold = new Font(baseFont, 11, Font.BOLD, BaseColor.BLACK);
                fontSmall = new Font(baseFont, 9, Font.NORMAL, BaseColor.GRAY);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading fonts: {ex.Message}");
                // Fallback to default fonts
                fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);
                fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11);
                fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
                fontSmall = FontFactory.GetFont(FontFactory.HELVETICA, 9);
            }
        }
        #endregion

        #region Main Methods

        /// <summary>
        /// Tạo file PDF hóa đơn và tự động mở
        /// </summary>
        /// <param name="invoiceID">ID hóa đơn</param>
        /// <param name="autoOpen">Tự động mở file PDF sau khi tạo</param>
        /// <returns>Đường dẫn file PDF đã tạo, hoặc null nếu thất bại</returns>
        public static string GenerateInvoicePDF(int invoiceID, bool autoOpen = true)
        {
            try
            {
                // 1. Lấy dữ liệu hóa đơn
                var invoice = SalesInvoiceDAO.Instance.GetSalesInvoiceByID(invoiceID);
                // ✅ DEBUG: In ra kiểu dữ liệu
                System.Diagnostics.Debug.WriteLine($"TongTien type: {invoice.TongTien?.GetType().Name ?? "null"}");
                System.Diagnostics.Debug.WriteLine($"TongTien value: {invoice.TongTien}");
                if (invoice == null)
                {
                    throw new Exception("Không tìm thấy hóa đơn!");
                }

                var invoiceDetails = SalesInvoiceDAO.Instance.GetInvoiceDetails(invoiceID);
                if (invoiceDetails == null || invoiceDetails.Count == 0)
                {
                    throw new Exception("Hóa đơn không có chi tiết!");
                }

                // 2. Tạo thư mục lưu file
                string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Invoices");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 3. Tạo tên file
                string fileName = $"HoaDon_{invoice.MaHoaDon}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = Path.Combine(folderPath, fileName);

                // 4. Tạo PDF
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 40, 40, 40, 40); // Margins: 40pt
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.Open();

                    // Add content
                    AddHeader(document);
                    AddInvoiceInfo(document, invoice);
                    AddCustomerInfo(document, invoice);
                    AddProductTable(document, invoiceDetails);
                    AddPaymentSummary(document, invoice);
                    AddFooter(document, invoice);

                    document.Close();
                }

                // 5. Mở file PDF (nếu yêu cầu)
                if (autoOpen)
                {
                    System.Diagnostics.Process.Start(filePath);
                }

                return filePath;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"GenerateInvoicePDF error: {ex.Message}");
                throw new Exception($"Lỗi khi tạo file PDF: {ex.Message}");
            }
        }

        #endregion

        #region Private Methods - Build PDF Sections

        /// <summary>
        /// Thêm phần Header - Thông tin cửa hàng
        /// </summary>
        private static void AddHeader(Document document)
        {
            // Tên cửa hàng
            Paragraph shopName = new Paragraph(SHOP_NAME, fontTitle);
            shopName.Alignment = Element.ALIGN_CENTER;
            document.Add(shopName);

            // Địa chỉ và SĐT
            Paragraph shopInfo = new Paragraph($"{SHOP_ADDRESS}\nĐiện thoại: {SHOP_PHONE}", fontSmall);
            shopInfo.Alignment = Element.ALIGN_CENTER;
            shopInfo.SpacingAfter = 10f;
            document.Add(shopInfo);

            // Đường kẻ ngang
            LineSeparator line = new LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -1);
            document.Add(new Chunk(line));
            document.Add(new Paragraph(" ")); // Space

            // Tiêu đề HÓA ĐƠN
            Paragraph title = new Paragraph("HÓA ĐƠN BÁN HÀNG", fontHeader);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 15f;
            document.Add(title);
        }

        /// <summary>
        /// Thêm thông tin hóa đơn (Mã, Ngày)
        /// </summary>
        private static void AddInvoiceInfo(Document document, SalesInvoices invoice)
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 1, 1 });

            // Mã hóa đơn
            PdfPCell cellLeft = new PdfPCell(new Phrase($"Mã hóa đơn: {invoice.MaHoaDon}", fontBold));
            cellLeft.Border = Rectangle.NO_BORDER;
            cellLeft.HorizontalAlignment = Element.ALIGN_LEFT;
            table.AddCell(cellLeft);

            // Ngày bán
            PdfPCell cellRight = new PdfPCell(new Phrase($"Ngày: {invoice.NgayBan:dd/MM/yyyy HH:mm}", fontNormal));
            cellRight.Border = Rectangle.NO_BORDER;
            cellRight.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cellRight);

            table.SpacingAfter = 10f;
            document.Add(table);
        }

        /// <summary>
        /// Thêm thông tin khách hàng
        /// </summary>
        private static void AddCustomerInfo(Document document, SalesInvoices invoice)
        {
            // Lấy thông tin khách hàng
            var customer = CustomerDAO.Instance.GetCustomerByID(invoice.CustomerID);

            Paragraph customerInfo = new Paragraph();
            customerInfo.Add(new Chunk("Khách hàng: ", fontBold));
            customerInfo.Add(new Chunk(customer?.TenKhachHang ?? "N/A", fontNormal));
            customerInfo.Add(new Chunk("\n"));

            if (!string.IsNullOrEmpty(customer?.SoDienThoai))
            {
                customerInfo.Add(new Chunk("Số điện thoại: ", fontBold));
                customerInfo.Add(new Chunk(customer.SoDienThoai, fontNormal));
                customerInfo.Add(new Chunk("\n"));
            }

            if (!string.IsNullOrEmpty(customer?.DiaChi))
            {
                customerInfo.Add(new Chunk("Địa chỉ: ", fontBold));
                customerInfo.Add(new Chunk(customer.DiaChi, fontNormal));
            }

            customerInfo.SpacingAfter = 15f;
            document.Add(customerInfo);
        }

        /// <summary>
        /// Thêm bảng chi tiết sản phẩm
        /// </summary>
        private static void AddProductTable(Document document, System.Collections.Generic.List<SalesInvoiceDetails> details)
        {
            PdfPTable table = new PdfPTable(6);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 0.5f, 2.5f, 1f, 1f, 1.5f, 1.5f });

            AddTableHeader(table, "STT");
            AddTableHeader(table, "Sản phẩm");
            AddTableHeader(table, "ĐVT");
            AddTableHeader(table, "Số lượng");
            AddTableHeader(table, "Đơn giá");
            AddTableHeader(table, "Thành tiền");

            int stt = 1;
            foreach (var item in details)
            {
                AddTableCell(table, stt.ToString(), Element.ALIGN_CENTER);
                AddTableCell(table, item.ProductName ?? "N/A", Element.ALIGN_LEFT);
                AddTableCell(table, item.UnitName ?? "N/A", Element.ALIGN_CENTER);
                AddTableCell(table, item.SoLuong.ToString("N2"), Element.ALIGN_RIGHT);

                // ✅ DonGiaBan là decimal (non-nullable)
                AddTableCell(table, SafeDecimalToString(item.DonGiaBan), Element.ALIGN_RIGHT);

                // ✅ ThanhTien là decimal? (nullable)
                AddTableCell(table, SafeNullableDecimalToString(item.ThanhTien), Element.ALIGN_RIGHT);

                stt++;
            }

            table.SpacingAfter = 15f;
            document.Add(table);
        }
        /// Thêm phần tổng kết thanh toán
        /// </summary>
        private static void AddPaymentSummary(Document document, SalesInvoices invoice)
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 50;
            table.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.SetWidths(new float[] { 2, 1.5f });

            // ✅ TongTien là decimal? (nullable)
            decimal tongTien = SafeGetNullableDecimal(invoice.TongTien);
            AddSummaryRow(table, "Tổng tiền:", tongTien.ToString("N0"), true);

            // Lấy thông tin thanh toán
            var payments = SalesInvoiceDAO.Instance.GetPaymentsByInvoiceID(invoice.InvoiceID);
            decimal totalPaid = 0m;

            if (payments != null && payments.Count > 0)
            {
                // ✅ SoTien là decimal (non-nullable)
                totalPaid = payments.Sum(p => p.SoTien);
            }

            if (totalPaid > 0)
            {
                AddSummaryRow(table, "Tiền khách đưa:", totalPaid.ToString("N0"), false);

                decimal change = totalPaid - tongTien;

                if (change >= 0)
                {
                    AddSummaryRow(table, "Tiền thừa:", change.ToString("N0"), false);
                }
                else
                {
                    AddSummaryRow(table, "Còn nợ:", Math.Abs(change).ToString("N0"), false);
                }
            }

            // Trạng thái
            string trangThai = invoice.TrangThaiThanhToan ?? "N/A";
            AddSummaryRow(table, "Trạng thái:", trangThai, false);

            table.SpacingAfter = 20f;
            document.Add(table);
        }

        /// <summary>
        /// Xử lý decimal? (nullable) - Dùng cho TongTien, ThanhTien
        /// </summary>
        private static string SafeNullableDecimalToString(decimal? value, string format = "N0")
        {
            return value.HasValue ? value.Value.ToString(format) : "0";
        }

        /// <summary>
        /// Xử lý decimal (non-nullable) - Dùng cho DonGiaBan, SoTien
        /// </summary>
        private static string SafeDecimalToString(decimal value, string format = "N0")
        {
            return value.ToString(format);
        }

        /// <summary>
        /// Lấy giá trị decimal? an toàn
        /// </summary>
        private static decimal SafeGetNullableDecimal(decimal? value)
        {
            return value ?? 0m;
        }

        #endregion
        private static void AddFooter(Document document, SalesInvoices invoice)
        {
            // Nhân viên bán hàng
            var user = UserDAO.Instance.GetUserByID(invoice.UserID);
            Paragraph staff = new Paragraph($"Nhân viên: {user?.HoTen ?? "N/A"}", fontNormal);
            staff.Alignment = Element.ALIGN_LEFT;
            staff.SpacingAfter = 20f;
            document.Add(staff);

            // Đường kẻ ngang
            LineSeparator line = new LineSeparator(1f, 100f, BaseColor.GRAY, Element.ALIGN_CENTER, -1);
            document.Add(new Chunk(line));
            document.Add(new Paragraph(" ")); // Space

            // Lời cảm ơn
            Paragraph thanks = new Paragraph("Cảm ơn quý khách! Hẹn gặp lại!", fontNormal);
            thanks.Alignment = Element.ALIGN_CENTER;
            thanks.SpacingAfter = 10f;
            document.Add(thanks);

            // Chính sách
            Paragraph policy = new Paragraph("* Vui lòng kiểm tra hàng trước khi rời khỏi cửa hàng\n* Hóa đơn là căn cứ để đổi trả hàng trong vòng 3 ngày", fontSmall);
            policy.Alignment = Element.ALIGN_CENTER;
            document.Add(policy);
        }


        #region Helper Methods

        private static void AddTableHeader(PdfPTable table, string text)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, fontBold));
            cell.BackgroundColor = new BaseColor(200, 200, 200);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 8f;
            cell.BorderWidth = 1f;
            table.AddCell(cell);
        }

        private static void AddTableCell(PdfPTable table, string text, int alignment)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, fontNormal));
            cell.HorizontalAlignment = alignment;
            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
            cell.Padding = 5f;
            cell.BorderWidth = 0.5f;
            table.AddCell(cell);
        }

        private static void AddSummaryRow(PdfPTable table, string label, string value, bool isBold)
        {
            Font labelFont = isBold ? fontBold : fontNormal;
            Font valueFont = isBold ? fontBold : fontNormal;

            PdfPCell cellLabel = new PdfPCell(new Phrase(label, labelFont));
            cellLabel.Border = Rectangle.NO_BORDER;
            cellLabel.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellLabel.Padding = 5f;
            table.AddCell(cellLabel);

            PdfPCell cellValue = new PdfPCell(new Phrase(value, valueFont));
            cellValue.Border = Rectangle.NO_BORDER;
            cellValue.HorizontalAlignment = Element.ALIGN_RIGHT;
            cellValue.Padding = 5f;
            table.AddCell(cellValue);
        }

        #endregion
    }
}