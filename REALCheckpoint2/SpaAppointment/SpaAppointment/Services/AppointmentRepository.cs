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
        private readonly IReadOnlySpaContext _readOnlySpaContext;
        public IQueryable<Appointment> Appointments => _spaContext.Appointments;

        public AppointmentRepository(SpaContext spaContext, IReadOnlySpaContext readOnlySpaContext)
        {
            _spaContext = spaContext;
            _readOnlySpaContext = readOnlySpaContext;
        }

        public bool isAppointmentAvailable(DateTime ProposedTime)
        {
            foreach (Appointment x in _spaContext.Appointments )
            {
                if (x.AppTime.ToString("mm/dd/") == ProposedTime.ToString(""))
                {
                    return false;
                }
            }
            return true;
                //method to check availibility that loops thru list of app an checks time
        }


        public void Add(Appointment appointment)
        {
            appointment.Id = Interlocked.Increment(ref AppointmentKeyCounter);
            _spaContext.Appointments.Add(appointment);
            _spaContext.SaveChanges();
        }

        public Appointment GetAppointment(int id)
        {
            return _spaContext.Appointments.Find(SelectAppointmentById(id));
        }

        public void DeleteAppointment(int id)
        {
            var index = _spaContext.Appointments.Find(SelectAppointmentById(id));
            _spaContext.Appointments.Remove(index);
            _spaContext.SaveChanges();
        }

        public void Update(int id, Appointment appointment)
        {
            appointment.Id = id;
            _spaContext.Appointments.Update(appointment);
            _spaContext.SaveChanges();
        }

        //Selector Functions
        private static Func<Appointment, bool> SelectAppointmentById(int id)
        {
            return Appointment => Appointment.Id == id;
        }
    }
}
