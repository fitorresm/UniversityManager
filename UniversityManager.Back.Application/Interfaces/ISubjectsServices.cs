using UniversityManager.Back.Application.Dtos;

namespace UniversityManager.Back.Application.Interfaces
{
    public interface ISubjectsServices
    {
        Task<SubjectDto> AddSubject(SubjectDto model);
        Task<SubjectDto> UpdateSubject(int idStudent, SubjectDto model);
        Task<SubjectDto> InactivateById(int idSubject);
        List<SubjectDto> GetAll();
        List<SubjectDto> GetByName(string name);
        SubjectDto GetById(int id);
    }
}
