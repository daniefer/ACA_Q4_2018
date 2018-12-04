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
        public DbSet<Customer> Customers { get; }
        public DbSet<ServiceProvider> ServiceProviders { get; }

        IQueryable<Appointment> IReadOnlySpaContext.Appointments { get => Appointments.AsNoTracking(); }
        IQueryable<Customer> IReadOnlySpaContext.Customers { get => Customers.AsNoTracking(); }
        IQueryable<ServiceProvider> IReadOnlySpaContext.ServiceProviders { get => ServiceProviders.AsNoTracking(); }
    }
}
