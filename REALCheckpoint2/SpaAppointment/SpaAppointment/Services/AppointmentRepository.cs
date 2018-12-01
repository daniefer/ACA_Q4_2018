using SpaAppointment.Controllers;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class AppointmentRepository
    {

        private int AppointmentKeyCounter = 3;

        private List<Appointment> _appointments = new List<Appointment>()
        {
            //Just to stub in data for now
            new Appointment {AppTime = DateTime.Now, Id=1, Description = "This is the spa's first appointment",
                CustomerId = 1, ProviderId = 1 },
            new Appointment {AppTime = DateTime.Now, Id =2, Description = "This is my second appointment at the spa",
                CustomerId = 2, ProviderId = 2 },
            new Appointment {AppTime = DateTime.Now, Id =3, Description = "Appontment three, Baby!!",
                CustomerId = 3, ProviderId = 3 }
        };

        public IReadOnlyList<Appointment> Appointments => _appointments;

        public void isAppointmentAvailable(DateTime AppTime)
        {
            //Try and do the same thing but afterwords by just accessing the last item added to the list?
            var last = Appointments[Appointments.Count - 1];

            //dont forget type AND identifier for foreach loop LOL
            foreach (Appointment x in _appointments )
            {
                string date1 = x.AppTime.ToString("{MM/dd/yyyy h:mm tt}");
                string date2 = last.AppTime.ToString("{MM/dd/yyyy h:mm tt}");

                if (date1.Equals(date2))
                {
                   DeleteAppointment(last.Id );
                    return;
                    //create a return to an error page letting you know why it wasn't created?
                }
                else
                {
                    return;
                }
            }
                //method to check availibility that loops thru list of app an checks time
        }


        public void Add(Appointment appointments)
        {
            appointments.Id = Interlocked.Increment(ref AppointmentKeyCounter);
            _appointments.Add(appointments);
        }

        public Appointment GetAppointment(int id)
        {
            return _appointments.Find(x => x.Id == id);
        }

        public void DeleteAppointment(int id)
        {
            var index = _appointments.FindIndex(x => x.Id == id);
            _appointments.RemoveAt(index);
        }

        public void Update(int id, Appointment appointment)
        {
            var index = _appointments.FindIndex(x => x.Id == id);
            _appointments.RemoveAt(index);
            appointment.Id = id;
            _appointments.Insert(index, appointment);
        }
    }
}
