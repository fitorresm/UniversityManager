using Microsoft.AspNetCore.Mvc;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Services;

namespace UniversityManager.Back.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubjectsController : ControllerBase
    {
        #region DependenceInjection
        private readonly SubjectsServices _subjectsServices;

        public SubjectsController(SubjectsServices subjectsServices)
        {
            _subjectsServices = subjectsServices;
        }
        #endregion

        #region ActionResults
        [HttpGet]

        /// <summary>
        /// Get All Subjects Cadaster 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult GetAll()
        {
            try
            {
                var responseReturn = _subjectsServices.GetAll();

                if (responseReturn.Count == 0) return NotFound("Não Foi Encontrado Nenhum Resultado");

                return Ok(responseReturn);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }



        [HttpGet("{id}")]

        /// <summary>
        /// Get Subjects Cadaster with id
        /// </summary>
        /// <param name="document">Document of Identity</param>
        /// <returns></returns>
        public IActionResult GetById(int id)
        {


            try
            {
                var responseReturn = _subjectsServices.GetById(id);

                if (responseReturn == null) return NotFound("Não Foi Encontrado Nenhum Resultado");

                return Ok(responseReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }

        [HttpGet("{name}")]

        /// <summary>
        /// Get Subjects Cadaster with id
        /// </summary>
        /// <param name="name">Name Of Subject</param>
        /// <returns></returns>
        public IActionResult GetByName(string name)
        {


            try
            {
                var responseReturn = _subjectsServices.GetByName(name);

                if (responseReturn.Count == 0) return NotFound("Não Foi Encontrado Nenhum Resultado");

                return Ok(responseReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }

        [HttpPut]

        /// <summary>
        /// Cadaster Subject
        /// </summary>
        /// <param name="">Model Subject Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> AddSubjects(SubjectDto model)
        {

            try
            {
                var responseReturn = await _subjectsServices.AddSubject(model);

                if (responseReturn == null) return BadRequest("Não Foi Possivel Adicionar!");

                return Ok(responseReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }


        [HttpPost]

        /// <summary>
        /// Update Subject
        /// </summary>
        /// <param name="">Model Subject Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateSubject(SubjectDto model)
        {

            try
            {
                var responseReturn = await _subjectsServices.UpdateSubject(model.Id, model);

                if (responseReturn == null) return BadRequest("Não Foi Possivel Atualizar o Cadastro!");

                return Ok(responseReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }

        [HttpDelete]

        /// <summary>
        /// Delete Subject
        /// </summary>
        /// <param name="">Model Subject Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> InactivateById(int idSubject)
        {

            try
            {
                var responseReturn = await _subjectsServices.InactivateById(idSubject);

                if (responseReturn == null) return BadRequest("Não Foi Possivel Inativar o Cadastro!");

                return Ok(responseReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }


        #endregion
    }
}
