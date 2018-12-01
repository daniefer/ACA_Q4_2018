using SpaAppointment.Models;
using SpaAppointment.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace SpaAppointment.Tests
{
    public class AppointmentRepositoryTest
    {
        AppointmentRepository repo = new AppointmentRepository();
        [Fact]
        public void CanAppointmentRepositoryCreate()    
        {
            // arrange
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
