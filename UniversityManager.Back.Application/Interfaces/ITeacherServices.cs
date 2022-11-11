using Labet_Telemedicina_Back.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Application.Models;
using UniversityManager.Back.Application.Services;
using UniversityManager.Domain;

namespace UniversityManager.Back.Application.Interfaces
{
    public interface ITeacherServices
    {
        Task<TeacherDto> AddTeachers(TeacherDto model);
        Task<TeacherDto> UpdateTeacher(int teacherId, TeacherDto model);
        TeacherDto GetTeacherByDoc(string docId);
        List<TeacherDto> GetAllTeachers();
        Task<TeacherDto> InactivateTeacherById(int Id);


    }
}
