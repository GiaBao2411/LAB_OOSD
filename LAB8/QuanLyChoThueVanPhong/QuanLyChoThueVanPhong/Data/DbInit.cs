using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace QuanLyChoThueVanPhong.Data
{
    /// <summary>
    /// Lần chạy đầu tiên sẽ tự chạy file Database\QuanLyChoThueVanPhong.sql để tạo bảng và dữ liệu mẫu.
    /// Nếu cơ sở dữ liệu đã tồn tại thì bỏ qua.
    /// </summary>
    public static class DbInit
    {
        public static void EnsureDatabase()
        {
            var csb = new SqlConnectionStringBuilder(Db.ConnectionString);
            string tenCSDL = csb.InitialCatalog;
            csb.InitialCatalog = "master";

            using (var cn = new SqlConnection(csb.ConnectionString))
            {
                cn.Open();

                object o;
                using (var cmd = new SqlCommand("SELECT DB_ID(@n)", cn))
                {
                    cmd.Parameters.AddWithValue("@n", tenCSDL);
                    o = cmd.ExecuteScalar();
                }
                if (o != null && o != DBNull.Value) return;   // đã có cơ sở dữ liệu

                string duongDan = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                               "Database", "QuanLyChoThueVanPhong.sql");
                if (!File.Exists(duongDan)) return;

                foreach (string loSql in TachTheoGo(File.ReadAllText(duongDan, Encoding.UTF8)))
                {
                    using (var cmd = new SqlCommand(loSql, cn))
                    {
                        cmd.CommandTimeout = 180;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>Tách script thành từng lô theo dòng GO vì SqlCommand không hiểu GO.</summary>
        private static List<string> TachTheoGo(string script)
        {
            var ketQua = new List<string>();
            var hienTai = new StringBuilder();

            foreach (string dong in script.Replace("\r\n", "\n").Split('\n'))
            {
                if (dong.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase))
                {
                    if (hienTai.ToString().Trim().Length > 0) ketQua.Add(hienTai.ToString());
                    hienTai.Clear();
                }
                else
                {
                    hienTai.AppendLine(dong);
                }
            }
            if (hienTai.ToString().Trim().Length > 0) ketQua.Add(hienTai.ToString());
            return ketQua;
        }
    }
}
