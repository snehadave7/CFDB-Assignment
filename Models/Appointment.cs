namespace HospitalManagementAssignment.Models {
    public class Appointment {
        public int AppointmentId { get; set; }
        public string AppointmentDate { get; set; }

        public int PatientId { get; set; }  
        public int DoctorId {  get; set; }

        public virtual Patient? Patient { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
