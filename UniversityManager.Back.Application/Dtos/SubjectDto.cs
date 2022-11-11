using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager.Back.Application.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Single MinAprove { get; set; }
        public Single MaxAprove { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool Optional { get; set; }

        public bool Disabled { get; set; }
    }
}
