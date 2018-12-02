using Microsoft.EntityFrameworkCore;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Data
{
    public class SpaContext : DbContext, IReadOnlySpaContext
    {
        public SpaContext(DbContextOptions<SpaContext> options) : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; }

        IQueryable<Appointment> IReadOnlySpaContext.Appointments { get => Appointments.AsNoTracking(); }
    }
}
