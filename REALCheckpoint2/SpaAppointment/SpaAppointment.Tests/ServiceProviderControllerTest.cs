using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Controllers;
using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class ServiceProviderControllerTest
    {
        [Fact]
        public void CanServiceProviderControllerViewDetails()
        {
            //arrange
            var controller = new ServiceProviderController();
            var testProvider = new ServiceProvider();

            //act
            var result = controller.Details(testProvider.Id);

            //assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
