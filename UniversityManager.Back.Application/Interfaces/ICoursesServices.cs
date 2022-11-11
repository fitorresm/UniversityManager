using UniversityManager.Back.Application.Dtos;

namespace UniversityManager.Back.Application.Interfaces
{
    public interface ICourseServices
    {
        Task<CourseDto> AddCourse(CourseDto model);
        Task<CourseDto> UpdateCourse(int idStudent, CourseDto model);
        Task<CourseDto> InactivateById(int idCourse);
        List<CourseDto> GetAll();
        List<CourseDto> GetByName(string name);
        CourseDto GetById(int id);
    }
}
