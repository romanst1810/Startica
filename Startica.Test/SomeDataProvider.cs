using System;
using System.Collections.Generic;
using System.Linq;

namespace Startica.Test
{
    public class SomeDataProvider
    {
        public static List<DateTime> GetAllDates(int selectedMonth)
        {
            return GetDates().ToList();
        }


        private static IEnumerable<DateTime> GetDates()
        {
            yield return new DateTime(2001, 2, 1);
            yield return new DateTime(2001, 2, 1);
            yield return new DateTime(2001, 2, 1);
            yield return new DateTime(2001, 2, 1);

            yield return new DateTime(2001, 2, 3);
            
            yield return new DateTime(2001, 2, 4);
            yield return new DateTime(2001, 2, 4);
            yield return new DateTime(2001, 2, 4);

            yield return new DateTime(2001, 2, 28);


        }
    }
}