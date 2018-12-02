using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Data
{
    interface IReadOnlySpaContext
    {
        IQueryable<Appointment> Appointments { get; }
    }
}
