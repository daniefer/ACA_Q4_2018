using SpaAppointment.Models;
using SpaAppointment.Services;
using SpaAppointment.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Moq;

namespace SpaAppointment.Tests
{
    public class AppointmentRepositoryTest
    {
        [Fact]
        public void CanAppointmentRepositoryCreate()    
        {
            // arrange
            var mockSpaContext = new Mock<SpaContext>();
            var mockReadOnlyContext = new Mock<IReadOnlySpaContext>();
            AppointmentRepository repo = new AppointmentRepository(mockSpaContext.Object, mockReadOnlyContext.Object);

            var testAppt = new Appointment()
            {  };

            //act
            repo.Add(testAppt);

            // assert
            var a = repo.Appointments.FirstOrDefault(x => x.Id == testAppt.Id);
            Assert.NotNull(a);
        }
    }
}
