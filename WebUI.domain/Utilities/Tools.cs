using System;
using System.Collections.Generic;
using System.Linq;
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
            var shuffledArray = arr;
            int n = shuffledArray.Length;
            var random = new Random();
            while (n > 1)
            {
                int k = random.Next(n--);
                char temp = shuffledArray[n];
                shuffledArray[n] = shuffledArray[k];
                shuffledArray[k] = temp;
            }
            return shuffledArray;
        }
    }
}

