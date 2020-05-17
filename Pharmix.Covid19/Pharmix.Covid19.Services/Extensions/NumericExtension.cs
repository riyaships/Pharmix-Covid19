using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmix.Covid19.Services.Extensions
{
    public static class NumericExtension
    {
        public static int AsInt(this string input)
        {
            input = input.Replace(",", "");
            if (string.IsNullOrWhiteSpace(input)) return 0;

            var isValid = int.TryParse(input, out var validInteger);

            if (isValid) return validInteger;

            return 0;
        }
        public static DateTime? AsDateTime(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            var isValid = DateTime.TryParse(input, out var validDate);

            if (isValid) return validDate;

            return null;
        }
    }
}
