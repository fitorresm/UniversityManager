using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence.Interfaces
{
    public interface ITeacherPersistence
    {
        Task<Teacher> AddTeacher(Teacher model);
        Task<Teacher> UpdateTeacher(int teacherId, Teacher model);
        Teacher GetTeacherByDoc(string docId);
        List<Teacher> GetAllTeachers();
        Task<Teacher> InactivateTeacherByDoc(int docId);
        bool ValidOnlyCadTeacher(string document);


    }
}
