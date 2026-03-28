using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClubManager
{
    public sealed class DbSingleton
    {
        private static DbSingleton _instance = null;
        private static readonly object _lock = new object();

        private readonly string _cs;

        private DbSingleton()
        {
            _cs = ConfigurationManager.ConnectionStrings["ClubManagerDB"].ConnectionString;
        }

        public static DbSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new DbSingleton();
                    }
                }
                return _instance;
            }
        }

        public DataRow GetUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 Id, Username, Role FROM Utilisateurs WHERE Username=@u AND PasswordHash=@p", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 1) return dt.Rows[0];
                    return null;
                }
            }
        }
    }
}