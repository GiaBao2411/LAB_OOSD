using System;
using System.Windows.Forms;
using QuanLyCongTyDuLich.Data;
using QuanLyCongTyDuLich.Forms;

namespace QuanLyCongTyDuLich
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                DbInit.DamBaoCoCSDL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối / tạo được CSDL QuanLyCongTyDuLich.\n\n" + ex.Message +
                    "\n\nHãy chạy thủ công file Database\\QuanLyCongTyDuLich.sql trong SSMS, " +
                    "rồi kiểm tra chuỗi kết nối trong App.config.",
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.Run(new FrmMain());
        }
    }
}
