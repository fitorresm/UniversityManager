using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Interfaces;
using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence;
using AutoMapper;
using UniversityManager.Back.Application.Models;
using UniversityManager.Back.Persistence.Interfaces;
using UniversityManager.Domain;
using System.Reflection.Metadata;

namespace UniversityManager.Back.Application.Services
{
    public class StudentsServices : IStudentServices
    {
        private readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly StudentPersistence _studentPersistence;
        private readonly IMapper _mapper;



        public StudentsServices(ManagerUniversityPersistence managerUniversityPersistence, StudentPersistence studentPersistence, IMapper mapper)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _studentPersistence = studentPersistence;
            _mapper = mapper;
        }
        public async Task<StudentDto> AddStudents(StudentDto model)
        {
            try
            {
                var studentAdd = _mapper.Map<Student>(model);

                _managerUniversityPersistence.Add<Student>(studentAdd);


                if (await _managerUniversityPersistence.SaveChangesAsync())
                {

                    var responseReturn = _studentPersistence.GetByDoc(studentAdd.Document);


                    return _mapper.Map<StudentDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<StudentDto> GetAll()
        {
            try
            {
                var students = _studentPersistence.GetAll();

                var result = _mapper.Map<List<StudentDto>>(students);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public StudentDto GetByDoc(string document)
        {
            try
            {
                var student = _studentPersistence.GetByDoc(document);

                var result = _mapper.Map<StudentDto>(student);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<StudentDto> InactivateById(int Id)
        {
            try
            {
                Student userInactivate = await _studentPersistence.InactivateById(Id);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _studentPersistence.GetByDoc(userInactivate.Document);

                    return _mapper.Map<StudentDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StudentDto> UpdateStudent(int studentId, StudentDto model)
        {
            try
            {
                var studentToUpdate = _studentPersistence.GetByDoc(model.Document);

                if (studentToUpdate == null) return null;

                _mapper.Map(model, studentToUpdate);

                _managerUniversityPersistence.Update<Student>(studentToUpdate);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _studentPersistence.GetByDoc(studentToUpdate.Document);

                    return _mapper.Map<StudentDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
