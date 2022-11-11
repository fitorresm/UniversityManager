using Microsoft.AspNetCore.Mvc;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Services;

namespace UniversityManager.Back.API.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SemestersController : ControllerBase
    {
        #region DependenceInjection
        private readonly SemestersServices _semestersServices;

        public SemestersController(SemestersServices semestersServices)
        {
            _semestersServices = semestersServices;
        }
        #endregion

        #region ActionResults
        [HttpGet]

        /// <summary>
        /// Get All Semesters Cadaster 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult GetAll()
        {
            try
            {
                var responseReturn = _semestersServices.GetAll();

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
        /// Get Semesters Cadaster with id
        /// </summary>
        /// <param name="document">Document of Identity</param>
        /// <returns></returns>
        public IActionResult GetById(int id)
        {


            try
            {
                var responseReturn = _semestersServices.GetById(id);

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
        /// Get Semesters Cadaster with id
        /// </summary>
        /// <param name="name">Name Of Semester</param>
        /// <returns></returns>
        public IActionResult GetByName(string name)
        {


            try
            {
                var responseReturn = _semestersServices.GetByName(name);

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
        /// Cadaster Semester
        /// </summary>
        /// <param name="">Model Semester Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> AddSemesters(SemesterDto model)
        {

            try
            {
                var responseReturn = await _semestersServices.AddSemester(model);

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
        /// Update Semester
        /// </summary>
        /// <param name="">Model Semester Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateSemester(SemesterDto model)
        {

            try
            {
                var responseReturn = await _semestersServices.UpdateSemester(model.Id, model);

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
        /// Delete Semester
        /// </summary>
        /// <param name="">Model Semester Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> InactivateById(int idSemester)
        {

            try
            {
                var responseReturn = await _semestersServices.InactivateById(idSemester);

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
