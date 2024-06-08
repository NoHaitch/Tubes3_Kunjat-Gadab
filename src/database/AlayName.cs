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

        bool match = Regex.IsMatch(normalizedAlayName, pattern, RegexOptions.IgnoreCase);

        if (match)
        {
            return true;
        } else
        {
            if (LevenshteinDistance(normalizedAlayName, validName) <= 5)
            {
                return true;
            }
            return false;
        }
    }

    public static int LevenshteinDistance(string source, string target)
    {
        if (string.IsNullOrEmpty(source))
            return string.IsNullOrEmpty(target) ? 0 : target.Length;

        if (string.IsNullOrEmpty(target))
            return source.Length;

        int sourceLength = source.Length;
        int targetLength = target.Length;

        int[,] distance = new int[sourceLength + 1, targetLength + 1];

        for (int i = 0; i <= sourceLength; distance[i, 0] = i++) { }
        for (int j = 0; j <= targetLength; distance[0, j] = j++) { }

        for (int i = 1; i <= sourceLength; i++)
        {
            for (int j = 1; j <= targetLength; j++)
            {
                int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                distance[i, j] = Math.Min(
                    Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1),
                    distance[i - 1, j - 1] + cost);
            }
        }

        return distance[sourceLength, targetLength];
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

    /// <summary>
    /// Create a pattern from the valid name, will be used to match with the alayName
    /// </summary>
    /// <param name="validName">The valid name</param>
    /// <returns>Pattern generated from the valid name (create all lowercase and delete all vocals)</returns>
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
