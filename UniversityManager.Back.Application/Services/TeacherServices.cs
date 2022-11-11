using AutoMapper;
using Labet_Telemedicina_Back.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Application.Interfaces;
using UniversityManager.Back.Application.Models;
using UniversityManager.Back.Persistence;
using UniversityManager.Domain;

namespace UniversityManager.Back.Application.Services
{
    public class TeacherServices : ITeacherServices
    {
        private readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly TeacherPersistence _TeacherPersistence;
        private readonly IMapper _mapper;

     

        public TeacherServices(ManagerUniversityPersistence managerUniversityPersistence, TeacherPersistence teacherPersistence, IMapper mapper)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _TeacherPersistence = teacherPersistence;
            _mapper = mapper;
        }      

       
        public async Task<TeacherDto> AddTeachers(TeacherDto model)
        {
           
            try
            {
                var teacherAdd = _mapper.Map<Teacher>(model);

                _managerUniversityPersistence.Add<Teacher>(teacherAdd);


                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    
                    var responseReturn = _TeacherPersistence.GetTeacherByDoc(teacherAdd.Document);


                    return _mapper.Map<TeacherDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TeacherDto> InactivateTeacherById(int Id)
        {
           
            try
            {
                Teacher userInactivate = await _TeacherPersistence.InactivateTeacherByDoc(Id);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _TeacherPersistence.GetTeacherByDoc(userInactivate.Document);

                    return _mapper.Map<TeacherDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TeacherDto> UpdateTeacher(int teacherId, TeacherDto model)
        {
            
            try
            {
                var teatcherToUpdate = _TeacherPersistence.GetTeacherByDoc(model.Document);

                if (teatcherToUpdate == null) return null;

                _mapper.Map(model, teatcherToUpdate);

                _managerUniversityPersistence.Update<Teacher>(teatcherToUpdate);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _TeacherPersistence.GetTeacherByDoc(teatcherToUpdate.Document);
                    return _mapper.Map<TeacherDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TeacherDto> GetAllTeachers()
        {
      
            try
            {
                var teachers = _TeacherPersistence.GetAllTeachers();

                var result = _mapper.Map<List<TeacherDto>>(teachers);
            
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TeacherDto GetTeacherByDoc(string document)
        {
           
            try
            {
                var teacher = _TeacherPersistence.GetTeacherByDoc(document);

                var result = _mapper.Map<TeacherDto>(teacher);


               

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

  
    }
}
