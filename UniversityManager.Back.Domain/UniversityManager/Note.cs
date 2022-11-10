using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManager.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public int? IdStudent { get; set; }

        public int? IdSubject { get; set; }


        public int? IdSemester { get; set; }



        public int? IdCourse { get; set; }



        public int? IdTeacher { get; set; }


        public Single ValueNote { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Disabled { get; set; }
    }
}