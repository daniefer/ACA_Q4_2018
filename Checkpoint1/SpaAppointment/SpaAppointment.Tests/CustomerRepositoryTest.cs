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
            CustomerRepository.Add(testCustomer);

            //assert
            var c = CustomerRepository.GetCustomer(testCustomer.Id);
            Assert.NotNull(c);
        }
    }
}
