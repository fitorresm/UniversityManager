using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence.Interfaces
{

    public interface ISemestersPersistence
    {
        Task<Semester> AddSemester(Semester model);
        Task<Semester> UpdateSemester(int idStudent, Semester model);
        Task<Semester> InactivateById(int idSemester);
        List<Semester> GetAll();
        List<Semester> GetByName(string name);
        Semester GetById(int id);
    }
}
