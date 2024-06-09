using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace src.database
{
    // Assumption data in table biodata that is incorrect
    public static class Database
    {
        static MySqlConnection connection;

        /// <summary>
        /// Connect to the database
        /// </summary>
        public static void Connect()
        {
            string connectionString = "Server=localhost;Port=3307;Database=fingerprint;Uid=user;Pwd=password;";
            connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT table_name FROM information_schema.tables WHERE table_schema = 'fingerprint'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Check nama:");
                Console.WriteLine(AlayName.IsAlayNameMatch("B4645 smbg", "Bagas Sambega"));
                String origin = "Bagas Sambega 123";
                String hashed = AlayName.Encrypt(origin, AlayName.GenerateKey(origin, "SKIBIDI"));
                Console.WriteLine($"{origin} = {hashed}");
                Console.WriteLine(AlayName.Decrypt(hashed, AlayName.GenerateKey(origin, "SKIBIDI")));
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

        /// <summary>
        /// Disconnect from database
        /// </summary>
        public static void Disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static string GetConnectionString()
        {
            return connection.ConnectionString;
        }


        /// <summary>
        /// Run SQL command, return the MySqlDataReader for reading all the selected data from SQL.
        /// </summary>
        /// <param name="query">The query select string</param>
        /// <returns>MySqlDataReader for reading all the selected data from SQL</returns>
        public static MySqlDataReader Select(String query)
        {
            MySqlCommand mySqlCommand = new MySqlCommand(query, connection);
            return mySqlCommand.ExecuteReader();
        }

        /// <summary>
        /// Select all data (nama, berkas_citra) from table sidik_jari
        /// </summary>
        /// <returns>MySqlDataReader that can be read, contain nama, berkas_citra</returns>
        public static MySqlDataReader SelectAllFingerprint()
        {
            return Select("SELECT * FROM sidik_jari");
        }

        /// <summary>
        /// Select all data (all attr) from table biodata
        /// </summary>
        /// <returns>MySqlDataReader that can be read contains all attribute in table biodata</returns>
        public static MySqlDataReader SelectAllBiodata()
        {
            return Select("SELECT * FROM biodata");
        }

        /// <summary>
        /// Select data (all attr) from table biodata where name given
        /// </summary>
        /// <param name="name">Name for find in the table biodata</param>
        /// <returns>MySqlDataReader that can be read contains all attribute in table biodata where the name = {name}</returns>
        public static MySqlDataReader SelectAllBiodata(String name)
        {
            name = $"\"{name}\"";
            return Select($"SELECT * FROM biodata WHERE nama={name}");
        }

        /// <summary>
        /// Return all path file to sidik_jari image from database
        /// </summary>
        /// <returns>List of all path file in database sidik_jari</returns>
        public static List<String> SelectAllFingerprintImages()
        {
            MySqlDataReader temp = Select($"SELECT * FROM sidik_jari");
            List<String> list = new List<String>();
            while (temp.Read())
            {
                list.Add(temp["berkas_citra"].ToString());
            }
            temp.Close();
            return list;
        }


        /// <summary>
        /// Find the corresponding name in table biodata (the alayname, unique) if given the file name in the table sidik_jari
        /// </summary>
        /// <param name="filename">File path name in the table sidik_jari</param>
        /// <returns>The alay name exist in table biodata and the original name in table sidik_jari</returns>
        public static (String, String) FindBiodata(String filename)
        {
            List<String> namaBiodata = new List<String>();
            String temp = null;
            try
            {
                MySqlDataReader query = SelectAllBiodata();
                while (query.Read())
                {
                    namaBiodata.Add(query["nama"].ToString());
                }
                query.Close();
                query = SelectAllFingerprint();
                while (query.Read())
                {
                    Console.WriteLine(query["berkas_citra"].ToString());
                    if (query["berkas_citra"].ToString() == filename || query["berkas_citra"].ToString() == $"\"{filename}\"")
                    {
                        temp = query["nama"].ToString();
                        break;
                    }
                }
                query.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (temp == null)
            {
                return (null, temp);
            }
            for (var i = 0; i < namaBiodata.Count(); i++)
            {
                if (AlayName.IsAlayNameMatch(namaBiodata[i], temp))
                {
                    Console.WriteLine($"{temp} = {namaBiodata[i]}");
                    return (namaBiodata[i], temp);
                }
            }
            return (null, temp);
        }

        /// <summary>
        /// Find corresponding biodata in table biodata if given the name
        /// </summary>
        /// <param name="biodataName">Nama di tabel biodata (nama alay)</param>
        /// <returns>All biodata where nama = biodataName</returns>
        public static Dictionary<String, String> ReturnBiodata(String biodataName)
        {
            try
            {
                MySqlDataReader q = SelectAllBiodata(biodataName);
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
                q.Close();
                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public static void ImportSQl(String filename)
        {
            String sql = File.ReadAllText(filename);
            string[] sqlStatements = sql.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (String statement in sqlStatements)
            {
                String trimmed = statement.Trim();
                if (trimmed.StartsWith("INSERT INTO biodata", StringComparison.OrdinalIgnoreCase))
                {
                    String test = ModifyInsert(trimmed);
                    Console.WriteLine(trimmed);
                }
                else
                {
                    using (MySqlCommand command = new MySqlCommand(trimmed, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }

            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                command.ExecuteNonQuery();
            }

            Console.WriteLine("SQL file imported successfully.");
        }

        /*public static void Seeding()
        {
            MySqlDataReader query = Select("SELECT nama FROM ")
        } */
        public static String ModifyInsert(String statement)
        {
            String pattern = @"VALUES\s*\(([^)]+)\)";
            MatchCollection matches = Regex.Matches(statement, pattern, RegexOptions.IgnoreCase);
            foreach (Match match in matches)
            {
                string entireMatch = match.Groups[0].Value; // Extracts the entire match including "VALUES"
                string values = match.Groups[1].Value;
                string[] item = values.Split(new[] { "," }, StringSplitOptions.None);

                foreach (string value in item)
                {
                    Console.WriteLine(value);
                }

                string name = item[0];
            }
            return pattern;
        }
    }


}
