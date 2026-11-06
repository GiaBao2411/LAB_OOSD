using System;
using System.Windows.Forms;
using QuanLyChoThueVanPhong.Data;

namespace QuanLyChoThueVanPhong
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Lần chạy đầu tiên: tự tạo cơ sở dữ liệu và dữ liệu mẫu từ Database\QuanLyChoThueVanPhong.sql
            try
            {
                DbInit.EnsureDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không kết nối được SQL Server nên chưa tạo được cơ sở dữ liệu.\r\n\r\n" +
                    ex.Message + "\r\n\r\n" +
                    "Hãy sửa chuỗi kết nối trong App.config cho đúng máy chủ của bạn, " +
                    "hoặc mở SSMS chạy tay file Database\\QuanLyChoThueVanPhong.sql rồi chạy lại chương trình.",
                    "Khởi tạo cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Application.Run(new QuanLyChoThueVanPhong.Forms.FrmMain());
        }
    }
}
