using Microsoft.AspNetCore.Mvc;
using Moq;
using SpaAppointment.Controllers;
using SpaAppointment.Models;
using SpaAppointment.Services;
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
            var mockServRepo = new Mock<ServiceProviderRepository>();
            var mockAppRepo = new Mock<AppointmentRepository>();
            var mockCustRepo = new Mock<CustomerRepository>();
            var controller = new AppointmentController(mockAppRepo.Object,
                mockCustRepo.Object, mockServRepo.Object);
            var testApp = new Appointment();

            //act
            var result = controller.Create(testApp);

            //assert
            Assert.NotNull(testApp);
            Assert.IsType<RedirectToActionResult>(result);
        }
    }
}
