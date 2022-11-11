using AutoMapper;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Models;
using UniversityManager.Domain;

namespace UniversityManager.Back.API.Helpers
{
    public class UniversityManagerProfile : Profile
    {
        public UniversityManagerProfile()
        {
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Semester, SemesterDto>().ReverseMap();

        }
    }
}
