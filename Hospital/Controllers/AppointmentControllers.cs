using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers

    
{
    public class AppointmentControllers : Controller
    {

        private readonly Pdatabase _hii;
        public AppointmentControllers(Pdatabase hii)
        {
            _hii = hii;
        }



        public IActionResult AAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AAdd(AModels Amodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Add(Amodel);
                _hii.SaveChanges();
                TempData["hii"] = "Added Successfully";
                return RedirectToAction("AAdd");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Added" + ex;
                return View();

            }
        }

        public IActionResult ADisplay()
        {
            var a = _hii.Appointment_Details.ToList();
            return View(a);
        }
        public IActionResult ADelete(int Id)
        {
            try
            {
                var c = _hii.Appointment_Details.Find(Id);
                if (c != null)
                {
                    _hii.Appointment_Details.Remove(c);
                    _hii.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("ADisplay");
        }
      
        public IActionResult AUpdate(int Id)
        {
            var c = _hii.Appointment_Details.Find(Id);

            return View(c);
        }
        [HttpPost]
        public IActionResult AUpdate(AModels Amodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Appointment_Details.Update(Amodel);
                _hii.SaveChanges();
                TempData["hii"] = "Updated Successfully";
                return RedirectToAction("ADisplay");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Updated" + ex;
                return View();

            }
        }
    }
}
