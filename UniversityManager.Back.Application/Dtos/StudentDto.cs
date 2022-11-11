using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager.Back.Application.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public DateTime BornDate { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone { get; set; }

        public string EmailAddress { get; set; }

        public string City { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool GraduationCompleted { get; set; }

        public bool Disabled { get; set; }
    }
}
