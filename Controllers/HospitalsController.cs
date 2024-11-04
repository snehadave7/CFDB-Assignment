using HospitalManagementAssignment.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAssignment.Controllers {
    public class HospitalsController : Controller {
        private readonly MyContext _context;
        public HospitalsController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index() {
            var hospital = _context.Hospitals.ToList();
            return View(hospital);
        }

        public IActionResult Details(int id) {
            var hospital= _context.Hospitals.FirstOrDefault(x=>x.HospitalId==id);
            return View(hospital);
        }

        public IActionResult Edit(int id) {
            var hospital = _context.Hospitals.FirstOrDefault(x => x.HospitalId == id);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Hospital hospital) {
            if (hospital != null) {
                _context.Entry(hospital).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Create(int id) {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital) {
            if (ModelState.IsValid) {
                _context.Hospitals.Add(hospital);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int id) {
            var hospital = _context.Hospitals.FirstOrDefault(x => x.HospitalId == id);
            return View(hospital);
        }

        [HttpPost("Delete")]
        public IActionResult DeleteConfirmed(int id) {
            var hospital = _context.Hospitals.FirstOrDefault(x => x.HospitalId == id);
            
            if (hospital != null) {
                _context.Hospitals.Remove(hospital);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
