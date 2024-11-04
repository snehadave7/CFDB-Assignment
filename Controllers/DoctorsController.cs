using HospitalManagementAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementAssignment.Controllers {
    public class DoctorsController : Controller {
        private readonly MyContext _context;
        public DoctorsController(MyContext context) {
            _context = context;
        }
        public IActionResult Index() {
            var doctor=_context.Doctors.Include(x=>x.Hospital).ToList();
            return View(doctor);
        }

        public IActionResult Details(int id) {
            var doctor=_context.Doctors.Include(x => x.Hospital).FirstOrDefault(x=>x.DoctorId == id);
            return View(doctor);
        }

        public IActionResult Edit(int id) {
            ViewBag.HospitalId = new SelectList(_context.Hospitals, "HospitalId", "HospitalName");

            var doctor = _context.Doctors.FirstOrDefault(x => x.DoctorId == id);
            return View(doctor);

        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor) {
            if (doctor != null) {
                _context.Entry(doctor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Create(int id) {
            ViewBag.HospitalId = new SelectList(_context.Hospitals, "HospitalId", "HospitalName");
            return View();  
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor) {
            if (ModelState.IsValid) {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id) {
            var doctor= _context.Doctors.FirstOrDefault(y=>y.DoctorId == id);
            return View(doctor);
        }
        [HttpPost("Delete")]
        [Route("doctors/delete-confirmed")]

        public IActionResult DeleteConfirmed(int id) {
            var doctor = _context.Doctors.FirstOrDefault(y => y.DoctorId == id);
            if (doctor != null) {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
