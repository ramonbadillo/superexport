namespace FeatherExport.Utilities
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class HelpersDatabase
    {
        public static void CloseReader(ref MySqlDataReader Reader)
        {
            if (Reader != null)
            {
                if (!Reader.IsClosed)
                {
                    Reader.Close();
                }
            }
        }

        public static void CloseConnection(ref MySqlConnection connection)
        {
            if (connection != null)
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static double GetDouble(MySqlDataReader reader, string field)
        {
            double returnDouble = 0; ;
            if (reader[field] != DBNull.Value)
            {
                returnDouble = reader.GetDouble(field);
            }

            return returnDouble;
        }

        public static bool GetBool(MySqlDataReader reader, string field)
        {
            bool returnBool = false;
            if (reader[field] != DBNull.Value)
            {
                int value = reader.GetInt16(field);
                if (value == 1)
                {
                    returnBool = true;
                }
            }
            return returnBool;
        }

        public static string GetDateInvoices(MySqlDataReader reader, string field)
        {
            string returnString = "0001-01-01";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("yyyy-MM-dd");
            }

            return returnString;
        }

        public static DateTime GetDateTimeObject(MySqlDataReader reader, string field)
        {
            DateTime returnString = DateTime.MinValue;
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field);
            }

            return returnString;
        }

        public static string GetDate(MySqlDataReader reader, string field)
        {
            string returnString = "0001/01/01";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("yyyy/MM/dd");
            }

            return returnString;
        }

        public static string GetDateOnlineStore(MySqlDataReader reader, string field)
        {
            string returnString = "0001/01/01";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("MM/dd/yyyy");
            }

            return returnString;
        }

        public static string GetTime(MySqlDataReader reader, string field)
        {
            string returnString = "00:00:00";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("HH:mm:ss");
            }

            return returnString;
        }

        public static string GetDateTime(MySqlDataReader reader, string field)
        {
            string returnString = "0001/01/01 00:00:00";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("yyyy/MM/dd HH:mm:ss");
            }

            return returnString;
        }

        public static string GetDateTimeReport(MySqlDataReader reader, string field)
        {
            string returnString = "01/01/0001 00:00:00";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("MM/dd/yyyy HH:mm:ss");
            }

            return returnString;
        }

        public static string GetDateTimeSec(MySqlDataReader reader, string field)
        {
            string returnString = "0001/01/01 00:00:00";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetDateTime(field).ToString("yyyy/MM/dd HH:mm:ss");
            }

            return returnString;
        }

        public static string GetTimeSpan(MySqlDataReader reader, string field)
        {
            string returnString = "00:00:00";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetTimeSpan(field).ToString();
            }

            return returnString;
        }

        public static string GetFullString(MySqlDataReader reader, string field)
        {
            string returnString = "";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetString(field);
            }

            return returnString;
        }

        public static string GetString(MySqlDataReader reader, string field)
        {
            string returnString = "";
            if (reader[field] != DBNull.Value)
            {
                returnString = Truncate(reader.GetString(field), 100);
            }

            return returnString;
        }

        public static string GetStringClean(MySqlDataReader reader, string field)
        {
            string returnString = "";
            if (reader[field] != DBNull.Value)
            {
                returnString = Truncate(reader.GetString(field), 100);
            }

            return returnString.ToLower().Trim();
        }

        public static string GetXML(MySqlDataReader reader, string field)
        {
            string returnString = "";
            if (reader[field] != DBNull.Value)
            {
                returnString = reader.GetString(field);
            }

            return returnString;
        }

        public static decimal GetDecimal(MySqlDataReader reader, string field)
        {
            decimal returnDecimal = 0M;
            if (reader[field] != DBNull.Value)
            {
                returnDecimal = reader.GetDecimal(field);
            }
            return returnDecimal;
        }

        public static int GetInt(MySqlDataReader reader, string field)
        {
            int returnInt = 0;
            if (reader[field] != DBNull.Value)
            {
                returnInt = reader.GetInt32(field);
            }
            return returnInt;
        }

        public static int GetInt16(MySqlDataReader reader, string field)
        {
            int returnInt = 0;
            if (reader[field] != DBNull.Value)
            {
                returnInt = reader.GetInt32(field);
            }
            return returnInt;
        }

        public static float GetFloat(MySqlDataReader reader, string field)
        {
            float returnFloat = 0;
            if (reader[field] != DBNull.Value)
            {
                returnFloat = reader.GetFloat(field);
            }
            return returnFloat;
        }

        public static string Truncate(this string value, int maxLength, bool replaceTruncatedCharWithEllipsis = false)
        {
            if (replaceTruncatedCharWithEllipsis && maxLength <= 3)
                Console.WriteLine("maxLength:" + "maxLength should be greater than three when replacing with an ellipsis.");

            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;

            if (replaceTruncatedCharWithEllipsis &&
                value.Length > maxLength)
            {
                return value.Substring(0, maxLength - 3) + "...";
            }

            return value.Substring(0, Math.Min(value.Length, maxLength));
        }

        public static string TrimSpacesBetweenString(string s)
        {
            var myString = s.Split(new string[] { " " }, StringSplitOptions.None);
            string result = string.Empty;
            foreach (var mstr in myString)
            {
                var ss = mstr.Trim();
                if (!string.IsNullOrEmpty(ss))
                {
                    result = result + ss + " ";
                }
            }
            return result.Trim();
        }

        public static string CleanStringForCamaleon(string Text)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return "";
            }
            else
            {
                return CleanString(Text, new string[] { "'", "&", "#", "`", ",", "@", "\u001e", "<", ">" });
            }
        }

        public static string CleanString(string TextToClean, string[] charactersToReplace)
        {
            if (string.IsNullOrEmpty(TextToClean))
            {
                return "";
            }
            foreach (var character in charactersToReplace)
            {
                TextToClean = TextToClean.Replace(character, "");
            }
            return TextToClean;
        }

        public static string RemoveWhitespace(this string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        //public static string CleanString(string s)
        //{
        //    s = s.Replace("'", "");
        //    s = s.Replace("&", "");
        //    s = s.Replace("#", "");
        //    s = s.Replace("`", "");
        //    s = s.Replace(",", "");
        //    s = s.Replace("@", "");
        //    return s;
        //}
    }
}