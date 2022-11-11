using AutoMapper;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Persistence;
using UniversityManager.Domain;

namespace UniversityManager.Back.Application.Services
{
    public class SubjectsServices
    {
        private readonly ManagerUniversityPersistence _managerUniversityPersistence;
        private readonly SubjectPersistence _subjectPersistence;
        private readonly IMapper _mapper;



        public SubjectsServices(ManagerUniversityPersistence managerUniversityPersistence, SubjectPersistence subjectPersistence, IMapper mapper)
        {
            _managerUniversityPersistence = managerUniversityPersistence;
            _subjectPersistence = subjectPersistence;
            _mapper = mapper;
        }
        public async Task<SubjectDto> AddSubject(SubjectDto model)
        {
            try
            {
                var subjectAdd = _mapper.Map<Subject>(model);

                _managerUniversityPersistence.Add<Subject>(subjectAdd);
                if (await _managerUniversityPersistence.SaveChangesAsync())
                {

                    var responseReturn = _subjectPersistence.GetById(subjectAdd.Id);


                    return _mapper.Map<SubjectDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<SubjectDto> UpdateSubject(int idStudent, SubjectDto model)
        {
            try
            {
                var subjectToUpdate = _subjectPersistence.GetById(model.Id);

                if (subjectToUpdate == null) return null;

                _mapper.Map(model, subjectToUpdate);

                _managerUniversityPersistence.Update<Subject>(subjectToUpdate);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _subjectPersistence.GetById(subjectToUpdate.Id);

                    return _mapper.Map<SubjectDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<SubjectDto> InactivateById(int idSubject)
        {
            try
            {
                Subject userInactivate = await _subjectPersistence.InactivateById(idSubject);

                if (await _managerUniversityPersistence.SaveChangesAsync())
                {
                    var responseReturn = _subjectPersistence.GetById(userInactivate.Id);

                    return _mapper.Map<SubjectDto>(responseReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SubjectDto> GetAll()
        {
            try
            {
                var subjects = _subjectPersistence.GetAll();

                var result = _mapper.Map<List<SubjectDto>>(subjects);

                return result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SubjectDto GetById(int id)
        {
            try
            {
                var subject = _subjectPersistence.GetById(id);

                var result = _mapper.Map<SubjectDto>(subject);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<SubjectDto> GetByName(string name)
        {
            try
            {
                var subjects = _subjectPersistence.GetByName(name);

                var result = _mapper.Map<List<SubjectDto>>(subjects);

                return result;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
