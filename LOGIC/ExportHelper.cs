using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DoubleTRice.LOGIC
{
    public static class ExportHelper
    {
        public static void ExportToExcel(DataGridView dgv, string fileName)
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.csv)|*.csv";
            sfd.FileName = fileName + "_" + DateTime.Now.ToString("ddMMyyyy_HHmm") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // 1. Lấy Header
                    string[] columnNames = new string[dgv.Columns.Count];
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        columnNames[i] = dgv.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", columnNames));

                    // 2. Lấy dữ liệu Rows
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] fields = new string[dgv.Columns.Count];
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                string value = row.Cells[i].Value?.ToString() ?? "";
                                // Xử lý nếu dữ liệu có chứa dấu phẩy thì bọc trong ngoặc kép
                                if (value.Contains(",")) value = "\"" + value + "\"";
                                fields[i] = value;
                            }
                            sb.AppendLine(string.Join(",", fields));
                        }
                    }

                    // 3. Lưu file (Encoding UTF8 để hiển thị tiếng Việt)
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file sau khi lưu
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}