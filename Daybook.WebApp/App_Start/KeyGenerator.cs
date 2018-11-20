using System;
using System.Text;

namespace Daybook.WebApp
{
    public static class KeyGenerator
    {
        /// <summary>
        /// 2018NOV152359591231234 length:22
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeKey()
        {
            return DateTime.UtcNow.ToString("yyyyMMMddHHmmssfffffff");
        }

        /// <summary>
        /// 2018Nov14230325675532632333033323536373535333236 length: 48
        /// </summary>
        /// <param name="userhask"></param>
        /// <returns></returns>
        public static string GetUniqKey(string userid)
        {
            var dt = GetDateTimeKey();

            return string.Format("{0}{1}",
                dt,
                BitConverter.ToString(Encoding.Default.GetBytes(dt.Substring(9, 13))).Replace("-", ""));
        }

        public static string Encode(string plaintext)
        {
            string encryptedtext = string.Empty;

            if (!string.IsNullOrEmpty(plaintext))
            {
                byte[] encoded = System.Text.Encoding.UTF8.GetBytes(plaintext);

                encryptedtext = Convert.ToBase64String(encoded);
            }

            return encryptedtext;
        }

        public static string Decode(string encryptedtext)
        {
            string plaintext = string.Empty;

            if (!string.IsNullOrEmpty(encryptedtext))
            {
                byte[] encoded = Convert.FromBase64String(encryptedtext);

                plaintext = Encoding.UTF8.GetString(encoded);
            }

            return plaintext;
        }
    }
}