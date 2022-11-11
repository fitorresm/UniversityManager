using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence.Interfaces;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence
{
    public class TeacherPersistence : ITeacherPersistence
    {
        public readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly UniversityManagerContext _universityManagerContext;

        public TeacherPersistence(ManagerUniversityPersistence managerUniversityPersistence, UniversityManagerContext universityManagerContext)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _universityManagerContext = universityManagerContext;
        }
        public async Task<Teacher> AddTeacher(Teacher model)
        {
            try
            {
                if (ValidOnlyCadTeacher(model.Document))
                {
                    _managerUniversityPersistence.Add(model);
                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        return GetTeacherByDoc(model.Document);
                    }
                    else
                    {
                        return null;
                    }
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

        public async Task<Teacher> InactivateTeacherByDoc(int idTeacher)
        {
            try
            {
                Teacher teacherToInactivate = _universityManagerContext.Teachers.Where(teacher => teacher.Id == idTeacher).FirstOrDefault();
                if (teacherToInactivate != null)
                {
                    teacherToInactivate.DeletedAt = DateTime.Now;
                    teacherToInactivate.UpdatedAt = DateTime.Now;

                    teacherToInactivate.Disabled = true;

                    _universityManagerContext.Update(teacherToInactivate);

                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        return GetTeacherByDoc(teacherToInactivate.Document);
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

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                List<Teacher> teacherResponse = _universityManagerContext.Teachers.OrderBy(teacher => teacher.Id).ToList();

                if (teacherResponse != null)
                {
                    return teacherResponse;
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

        public Teacher GetTeacherByDoc(string document)
        {
            try
            {
                Teacher teacherResponse = _universityManagerContext.Teachers.Where(teacher => teacher.Document == document).FirstOrDefault();

                if (teacherResponse != null)
                {
                    return teacherResponse;
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

        public async Task<Teacher> UpdateTeacher(int teacherId, Teacher model)
        {
            try
            {

                _managerUniversityPersistence.Update(model);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    return GetTeacherByDoc(model.Document);
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

        public bool ValidOnlyCadTeacher(string document)
        {
            bool valid = _universityManagerContext.Teachers.Where(teacher => teacher.Document == document).Count() < 1;

            return valid;
        }
    }
}
