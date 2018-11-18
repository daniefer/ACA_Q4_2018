//Don't know how to change directory of my ALREADY submitted Checkpoint#1, 
//so I make a new branch and also making some changes in this project by typing 
// these comments, so I can "git add" it to a new branch.
//
//*********************************************************************
//And I'm not being late.
//
//*********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BellaSalon.Models;

namespace BellaSalon.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult CustomerIndex()
        {
            return View(Repository.Customers);
        }
        [HttpGet]
        public IActionResult CustomerCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerCreate(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Repository.CustomerAdd(customer);
            return View("CustomerIndex", Repository.Customers);
        }
        public IActionResult CustomerDelete(Guid ID)
        {
            var DelCustomer = Repository.Customers.ToList().Find(c => c.ID == ID);
            Repository.CustomerRemove(DelCustomer);
            return View("CustomerIndex", Repository.Customers);
        }
        public IActionResult ServiceProviderIndex()
        {
            return View(Repository.ServiceProviders);
        }
        [HttpGet]
        public IActionResult ServiceProviderCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ServiceProviderCreate(ServiceProvider serviceProvider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Repository.ServiceProviderAdd(serviceProvider);
            return View("ServiceProviderIndex", Repository.ServiceProviders);
        }
        public IActionResult ServiceProviderDelete(Guid ID)
        {
            var DelServiceProvider = Repository.ServiceProviders.ToList().Find(s => s.ID == ID);
            Repository.ServiceProviderRemove(DelServiceProvider);
            return View("ServiceProviderIndex", Repository.ServiceProviders);
        }
        public IActionResult AppointmentsByDate(string name)
        {
            var SPAppointments = Repository.Appointments.Where(a => a.ServiceProvider == name).ToList();

            ViewBag.SPAppointments = SPAppointments.OrderBy(a => a.Date).ThenBy(a => a.Time).ToList();
            ViewBag.ServiceProvider = name;
            ViewBag.Customers = Repository.Customers.ToList();
            return View();
        }
        public IActionResult AppointmentIndex()
        {
            return View(Repository.Appointments);
        }
        [HttpGet]
        public IActionResult AppointmentCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AppointmentCreate(Appointment appointment)
        {
            bool custExists = false;
            bool serviceProviderExists = false;
            bool doubleBooked = false;
            foreach (var c in Repository.Customers)
            {
                if (appointment.Customer == c.Name)
                    custExists = true;
            }
            foreach (var s in Repository.ServiceProviders)
            {
                if (appointment.ServiceProvider == s.Name)
                    serviceProviderExists = true;
            }
            foreach (var a in Repository.Appointments)
            {
                if (appointment.Date == a.Date && appointment.Time == a.Time && (appointment.Customer == a.Customer || appointment.ServiceProvider == a.ServiceProvider))
                {
                    doubleBooked = true;
                }
            }
            if (custExists && serviceProviderExists && !doubleBooked)
            {
                Repository.AddAppointment(appointment); 
            }
            else
            {
                ViewBag.error = "Invalid Appointment";
            }
            return View("AppointmentIndex", Repository.Appointments.OrderBy(a => a.Date).ThenBy(a => a.Time));
        }

        public IActionResult AppointmentDelete(Guid ID)
        {
            var DelAppointment = Repository.Appointments.ToList().Find(a => a.ID == ID);
            Repository.AppointmentRemove(DelAppointment);
            return View("AppointmentIndex", Repository.Appointments);
        }

        public IActionResult Index()
        {
            ViewData["message"] = "Bella's Spa and Nails";
            return View("BellaSalon");
        }

        public IActionResult Home()
        {
            return View("Home");
        }
        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //[HttpGet]
        //public ViewResult FindAppointment()
        //{
        //    ViewData["Message"] = "Enter Customer's Information to find booked appointment";

        //    return View();
        //}
        //[HttpPost]
        //public ViewResult FindAppointment(AppointmentResponse appointmentResponse)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Repository.AddResponse(appointmentResponse);
        //        return View("Thanks", appointmentResponse);
        //    }
        //    else
        //    {
        //        //there is a validation error
        //        return View();
        //    }
        //}

        //public ViewResult AppointmentDetailReport()
        //{
        //    return View(Repository.Responses);
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}

