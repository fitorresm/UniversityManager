using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Application.Dtos;

namespace UniversityManager.Back.Application.Interfaces
{
    public interface ISemestersServices
    {
        Task<SemesterDto> AddSemester(SemesterDto model);
        Task<SemesterDto> UpdateSemester(int idStudent, SemesterDto model);
        Task<SemesterDto> InactivateById(int idSemester);
        List<SemesterDto> GetAll();
        List<SemesterDto> GetByName(string name);
        SemesterDto GetById(int id);
    }
}
