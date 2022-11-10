using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManager.Domain
{
    public class Course
    {
                public int Id { get; set; }
                public string Name { get; set; }
                public int QtdSemesters { get; set; }                        
                public DateTime CreatedAt { get; set; }
                public DateTime? UpdatedAt { get; set; }
                public DateTime? DeletedAt { get; set; }
                public bool Disabled { get; set; }
    }
}