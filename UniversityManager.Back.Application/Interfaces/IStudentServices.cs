using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Models;

namespace UniversityManager.Back.Application.Interfaces
{
    public interface IStudentServices
    {
        Task<StudentDto> AddStudents(StudentDto model);
        Task<StudentDto> UpdateStudent(int teacherId, StudentDto model);
        StudentDto GetByDoc(string document);
        List<StudentDto> GetAll();
        Task<StudentDto> InactivateById(int Id);
    }
}
