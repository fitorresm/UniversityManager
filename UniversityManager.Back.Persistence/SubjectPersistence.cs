using UniversityManager.Back.Persistence.Contexts;
using UniversityManager.Back.Persistence.Interfaces;
using UniversityManager.Domain;

namespace UniversityManager.Back.Persistence
{
    public class SubjectPersistence : ISubjectPersistence
    {
        public readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly UniversityManagerContext _universityManagerContext;

        public SubjectPersistence(ManagerUniversityPersistence managerUniversityPersistence, UniversityManagerContext universityManagerContext)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _universityManagerContext = universityManagerContext;
        }
        public async Task<Subject> AddSubject(Subject model)
        {
            try
            {

                _managerUniversityPersistence.Add<Subject>(model);
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

        public List<Subject> GetAll()
        {
            try
            {
                List<Subject> studentsResponse = _universityManagerContext.Subjects.OrderBy(Subjects => Subjects.Id).ToList();

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

        public List<Subject> GetByName(string name)
        {
            try
            {
                var SubjectResponse = _universityManagerContext.Subjects.Where(Subject => Subject.Name.Contains(name.ToLower())).ToList();

                if (SubjectResponse.Count > 0)
                {
                    return SubjectResponse;
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Subject GetById(int id)
        {
            try
            {
                var SubjectResponse = _universityManagerContext.Subjects.Where(Subject => Subject.Id == id).FirstOrDefault();

                if (SubjectResponse != null)
                {
                    return SubjectResponse;
                }

                return null;
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Subject> InactivateById(int idSubject)
        {
            try
            {
                Subject modelToInactivate = _universityManagerContext.Subjects.Where(Subject => Subject.Id == idSubject).FirstOrDefault();

                if (modelToInactivate != null)
                {
                    modelToInactivate.DeletedAt = DateTime.Now;
                    modelToInactivate.UpdatedAt = DateTime.Now;

                    modelToInactivate.Disabled = true;

                    _universityManagerContext.Update<Subject>(modelToInactivate);

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

        public async Task<Subject> UpdateSubject(int idSubject, Subject model)
        {
            try
            {

                _managerUniversityPersistence.Update<Subject>(model);

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
