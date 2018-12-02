using SpaAppointment.Controllers;
using SpaAppointment.Data;
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

        private readonly SpaContext _spaContext;

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


        public void Add(Appointment appointment)
        {
            appointment.Id = Interlocked.Increment(ref AppointmentKeyCounter);
            _spaContext.Appointments.Add(appointment);
        }

        public Appointment GetAppointment(int id)
        {
            return _spaContext.Appointments.Find(SelectAppointmentById(int));
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

        //Selector Functions
        private static Func<Appointment, bool> SelectAppointmentById(int id)
        {
            return Appointment => Appointment.Id == id;
        }
    }
}
