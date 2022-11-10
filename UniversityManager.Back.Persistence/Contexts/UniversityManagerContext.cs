using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence.Contexts
{
    
    public class UniversityManagerContext : DbContext
    {
        public UniversityManagerContext(DbContextOptions<UniversityManagerContext> options) : base(options) { }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Relationship_Student_Subject> Relationship_Students_Subjects { get; set; }
        public virtual DbSet<Relationship_Subject_Course> Relationship_Subjects_Courses { get; set; }
        public virtual DbSet<Relationship_Teacher_Subject> Relationship_Teachers_Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relationship_Student_Subject>().HasKey(RelSS => new { RelSS.IdStudent, RelSS.IdSubject });
            modelBuilder.Entity<Relationship_Subject_Course>().HasKey(RelSC => new { RelSC.IdSubject });
            modelBuilder.Entity<Relationship_Teacher_Subject>().HasKey(RelTC => new { RelTC.IdSubject, RelTC.IdSemester });
            modelBuilder.Entity<Note>().HasKey(notes => new { notes.IdCourse, notes.IdSemester, notes.IdStudent, notes.IdSubject });

        }
    }
}
