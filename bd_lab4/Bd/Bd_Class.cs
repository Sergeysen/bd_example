using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace bd_lab4
{
    internal class Bd_Class
    {
        public static SqlConnection ConnectSql()
        {
            SqlConnection sqlConnection = null;
            try
            {
                string connectionString = "Server=WIN-3LMVU483N1V;Database=guskov_sergey_28_04_2024_new;Integrated Security=True;TrustServerCertificate=true;";
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                Console.WriteLine("Подключение открыто.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при подключении к базе данных: " + ex.Message);
                throw;
            }
            return sqlConnection;
        }

        public static void DisconnectSql(SqlConnection sqlConnection)
        {
            try
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    Console.WriteLine("Подключение закрыто.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при закрытии подключения: " + ex.Message);
                throw;
            }
        }

        }
}
