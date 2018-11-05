using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Controllers;
using SpaAppointment.Models;
using System.Collections.Generic;
using Xunit;

namespace SpaAppointment.Tests
{
    public class AppointmentControllerTest
    {
        [Fact]
        public void CanAppointmentControllerCreate()
        {
            //arrange
            var controller = new AppointmentController();
            var testApp = new Appointment();

            //act
            var result = controller.Create(testApp);

            //assert
            Assert.NotNull(testApp);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
