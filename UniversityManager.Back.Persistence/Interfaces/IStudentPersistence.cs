using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence.Interfaces
{
    public interface IStudentPersistence
    {
        Task<Student> AddStudent(Student model);
        Task<Student> UpdateStudent(int idStudent, Student model);
        Task<Student> InactivateById(int idStudent);
        List<Student> GetAll();
        Student GetByDoc(string document);
        bool ValidOnlyCad(string document);
    }
}
