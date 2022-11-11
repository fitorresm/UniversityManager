using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence.Interfaces;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence
{
    public class CoursesPersistence : ICoursesPersistence
    {
        public readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly UniversityManagerContext _universityManagerContext;

        public CoursesPersistence(ManagerUniversityPersistence managerUniversityPersistence, UniversityManagerContext universityManagerContext)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _universityManagerContext = universityManagerContext;
        }
        public async Task<Course> AddCourse(Course model)
        {
            try
            {
              
                    _managerUniversityPersistence.Add<Course>(model);
                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        return GetById(model.Id);
                    }
                    else
                    {
                        return null;
                    }
               

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Course> GetAll()
        {
            try
            {
                List<Course> studentsResponse = _universityManagerContext.Courses.OrderBy(courses => courses.Id).ToList();

                if (studentsResponse != null)
                {
                    return studentsResponse;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<Course> GetByName(string name)
        {
            try
            {
                var courseResponse = _universityManagerContext.Courses.Where(course => course.Name.Contains(name.ToLower())).ToList();

                if (courseResponse.Count > 0)
                {
                    return courseResponse;
                }

                return null;
            }
            
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Course GetById(int id)
        {
            try
            {
                var courseResponse = _universityManagerContext.Courses.Where(course => course.Id == id).FirstOrDefault();

                if (courseResponse != null)
                {
                    return courseResponse;
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> InactivateById(int idCourse)
        {
            try
            {
                Course modelToInactivate = _universityManagerContext.Courses.Where(course => course.Id == idCourse).FirstOrDefault();

                if (modelToInactivate != null)
                {
                    modelToInactivate.DeletedAt = DateTime.Now;
                    modelToInactivate.UpdatedAt = DateTime.Now;

                    modelToInactivate.Disabled = true;

                    _universityManagerContext.Update<Course>(modelToInactivate);

                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        return GetById(modelToInactivate.Id);
                    }
                    else
                    {
                        return null;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }

        public async Task<Course> UpdateCourse(int idCourse, Course model)
        {
            try
            {

                _managerUniversityPersistence.Update<Course>(model);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    return GetById(model.Id);
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

      
    }
}
