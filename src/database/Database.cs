using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace src.database
{
    // Assumption data in table biodata that is incorrect
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
            name = $"\"{name}\"";
            return select($"SELECT * FROM biodata WHERE nama={name}");
        }

        public static MySqlDataReader selectAllFingerprint(String filename)
        {
            filename = $"\"{filename}\"";
            return select($"SELECT * FROM sidik_jari WHERE berkas_citra={filename}");
        }

        /// <summary>
        /// Find the corresponding name in table biodata (the alayname, unique) if given the file name in the table sidik_jari
        /// </summary>
        /// <param name="filename">File path name in the table sidik_jari</param>
        /// <returns>The alay name exist in table biodata</returns>
        public static String findBiodata(String filename)
        {
            List<String> namaBiodata = new List<String>();
            String temp = null;
            try
            {
                MySqlDataReader query = selectAllBiodata();
                while (query.Read())
                {
                    namaBiodata.Add(query["nama"].ToString());
                }
                query.Close();
                query = selectAllFingerprint();
                while (query.Read())
                {
                    Console.WriteLine(query["berkas_citra"].ToString());
                    if (query["berkas_citra"].ToString() == filename)
                    {
                        temp = query["nama"].ToString();
                        break;
                    }
                }
                query.Close ();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (temp == null)
            {
                return null;
            }
            for (var i = 0; i < namaBiodata.Count(); i++)
            {
                if (AlayName.IsAlayNameMatch(namaBiodata[i], temp))
                {
                    Console.WriteLine($"{temp} = {namaBiodata[i]}");
                    return namaBiodata[i];
                }
            }
            return null;
        }

        public static Dictionary<String, String> returnBiodata(String biodataName)
        {
            try
            {
                MySqlDataReader q = selectAllBiodata(biodataName);
                Dictionary<String, String> data = new Dictionary<string, string>();
                while (q.Read())
                {
                    Console.WriteLine(q["NIK"].ToString());
                    data.Add("NIK", q["NIK"].ToString());
                    data.Add("nama", q["nama"].ToString());
                    data.Add("tempat_lahir", q["tempat_lahir"].ToString());
                    data.Add("tanggal_lahir", q["tanggal_lahir"].ToString());
                    data.Add("jenis_kelamin", q["jenis_kelamin"].ToString());
                    data.Add("golongan_darah", q["golongan_darah"].ToString());
                    data.Add("alamat", q["alamat"].ToString());
                    data.Add("agama", q["agama"].ToString());
                    data.Add("status_perkawinan", q["status_perkawinan"].ToString());
                    data.Add("pekerjaan", q["pekerjaan"].ToString());
                    data.Add("kewarganegaraan", q["kewarganegaraan"].ToString());
                }
                return data;
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static void Mtain()
        {
            connect();
            String name = (findBiodata("test/1.jpg"));
            Console.WriteLine (name);
            Dictionary<String, String> data = returnBiodata(name);
            if (data  != null)
            {
                try
                {
                    foreach(KeyValuePair<String, String> pair in data)
                    {
                        Console.WriteLine($"{pair.Key} = {pair.Value}");
                    }
                } catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

    }
}
