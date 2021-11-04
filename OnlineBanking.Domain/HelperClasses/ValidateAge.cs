using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBanking.Domain.HelperClasses
{
    public static class ValidateAge
    {
        public static bool IsAgeValid(DateTime birthDate)
        {
            int minAge = default;
            var currentYear = DateTime.Now.Year;
            int ageDifference = currentYear - birthDate.Year;
            return (ageDifference > minAge);
        }
    }
}
