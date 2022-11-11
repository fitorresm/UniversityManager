using Microsoft.AspNetCore.Mvc;
using UniversityManager.Back.Application.Dtos;
using UniversityManager.Back.Application.Services;

namespace UniversityManager.Back.API.Controllers
{


    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CoursesController : ControllerBase
    {
        #region DependenceInjection
        private readonly CoursesServices _coursesServices;

        public CoursesController(CoursesServices coursesServices)
        {
            _coursesServices = coursesServices;
        }
        #endregion

        #region ActionResults
        [HttpGet]

        /// <summary>
        /// Get All Courses Cadaster 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult GetAll()
        {
            try
            {
                var responseReturn = _coursesServices.GetAll();

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
        /// Get Courses Cadaster with id
        /// </summary>
        /// <param name="document">Document of Identity</param>
        /// <returns></returns>
        public IActionResult GetById(int id)
        {


            try
            {
                var responseReturn = _coursesServices.GetById(id);

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
        /// Get Courses Cadaster with id
        /// </summary>
        /// <param name="name">Name Of Course</param>
        /// <returns></returns>
        public IActionResult GetByName(string name)
        {


            try
            {
                var responseReturn = _coursesServices.GetByName(name);

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
        /// Cadaster Course
        /// </summary>
        /// <param name="">Model Course Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> AddCourses(CourseDto model)
        {

            try
            {
                var responseReturn = await _coursesServices.AddCourse(model);

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
        /// Update Course
        /// </summary>
        /// <param name="">Model Course Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateCourse(CourseDto model)
        {

            try
            {
                var responseReturn = await _coursesServices.UpdateCourse(model.Id, model);

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
        /// Delete Course
        /// </summary>
        /// <param name="">Model Course Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> InactivateById(int idCourse)
        {

            try
            {
                var responseReturn = await _coursesServices.InactivateById(idCourse);

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
