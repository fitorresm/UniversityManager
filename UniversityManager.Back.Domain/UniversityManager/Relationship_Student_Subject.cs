using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManager.Domain
{
    public class Relationship_Student_Subject
    {
        public int Id { get; set; }
        public int? IdStudent { get; set; }
        public Student Student { get; set; }
        public int? IdSubject { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }

        public int? IdSemester { get; set; }

        public IEnumerable<Semester> Semesters { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Disabled { get; set; }
    }
}