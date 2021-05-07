using System;
using System.Collections.Generic;
using System.Linq;

namespace Startica.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //FillControl(2, 2001, 28);
            FillControlLinq(2, 2001, 28);
        }

        private static void FillControl(int selectedMonth, int selectedYear, int numberOfDaysInMonth)
        {
            //returns all the dates of the appointment from the given month
            var dates = SomeDataProvider.GetAllDates(selectedMonth);

            //for example for the above data would return sorted list such as – '1/2/2001', '1/2/2001', '1/2/2001', '1/2/2001', '3/2/2001', '4/2/2001', '4/2/2001', '4/2/2001' … and so on
            //we want the code that adapts\converts from dates to listToPopulate
            //------------ complete the code that should be written here...
            var listToPopulate = new List<AppointmentsDateInfo>();
            var hashSet = new Dictionary<DateTime, int>();

            foreach (var item in dates)
            {
                var key = item.Date;

                if (!hashSet.ContainsKey(key))
                {
                    hashSet[key] = 0;
                }

                hashSet[key]++;
            }


            for (var day = 1; day <= numberOfDaysInMonth; day++)
            {
                var key = new DateTime(selectedYear, selectedMonth, day);
                var item = new AppointmentsDateInfo()
                {
                    Date = key,
                    CountAppointments = hashSet.ContainsKey(key) ? hashSet[key] : 0,
                };

                listToPopulate.Add(item);
            }


            //-------------------------
            var ctlAppointmentsDate = new AppointmentsDateControl();
            ctlAppointmentsDate.Populate(listToPopulate);
        }

        private static void FillControlLinq(int selectedMonth, int selectedYear, int numberOfDaysInMonth)
        {
            //returns all the dates of the appointment from the given month
            var dates = SomeDataProvider.GetAllDates(selectedMonth);

            //for example for the above data would return sorted list such as – '1/2/2001', '1/2/2001', '1/2/2001', '1/2/2001', '3/2/2001', '4/2/2001', '4/2/2001', '4/2/2001' … and so on
            //we want the code that adapts\converts from dates to listToPopulate
            //------------ complete the code that should be written here...
            var hashSet = dates
                .GroupBy(x=>x.Date)
                .ToDictionary(k=> k.Key, v=>v.Count());

            var listToPopulate =
                Enumerable.Range(1, 28)
                .Select(day =>
                {
                    var key = new DateTime(selectedYear, selectedMonth, day);
                    var item = new AppointmentsDateInfo()
                    {
                        Date = key,
                        CountAppointments = hashSet.ContainsKey(key) ? hashSet[key] : 0,
                    };

                    return item;
                }).ToList();

            //-------------------------
            var ctlAppointmentsDate = new AppointmentsDateControl();
            ctlAppointmentsDate.Populate(listToPopulate);
        }

    }
}
