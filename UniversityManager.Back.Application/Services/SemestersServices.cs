using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Interfaces;
using UniversityManager.Back.Persistence;
using UniversityManager.Domain;

namespace UniversityManager.Back.Application.Services
{
    public class SemestersServices : ISemestersServices
    {
        
            private readonly ManagerUniversityPersistence _managerUniversityPersistence;
            private readonly SemestersPersistence _semesterPersistence;
            private readonly IMapper _mapper;



            public SemestersServices(ManagerUniversityPersistence managerUniversityPersistence, SemestersPersistence semesterPersistence, IMapper mapper)
            {
                _managerUniversityPersistence = managerUniversityPersistence;
                _semesterPersistence = semesterPersistence;
                _mapper = mapper;
            }
            public async Task<SemesterDto> AddSemester(SemesterDto model)
            {
                try
                {
                    var semesterAdd = _mapper.Map<Semester>(model);

                    _managerUniversityPersistence.Add<Semester>(semesterAdd);
                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {

                        var responseReturn = _semesterPersistence.GetById(semesterAdd.Id);


                        return _mapper.Map<SemesterDto>(responseReturn);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public async Task<SemesterDto> UpdateSemester(int idStudent, SemesterDto model)
            {
                try
                {
                    var semesterToUpdate = _semesterPersistence.GetById(model.Id);

                    if (semesterToUpdate == null) return null;

                    _mapper.Map(model, semesterToUpdate);

                    _managerUniversityPersistence.Update<Semester>(semesterToUpdate);

                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        var responseReturn = _semesterPersistence.GetById(semesterToUpdate.Id);

                        return _mapper.Map<SemesterDto>(responseReturn);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            public async Task<SemesterDto> InactivateById(int idSemester)
            {
                try
                {
                    Semester userInactivate = await _semesterPersistence.InactivateById(idSemester);

                    if (await _managerUniversityPersistence.SaveChangesAsync())
                    {
                        var responseReturn = _semesterPersistence.GetById(userInactivate.Id);

                        return _mapper.Map<SemesterDto>(responseReturn);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public List<SemesterDto> GetAll()
            {
                try
                {
                    var semesters = _semesterPersistence.GetAll();

                    var result = _mapper.Map<List<SemesterDto>>(semesters);

                    return result;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public SemesterDto GetById(int id)
            {
                try
                {
                    var semester = _semesterPersistence.GetById(id);

                    var result = _mapper.Map<SemesterDto>(semester);

                    return result;

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            public List<SemesterDto> GetByName(string name)
            {
                try
                {
                    var semesters = _semesterPersistence.GetByName(name);

                    var result = _mapper.Map<List<SemesterDto>>(semesters);

                    return result;

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }
    }

