using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence.Interfaces
{
    public interface ISubjectPersistence
    {
        Task<Subject> AddSubject(Subject model);
        Task<Subject> UpdateSubject(int idStudent, Subject model);
        Task<Subject> InactivateById(int idSubject);
        List<Subject> GetAll();
        List<Subject> GetByName(string name);
        Subject GetById(int id);
    }
}
