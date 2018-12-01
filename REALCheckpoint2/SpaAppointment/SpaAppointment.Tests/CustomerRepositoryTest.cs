using SpaAppointment.Models;
using SpaAppointment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class CustomerRepositoryTest
    {
        CustomerRepository repo = new CustomerRepository();
        [Fact]
        public void CanCustomerRepositoryGetCustomer()
        {
            //arrange
            var testCustomer = new Customer()
            {
                Name = "Jay Winn",
                Id = 10
            };

            //act
            repo.Add(testCustomer);

            //assert
            var c = repo.GetCustomer(testCustomer.Id);
            Assert.NotNull(c);
        }
    }
}
