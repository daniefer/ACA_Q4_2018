using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaAppointment.Models
{
    public class Customer
    {
        public string name { get; set; }
        public int id { get; set; }
        public ServiceProvider thisCustomersServiceProvider { get; set; }
    }
}
