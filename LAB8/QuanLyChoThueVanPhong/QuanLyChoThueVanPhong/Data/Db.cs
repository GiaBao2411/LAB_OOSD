using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyChoThueVanPhong.Data
{
    /// <summary>
    /// Lớp truy cập dữ liệu dùng chung: mở kết nối, truy vấn, thực thi và lấy giá trị đơn.
    /// Form không được viết SQL trực tiếp, mọi câu lệnh đều đi qua Service rồi tới lớp này.
    /// </summary>
    public static class Db
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["QuanLyChoThueVanPhongDB"].ConnectionString; }
        }

        public static SqlConnection OpenConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static DataTable Query(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public static int Execute(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] ps)
        {
            using (var cn = OpenConnection())
            using (var cmd = new SqlCommand(sql, cn))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>Sinh mã chứng từ dạng tiền tố + thời gian, dùng khi Form không nhập mã.</summary>
        public static string SinhMa(string tienTo)
        {
            return tienTo + System.DateTime.Now.ToString("yyMMddHHmmssfff");
        }
    }
}
