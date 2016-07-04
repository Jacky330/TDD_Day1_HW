using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1Homework
{

    public static class Grouping
    {
        public static decimal[] Subtotal<T>(this IEnumerable<T> data, int size, string colName)
        {
            if (size <= 0)
            {
                throw new ArgumentException("The argument 'size' must be greater than zero.");
            }
            if (string.IsNullOrWhiteSpace(colName) || colName.Contains(" "))
            {
                throw new ArgumentException("The argument 'colName' cannot be null, empty or contain any white space.");
            }

            int pageCount = (int)Math.Ceiling((double)data.Count() / size);
            decimal[] result = new decimal[pageCount];

            for (var i = 0; i < pageCount; ++i)
            {
                result[i] = data.Skip(i * size).Take(size).Select(d => Convert.ToDecimal(d.GetType().GetProperty(colName).GetValue(d, null))).Sum();
            }
            return result;
        }
    }
}
