using SpaAppointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SpaAppointment.Services
{
    public class ServiceProviderRepository
    {
        private static int ProviderKeyCounter = 3;

        private static List<ServiceProvider> _providers = new List<ServiceProvider>
        {
            //just to have data for now

            new ServiceProvider {Name = "Joey Helperstien", Id=1},
            new ServiceProvider {Name = "Wendy Goosebumps", Id=2},
            new ServiceProvider {Name = "Cher Bear", Id=3},
        };

        public static IReadOnlyList<ServiceProvider> Providers => _providers;

        public static void Add(ServiceProvider providers)
        {
            providers.Id = Interlocked.Increment(ref ProviderKeyCounter);
            _providers.Add(providers);
        }

        public static void Update(int id, ServiceProvider provider)
        {
            var index = _providers.FindIndex(x => x.Id == id);
            _providers.RemoveAt(index);
            provider.Id = id;
            _providers.Insert(index, provider);
        }

        //to delete from the list
        public static void DeleteProvider(int id)
        {
            var index = _providers.FindIndex(x => x.Id == id);
            _providers.RemoveAt(index);
        }


        //List method to return service providers for one certain provider by day
        public static List<Appointment> GetAppointmentsForProviderByDay(int providerId)
        {
            return AppointmentRepository.Appointments
                .Where(x => x.ProviderId == providerId)
                .OrderBy(x => x.AppTime)
                .ToList();
        }

        public static ServiceProvider GetProvider(int id)
        {
            return _providers.Find(x => x.Id == id);
        }
    }
}
