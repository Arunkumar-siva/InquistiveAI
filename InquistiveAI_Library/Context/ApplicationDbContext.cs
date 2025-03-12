using InquistiveAI_Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InquistiveAI_Library.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Login> Login { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<BatchDetails> BatchDetails { get; set; }

        public DbSet<AssesmentDetails> AssesmentDetails { get; set; }

        public DbSet<EmployeeAssesmentDetails> EmployeeAssesmentDetails { get; set; }

        public DbSet<EmployeeDetails> EmployeeDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-one relationship between EmployeeAssesmentDetails and EmployeeDetails
            //modelBuilder.Entity<EmployeeAssesmentDetails>()
            //    .HasOne(e => e.EmployeeDetails)      // EmployeeAssesmentDetails has one EmployeeDetails
            //    .WithOne(ea => ea.EmployeeAssessmentDetails)                            // EmployeeDetails has one EmployeeAssesmentDetails
            //    .HasForeignKey<EmployeeAssesmentDetails>(e => e.AceId) // AceId in EmployeeAssesmentDetails is the FK
            //    .OnDelete(DeleteBehavior.Restrict);   // Avoid cascading deletes

            //// One-to-many relationship between EmployeeAssesmentDetails and BatchDetails
            //modelBuilder.Entity<EmployeeAssesmentDetails>()
            //    .HasOne(e => e.BatchDetails)
            //    .WithMany() // BatchDetails can have many EmployeeAssesmentDetails
            //    .HasForeignKey(e => e.BatchId)   // BatchId in EmployeeAssesmentDetails is the FK
            //    .OnDelete(DeleteBehavior.Restrict); // Avoid cascading deletes
        }



    }
}
