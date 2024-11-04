using HospitalManagementAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementAssignment.Controllers {
    public class PatientsController : Controller {
        private readonly MyContext _context;
        public PatientsController(MyContext context) {
            _context = context;
        }
        public IActionResult Index() {
            var patient = _context.Patients.ToList();
            return View(patient);
        }

        public IActionResult Details(int id) {
            var patient = _context.Patients.FirstOrDefault(x => x.PatientId == id);
            return View(patient);
        }

        public IActionResult Edit(int id) {

            var patient = _context.Patients.FirstOrDefault(x => x.PatientId == id);
            return View(patient);

        }
        [HttpPost]
        public IActionResult Edit(Patient patient) {
            if (patient != null) {
                _context.Entry(patient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Create(int id) {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient) {
            if (ModelState.IsValid) {
                _context.Patients.Add(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id) {
            var patient = _context.Patients.FirstOrDefault(y => y.PatientId == id);
            return View(patient);
        }
        [HttpPost("Delete")]
        [Route("patients/delete-confirmed")]

        public IActionResult DeleteConfirmed(int id) {
            var patient = _context.Patients.FirstOrDefault(y => y.PatientId == id);
            if (patient != null) {
                _context.Patients.Remove(patient);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
