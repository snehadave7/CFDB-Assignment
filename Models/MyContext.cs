﻿using Microsoft.EntityFrameworkCore;

namespace HospitalManagementAssignment.Models {
    public class MyContext : DbContext {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }


}