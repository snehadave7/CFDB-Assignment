namespace HospitalManagementAssignment.Models {
    public class Hospital {

        public int HospitalId { get; set; }
        public string HospitalName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Doctor> ? Doctors { get; set; }
    }
}
