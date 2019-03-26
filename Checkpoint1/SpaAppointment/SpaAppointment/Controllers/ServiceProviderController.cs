using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Models;
using SpaAppointment.Services;

namespace SpaAppointment.Controllers
{
    public class ServiceProviderController : Controller
    {
        // GET: ServiceProvider
        public ActionResult Index()
        {
            return View(ServiceProviderRepository.Providers);
        }

        // GET: ServiceProvider/Details/5
        public ActionResult Details(int id)
        {
            //Somehow my method ServiceProviderRepository.GetAppointmentsForProviderByDay is supposed 
            //to get implemented - dunno how. It will not let me.
            //like absolutely no idea
            //what do i do? Ive tried so many things creating different views etc 
            //and right now Its due and Im over it

            ServiceProviderRepository.GetAppointmentsForProviderByDay(id);
            return View(ServiceProviderRepository.GetProvider(id));
        }

        // GET: ServiceProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceProvider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceProvider providers)
        {
            try
            {
                // TODO: Add insert logic here
                ServiceProviderRepository.Add(providers);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceProvider/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ServiceProviderRepository.GetProvider(id) );
        }

        // POST: ServiceProvider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceProvider provider)
        {
            try
            {
                // TODO: Add update logic here
                ServiceProviderRepository.Update(id, provider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceProvider/Delete/5
        public ActionResult Delete(int id)
        {
            return View(ServiceProviderRepository.GetProvider(id));
        }

        // POST: ServiceProvider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ServiceProviderRepository.DeleteProvider(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}