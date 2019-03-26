using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class CustomerRepository
    {
        //keep track of wat is in my list
        private static int CustomerKeyCounter = 3;

        private static List<Customer> _customers = new List<Customer>
        {
            //just to have data for now

            new Customer {Name = "John Doe", Id = 1},
            new Customer {Name = "Bill Pricks", Id = 2},
            new Customer {Name = "Svett CoughOnYah", Id = 3}
        };

        //this allows me to pass my list into my controller methods so they can be seen by the view
        public static IReadOnlyList<Customer> Customers => _customers;

        //method allows me to add customers to my list
        public static void Add(Customer customers)
        {
            customers.Id = Interlocked.Increment(ref CustomerKeyCounter);
            _customers.Add(customers);
        }

        public static void Update(int id, Customer customers)
        {
            var index = _customers.FindIndex(x => x.Id == id);
            _customers.RemoveAt(index);
            customers.Id = id;
            _customers.Insert(index, customers);
        }

        //to delete from the list
        public static void DeleteCustomer(int id)
        {
            var index = _customers.FindIndex(x => x.Id == id);
            _customers.RemoveAt(index);
        }

        public static Customer GetCustomer(int id)
        {
            return _customers.Find(x => x.Id == id);
        }
    }
}
