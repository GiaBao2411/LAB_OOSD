using System.Configuration;
using System.Data.SqlClient;

public static class Db
{
    public static SqlConnection Open()
    {
        var cn = new SqlConnection(
            ConfigurationManager.ConnectionStrings["Shopping"].ConnectionString);
        cn.Open();
        return cn;
    }
}