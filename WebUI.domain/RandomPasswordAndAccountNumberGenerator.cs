using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.domain
{
    public class RandomPasswordAndAccountNumberGenerator
    {
        public StringBuilder RandomAccountNumber(int floor, int ceiling)
        {
            Random random = new Random();
            int num = random.Next(floor, ceiling);
            int num2 = random.Next(0, 10);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(num);
            stringBuilder.Append(num2);
            return stringBuilder;
        }
        public string RandomString(int size, bool lowerCase = true)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();

            char character;
            for (int i = 0; i < size; i++)
            {
                character = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                stringBuilder.Append(character);
            }
            if (!lowerCase)
                return stringBuilder.ToString().ToLower();
            return stringBuilder.ToString();
        }
        public string RandomPassword(int size = 0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(RandomString(4, true));
            stringBuilder.Append(RandomAccountNumber(1000, 9999));
            stringBuilder.Append(RandomString(2, false));
            return stringBuilder.ToString();
        }
    }
}
