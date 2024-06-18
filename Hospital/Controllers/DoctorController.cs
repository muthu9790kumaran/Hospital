using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        
        
            private readonly Pdatabase _hii;
            public DoctorController(Pdatabase hii)
            {
                _hii = hii;
            }


           
            public IActionResult DAdd()
            {
                return View();
            }
            [HttpPost]
            public IActionResult DAdd(DModels dmodel)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                try
                {
                    _hii.Doctor_Details.Add(dmodel);
                    _hii.SaveChanges();
                    TempData["hii"] = "Added Successfully";
                    return RedirectToAction("DAdd");
                }
                catch (Exception ex)
                {
                    TempData["hii"] = "Could Not Added" + ex;
                    return View();

                }
            }

            public IActionResult DDisplay()
            {
                var a = _hii.Doctor_Details.ToList();
                return View(a);
            }
            public IActionResult DDelete(int Id)
            {
                try
                {
                    var c = _hii.Doctor_Details.Find(Id);
                    if (c != null)
                    {
                        _hii.Doctor_Details.Remove(c);
                        _hii.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return RedirectToAction("DDisplay");
            }
        
            public IActionResult DUpdate(int Id)
            {
                var c = _hii.Doctor_Details.Find(Id);

                return View(c);
            }
           [HttpPost]
        public IActionResult DUpdate(DModels dmodel)
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                try
                {
                    _hii.Doctor_Details.Update(dmodel);
                    _hii.SaveChanges();
                    TempData["hii"] = "Updated Successfully";
                    return RedirectToAction("DDisplay");
                }
                catch (Exception ex)
                {
                    TempData["hii"] = "Could Not Updated" + ex;
                    return View();

                }
            }

        }


    
}
