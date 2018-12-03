using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Data;
using SpaAppointment.Models;
using SpaAppointment.Services;

namespace SpaAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppointmentRepository _repo;
        
        public AppointmentController(AppointmentRepository repo)
        {
            _repo = repo;
        }

        // GET: Appointment
        public ActionResult Index()
        {
            return View(_repo.Appointments);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointments)
        {
            if (repo.isAppointmentAvailable(appointments.AppTime))
            {
                repo.Add(appointments);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("AppTime", "Appointment is not available.");
                return View();
            }
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetAppointment(id));
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Appointment appointment)
        {
            try
            {
                // TODO: Add update logic here
                repo.Update(id, appointment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetAppointment(id));
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repo.DeleteAppointment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}