using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Models
{
    public class ServiceProvider
    {
        public string name { get; set; }
        public int id { get; set; }
        public Customer thisServiceProvidersCustomer { get; set; }
    }
}
