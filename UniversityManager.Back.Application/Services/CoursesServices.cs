using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Interfaces;
using UniversityManager.Back.Persistence;
using UniversityManager.Back.Persistence.Interfaces;
using UniversityManager.Domain;

namespace UniversityManager.Back.Application.Services
{
    public class CoursesServices : ICourseServices
    {
        private readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly CoursesPersistence _coursePersistence;
        private readonly IMapper _mapper;



        public CoursesServices(ManagerUniversityPersistence managerUniversityPersistence, CoursesPersistence coursePersistence, IMapper mapper)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _coursePersistence = coursePersistence;
            _mapper = mapper;
        }
        public async Task<CourseDto> AddCourse(CourseDto model)
        {
            try
            {
                var courseAdd = _mapper.Map<Course>(model);

                _managerUniversityPersistence.Add<Course>(courseAdd);
                if (await _managerUniversityPersistence.SaveChangesAsync())
                {

                    var responseReturn = _coursePersistence.GetById(courseAdd.Id);


                    return _mapper.Map<CourseDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CourseDto> UpdateCourse(int idStudent, CourseDto model)
        {
            try
            {
                var courseToUpdate = _coursePersistence.GetById(model.Id);

                if (courseToUpdate == null) return null;

                _mapper.Map(model, courseToUpdate);

                _managerUniversityPersistence.Update<Course>(courseToUpdate);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _coursePersistence.GetById(courseToUpdate.Id);

                    return _mapper.Map<CourseDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<CourseDto> InactivateById(int idCourse)
        {
            try
            {
                Course userInactivate = await _coursePersistence.InactivateById(idCourse);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _coursePersistence.GetById(userInactivate.Id);

                    return _mapper.Map<CourseDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CourseDto> GetAll()
        {
            try
            {
                var courses = _coursePersistence.GetAll();

                var result = _mapper.Map<List<CourseDto>>(courses);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CourseDto GetById(int id)
        {
            try
            {
                var course = _coursePersistence.GetById(id);

                var result = _mapper.Map<CourseDto>(course);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<CourseDto> GetByName(string name)
        {
            try
            {
                var courses = _coursePersistence.GetByName(name);

                var result = _mapper.Map<List<CourseDto>>(courses);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }




    }
}
