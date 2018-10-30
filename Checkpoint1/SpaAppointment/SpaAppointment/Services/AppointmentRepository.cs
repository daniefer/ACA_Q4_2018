using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class AppointmentRepository
    {
        //method to check availibility that loops thru list of app an checks time
        //try to pseudo code THIS - LOOP THRU APP LIST
        //ApptRepo.isApptAvail(appTime, serviceProvider)

        private static List<Appointment> _appointments = new List<Appointment>()
        {
            //Just to stub in data for now
            new Appointment {AppTime = DateTime.Now, Id =1, Description = "dis mah first appoint ment at spa",
                CustomerId = 1, ProviderId = 1 },
            new Appointment {AppTime = DateTime.Now, Id =2, Description = "This is my second appointment at the spa",
                CustomerId = 2, ProviderId = 2 },
            new Appointment {AppTime = DateTime.Now, Id =3, Description = "Appontment three, Baby!!",
                CustomerId = 3, ProviderId = 3 }
        };

        public static IReadOnlyList<Appointment> Appointments => _appointments;
    }
}
