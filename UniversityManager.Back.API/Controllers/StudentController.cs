using Microsoft.AspNetCore.Mvc;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Models;
using UniversityManager.Back.Application.Services;

namespace UniversityManager.Back.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        #region DependenceInjection
        private readonly StudentsServices _studentServices;

        public StudentController(StudentsServices studentServices)
        {
            _studentServices = studentServices;
        }
        #endregion

        #region ActionResults
        [HttpGet]

        /// <summary>
        /// Get All Students Cadaster with document
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult GetAll()
        {
            try
            {
                var responseReturn = _studentServices.GetAll();

                if (responseReturn == null) return NotFound("Não Foi Encontrado Nenhum Resultado");

                return Ok(responseReturn);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }



        [HttpGet("{document}")]

        /// <summary>
        /// Get Students Cadaster with document
        /// </summary>
        /// <param name="document">Document of Identity</param>
        /// <returns></returns>
        public IActionResult GetByDocument(string document)
        {


            try
            {
                var responseReturn = _studentServices.GetByDoc(document);

                if (responseReturn == null) return NotFound("Não Foi Encontrado Nenhum Resultado");

                return Ok(responseReturn);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha {ex.Message}");
            }

        }

        [HttpPut]

        /// <summary>
        /// Cadaster Student
        /// </summary>
        /// <param name="">Model Student Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> AddStudent(StudentDto model)
        {

            try
            {
                var responseReturn = await _studentServices.AddStudents(model);

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
        /// Update Student
        /// </summary>
        /// <param name="">Model Student Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateStudent(StudentDto model)
        {

            try
            {
                var responseReturn = await _studentServices.UpdateStudent(model.Id, model);

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
        /// Delete Student
        /// </summary>
        /// <param name="">Model Student Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> InactivateById(int idStudent)
        {

            try
            {
                var responseReturn = await _studentServices.InactivateById(idStudent);

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
