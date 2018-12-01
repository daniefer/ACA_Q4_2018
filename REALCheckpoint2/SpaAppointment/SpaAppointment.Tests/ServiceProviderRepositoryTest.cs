using SpaAppointment.Models;
using SpaAppointment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SpaAppointment.Tests
{
    public class ServiceProviderRepositoryTest
    {
        ServiceProviderRepository repo = new ServiceProviderRepository();
        [Fact]
        public void CanServiceProviderRepositoryDeleteProvider()
        {
            //arrange
            var testProvider = new ServiceProvider()
            {
                Id = 10,
                Name = "NoHands McGee"
            };

            //act
            repo.Add(testProvider);
            repo.DeleteProvider(testProvider.Id);

            //assert
            var p = repo.Providers.FirstOrDefault(x => x.Id == testProvider.Id);
            Assert.Null(p);
        }
    }
}
