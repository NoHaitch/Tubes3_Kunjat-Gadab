using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace src.database
{
    public static class Database
    {
        static MySqlConnection connection;
        public static void connect()
        {
            string connectionString = "Server=localhost;Port=3307;Database=fingerprint;Uid=user;Pwd=password;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'fingerprint'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Tables:");
                while (reader.Read())
                {
                    string tableName = reader["table_name"].ToString();
                    Console.WriteLine(tableName);
                }

                reader.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void disconnect()
        {
            try
            {
                connection.Close();
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string GetConnectionString()
        {
            return connection.ConnectionString;
        }

        public static MySqlDataReader select(String query)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            return mySqlCommand.ExecuteReader();
        }

        public static MySqlDataReader selectAllFingerprint()
        {
            return select("SELECT * FROM sidik_jari");
        }

        public static MySqlDataReader selectAllBiodata()
        {
            return select("SELECT * FROM biodata");
        }

        public static MySqlDataReader selectAllBiodata(String name)
        {
            return select($"SELECT * FROM biodata WHERE nama={name}");
        }

        public static void TMain()
        {
            connect();
            MySqlDataReader test = select("SELECT * FROM biodata WHERE jenis_kelamin = 'Laki-Laki';");
            try
            {
                while (test.Read())
                {
                    Console.WriteLine(test["nama"].ToString());
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
