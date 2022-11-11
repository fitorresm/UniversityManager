using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence.Interfaces;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence
{
    public class StudentPersistence : IStudentPersistence
    {
        public readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly UniversityManagerContext _universityManagerContext;

        public StudentPersistence(ManagerUniversityPersistence managerUniversityPersistence, UniversityManagerContext universityManagerContext)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _universityManagerContext = universityManagerContext;
        }
        public async Task<Student> AddStudent(Student model)
        {
            try
            {
                if (ValidOnlyCad(model.Document))
                {
                    _managerUniversityPersistence.Add<Student>(model);
                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        return GetByDoc(model.Document);
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

        public async Task<Student> InactivateById(int idStudent)
        {
            try
            {
                Student modelToInactivate = _universityManagerContext.Students.Where(Student => Student.Id == idStudent).FirstOrDefault();
                if (modelToInactivate != null)
                {
                    modelToInactivate.DeletedAt = DateTime.Now;
                    modelToInactivate.UpdatedAt = DateTime.Now;

                    modelToInactivate.Disabled = true;

                    _universityManagerContext.Update<Student>(modelToInactivate);

                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        return GetByDoc(modelToInactivate.Document);
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

        public List<Student> GetAll()
        {
            try
            {
                List<Student> studentsResponse = _universityManagerContext.Students.OrderBy(students => students.Id).ToList();

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

        public Student GetByDoc(string document)
        {
            try
            {
                Student studentResponse = _universityManagerContext.Students.Where(student => student.Document == document).FirstOrDefault();

                if (studentResponse != null)
                {
                    return studentResponse;
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

        public async Task<Student> UpdateStudent(int idStudent, Student model)
        {
            try
            {

                _managerUniversityPersistence.Update<Student>(model);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    return GetByDoc(model.Document);
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

        public bool ValidOnlyCad(string document)
        {
            bool valid = _universityManagerContext.Students.Where(student => student.Document == document).Count() < 1;

            return valid;
        }
    }
}
