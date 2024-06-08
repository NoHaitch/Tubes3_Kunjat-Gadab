using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using src.database;

namespace src.image
{
    public class ImageDBController
    {
        /// <summary>
        /// Given file name of uploaded fingerprint, return the biodata corresponding to the database
        /// </summary>
        /// <param name="filename">File name path of uploaded fingerprint, need to be relative (path/*.bmp)</param>
        /// <param name="method">Method used, between Knuth-Morris-Pratt or Boyer-Moore</param>
        /// <returns></returns>
        public static String processImage(String filename, String method)
        {
            // TODO use the method

            if (method == "KMP")
            {

            }

            String name = Database.FindBiodata(filename);
            String result = "";
            if (name != null) {
                Dictionary<String, String> data = Database.ReturnBiodata(name);
                if (data != null)
                {
                    foreach (KeyValuePair<String, String> pair in data)
                    {
                        result += pair.Value;
                        result += " : ";
                        result += pair.Key;
                        result += "\n\n";
                    }
                }
                if (result == null || result == "")
                {
                    return "Tidak ditemukan biodata yang bersesuaian\n";
                } else
                {
                    return result;
                }
            } else
            {
                return "Tidak ditemukan biodata yang bersesuaian\n";
            }
        }
    }
}
