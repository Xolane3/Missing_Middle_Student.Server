using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Missing_Middle_Student.Model.Models
{
    public class ApplicantDbContext : DbContext
    {

        public ApplicantDbContext(DbContextOptions<ApplicantDbContext> options) : base(options) { }


        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<StudentModule> StudentModules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentModule>()
                .HasKey(sm => new { sm.StudentNum, sm.ModuleCode });

            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Student)
                .WithMany(s => s.StudentModules)
                .HasForeignKey(sm => sm.StudentNum);

            modelBuilder.Entity<StudentModule>()
                .HasOne(sm => sm.Module)
                .WithMany(m => m.StudentModules)
                .HasForeignKey(sm => sm.ModuleCode);
        }

    }
}

