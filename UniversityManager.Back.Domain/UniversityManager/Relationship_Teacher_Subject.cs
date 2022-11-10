using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManager.Domain
{
    public class Relationship_Teacher_Subject
    {
        public int Id { get; set; }
        public int? IdTeacher { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public int? IdSubject { get; set; }
        public Subject Subject { get; set; }

        public int? IdSemester { get; set; }

        public Semester Semester { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Disabled { get; set; }
    }
}