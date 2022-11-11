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
    public class SemestersPersistence : ISemestersPersistence
    {
        public readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly UniversityManagerContext _universityManagerContext;

        public SemestersPersistence(ManagerUniversityPersistence managerUniversityPersistence, UniversityManagerContext universityManagerContext)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _universityManagerContext = universityManagerContext;
        }
        public async Task<Semester> AddSemester(Semester model)
        {
            try
            {

                _managerUniversityPersistence.Add<Semester>(model);
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

        public List<Semester> GetAll()
        {
            try
            {
                List<Semester> studentsResponse = _universityManagerContext.Semesters.OrderBy(Semesters => Semesters.Id).ToList();

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

        public List<Semester> GetByName(string name)
        {
            try
            {
                var SemesterResponse = _universityManagerContext.Semesters.Where(Semester => Semester.Name.Contains(name.ToLower())).ToList();

                if (SemesterResponse.Count > 0)
                {
                    return SemesterResponse;
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Semester GetById(int id)
        {
            try
            {
                var SemesterResponse = _universityManagerContext.Semesters.Where(Semester => Semester.Id == id).FirstOrDefault();

                if (SemesterResponse != null)
                {
                    return SemesterResponse;
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Semester> InactivateById(int idSemester)
        {
            try
            {
                Semester modelToInactivate = _universityManagerContext.Semesters.Where(Semester => Semester.Id == idSemester).FirstOrDefault();

                if (modelToInactivate != null)
                {
                    modelToInactivate.DeletedAt = DateTime.Now;
                    modelToInactivate.UpdatedAt = DateTime.Now;

                    modelToInactivate.Disabled = true;

                    _universityManagerContext.Update<Semester>(modelToInactivate);

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

        public async Task<Semester> UpdateSemester(int idSemester, Semester model)
        {
            try
            {

                _managerUniversityPersistence.Update<Semester>(model);

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
