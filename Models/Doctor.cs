namespace HospitalManagementAssignment.Models {
    public class Doctor {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string DoctorType { get; set; }

        public int HospitalId {  get; set; }

        public virtual Hospital? Hospital { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }

    }
}
