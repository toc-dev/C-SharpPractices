using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.HelperClasses
{
    public static class AccountNumberGenerator
    {
        public static StringBuilder RandomAccountNumber(int floor, int ceiling)
        {
            Random random = new Random();
            int num = 0;
            int num1 = 0;
            int num2 = random.Next(floor, ceiling);
            //int num2 = random.Next(0, 10);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(num);
            stringBuilder.Append(num1);
            stringBuilder.Append(num2);
            return stringBuilder;
        }
    }
}
