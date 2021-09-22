using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.domain.Utilities
{
    public static class Tools
    {
        public static string PasswordGenerator(string s)
        {
            var str = ($"{s}");
            var ch = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                ch[i] = str[i];
            }

            var shuffled = FisherYatesShuffler(ch);
            var word = new StringBuilder("");
            return word.Append(shuffled).ToString();
        }

        public static char[] FisherYatesShuffler(char[] arr)
        {
            int n = arr.Length;
            var random = new Random();
            for (int i = 0; i < n; i++)
            {
                int k = random.Next(n--);
                char temp = arr[n];
                arr[n] = arr[k];
                arr[k] = temp;
            }
            return arr;
        }

        public static string GenerateAccountNumber()
        {
            var milisecndns = string.Format("{0:000}", DateTime.Now.Millisecond);
            var year = DateTime.Now.ToString("yy");
            var month = string.Format("{0:00}", DateTime.Now.Month);
            var day = (RandomNumberGenerator.GetInt32(10, 99)).ToString();

            var str = year + month + milisecndns + day;
            return str;
        }


    }

}

