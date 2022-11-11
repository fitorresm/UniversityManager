using AutoMapper;
using UniversityManager.Back.Application.Models;
using UniversityManager.Domain;

namespace UniversityManager.Back.API.Helpers
{
    public class UniversityManagerProfile : Profile
    {
        public UniversityManagerProfile()
        {
            CreateMap<Teacher, TeacherDto>();
        }
    }
}
