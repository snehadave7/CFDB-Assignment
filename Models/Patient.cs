namespace HospitalManagementAssignment.Models {
    public class Patient {
        public int PatientId { get; set; }
        public string PatientName { get; set; }

        public string Gender{ get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }


    }
}
