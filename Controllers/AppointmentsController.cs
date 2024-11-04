using HospitalManagementAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
 
namespace HospitalManagementAssignment.Controllers {
    public class AppointmentsController : Controller {
        private readonly MyContext _context;
        public AppointmentsController(MyContext context) {
            _context = context;
        }
        public IActionResult Index() {
            var appointment = _context.Appointments.Include(x => x.Patient).Include(y=>y.Doctor).ToList();
            return View(appointment);
        }

        public IActionResult Details(int id) {
            var appointment = _context.Appointments.Include(x => x.Patient).Include(y => y.Doctor).FirstOrDefault(x => x.AppointmentId == id);
            return View(appointment);
        }

        public IActionResult Edit(int id) {
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "PatientName");
            ViewBag.DoctorId = new SelectList(_context.Doctors, "DoctorId", "DoctorName");

            var appointment = _context.Appointments.FirstOrDefault(x => x.AppointmentId == id);
            return View(appointment);

        }
        [HttpPost]
        public IActionResult Edit(Appointment appointment) {
            if (appointment != null) {
                _context.Entry(appointment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Create(int id) {
            ViewBag.PatientId = new SelectList(_context.Patients, "PatientId", "PatientName");
            ViewBag.DoctorId = new SelectList(_context.Doctors, "DoctorId", "DoctorName"); 
            return View();
        }
        [HttpPost]
        public IActionResult Create(Appointment appointment) {
            if (ModelState.IsValid) {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id) {
            var appointment = _context.Appointments.FirstOrDefault(y => y.AppointmentId == id);
            return View(appointment);
        }
        [HttpPost("Delete")]
        [Route("appointments/delete-confirmed")]

        public IActionResult DeleteConfirmed(int id) {
            var appointment = _context.Appointments.FirstOrDefault(y => y.AppointmentId == id);
            if (appointment != null) {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
