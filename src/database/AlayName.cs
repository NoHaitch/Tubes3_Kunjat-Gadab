using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class AlayName
{
    public static Dictionary<char, char> NumberConvert = new Dictionary<char, char>
    {
        {'1', 'I'},
        {'3', 'E'},
        {'4', 'A'},
        {'5', 'S'},
        {'6', 'G'},
        {'7', 'T'},
        {'9', 'G'},
        {'0', 'O'}
    };

    public static bool IsAlayNameMatch(string alayName, string validName)
    {
        string normalizedAlayName = NormalizeAlayName(alayName);

        string pattern = CreatePatternFromValidName(validName);

        return Regex.IsMatch(normalizedAlayName, pattern, RegexOptions.IgnoreCase);
    }

    public static string NormalizeAlayName(string alayName)
    {
        char[] normalizedArray = alayName.ToCharArray();
        for (int i = 0; i < normalizedArray.Length; i++)
        {
            if (NumberConvert.ContainsKey(normalizedArray[i]))
            {
                normalizedArray[i] = NumberConvert[normalizedArray[i]];
            }
        }
        return new string(normalizedArray);
    }

    public static string CreatePatternFromValidName(string validName)
    {
        string pattern = Regex.Replace(validName, "[aeiouAEIOU]", "[aeiouAEIOU]?");
        return "^" + pattern.Replace(" ", "\\s*") + "$";
    }

    static void TMain(string[] args)
    {
        List<string> Biodata = new List<string>
        {
            "Bintang Dwi Hartono",
            "Bentang Dwi Hartono",
            "Alexander De'Honor",
            "Bintang Trisna Adzhifah",
            "Juliantrini Maskulin",
            "Francisco Bernoulli",
            "Alina",
        };

        string alayName = "Bntng Dw1 h4rt0no";

        foreach (string validName in Biodata)
        {
            if (IsAlayNameMatch(alayName, validName))
            {
                Console.WriteLine($"{alayName} bersesuaian dengan {validName}");
            }
        }
    }
}
