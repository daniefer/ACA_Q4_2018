using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Controllers;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class CustomerControllerTest
    {
        [Fact]
        public void CanCustomerControllerReturnIndexView()
        {
            //arrange
            var controller = new CustomerController();

            //act
            var result = controller.Index();

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
