using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly Pdatabase _hii;
        public HomeController(Pdatabase hii)
        {
            _hii = hii;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Muthu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Muthu(Pmodels Pmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Patient_Details.Add(Pmodel);
                _hii.SaveChanges();
                TempData["hii"] = "Added Successfully";
                return RedirectToAction("Muthu");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Added" + ex;
                return View();

            }
        }

        public IActionResult Display()
        {
            var a = _hii.Patient_Details.ToList();
            return View(a);
        }
        public IActionResult Delete(int Id)
        {
            try
            {
                var c = _hii.Patient_Details.Find(Id);
                if (c!=null) 
                {
                    _hii.Patient_Details.Remove(c);
                    _hii.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("Display");
        }
        public IActionResult Update(int Id)
        {
            var c = _hii.Patient_Details.Find(Id);

            return View(c);
        }
        [HttpPost]
        public IActionResult Update(Pmodels Pmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Patient_Details.Update(Pmodel);
                _hii.SaveChanges();
                TempData["hii"] = "Updated Successfully";
                return RedirectToAction("Display");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Updated" + ex;
                return View();

            }
        }



    }

}
