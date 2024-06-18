using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospital.Controllers

{
    public class MedicalController:Controller
    {
        private readonly Pdatabase _hii;
        public MedicalController(Pdatabase hii)
        {
            _hii = hii;
        }



        public IActionResult MAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MAdd(MModels mmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Add(mmodel);
                _hii.SaveChanges();
                TempData["hii"] = "Added Successfully";
                return RedirectToAction("MAdd");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Added" + ex;
                return View();

            }
        }

        public IActionResult MDisplay()
        {
            var a = _hii.Medical_Records.ToList();
            return View(a);
        }
        
        public IActionResult MDelete(int Id)
        {
            try
            {
                var c = _hii.Medical_Records.Find(Id);
                if (c != null)
                {
                    _hii.Medical_Records.Remove(c);
                    _hii.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RedirectToAction("MDisplay");
        }
        public IActionResult MUpdate(int Id)
        {
            var c = _hii.Medical_Records.Find(Id);

            return View(c);
        }
        [HttpPost]
        public IActionResult MUpdate(MModels mmodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _hii.Medical_Records.Update(mmodel);
                _hii.SaveChanges();
                TempData["hii"] = "Updated Successfully";
                return RedirectToAction("MDisplay");
            }
            catch (Exception ex)
            {
                TempData["hii"] = "Could Not Updated" + ex;
                return View();

            }
        }

    }
}
