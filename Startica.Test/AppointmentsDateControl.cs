using System;
using System.Collections.Generic;

namespace Startica.Test
{
    public class AppointmentsDateControl
    {
        public void Populate(List<AppointmentsDateInfo> list)
        {
            // this is done by the control
            foreach (var dateInfo in list)
            {
                Console.WriteLine("{0:d}: {1}", dateInfo.Date, dateInfo.CountAppointments);
            }
        }
    }
}