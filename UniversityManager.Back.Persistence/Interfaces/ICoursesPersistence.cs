using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence.Interfaces
{
    public interface ICoursesPersistence
    {
        Task<Course> AddCourse(Course model);
        Task<Course> UpdateCourse(int idStudent, Course model);
        Task<Course> InactivateById(int idCourse);
        List<Course> GetAll();
        List<Course> GetByName(string name);
        Course GetById(int id);
        
    }
}
