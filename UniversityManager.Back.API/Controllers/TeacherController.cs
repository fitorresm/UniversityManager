﻿using Microsoft.AspNetCore.Mvc;
using UniversityManager.Back.Application.Models;
using UniversityManager.Back.Application.Services;

namespace UniversityManager.Back.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeacherController : ControllerBase
    {
        #region DependenceInjection
        private readonly TeacherServices _teacherServices;

        public TeacherController(TeacherServices teacherServices)
        {
            _teacherServices = teacherServices;
        }
        #endregion

        #region ActionResults
        [HttpGet]

        /// <summary>
        /// Get All Teachers Cadaster with document
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public IActionResult GetAllTeachers()
        {
            try
            {
                var responseReturn = _teacherServices.GetAllTeachers();

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
        /// Get Teachers Cadaster with document
        /// </summary>
        /// <param name="document">Document of Identity</param>
        /// <returns></returns>
        public IActionResult GetTeacherByDocument(string document)
        {
           

            try
            {
                var responseReturn = _teacherServices.GetTeacherByDoc(document);

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
        /// Cadaster Teacher
        /// </summary>
        /// <param name="">Model Teacher Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> AddTeacher(TeacherDto model)
        {
           
            try
            {
                var responseReturn = await _teacherServices.AddTeachers(model);

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
        /// Update Teacher
        /// </summary>
        /// <param name="">Model Teacher Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> UpdateTeacher(TeacherDto model)
        {

            try
            {
                var responseReturn = await _teacherServices.UpdateTeacher(model.Id, model);

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
        /// Delete Teacher
        /// </summary>
        /// <param name="">Model Teacher Dto</param>
        /// <returns></returns>
        public async Task<IActionResult> InactivateTeacherById(int idTeacher)
        {

            try
            {
                var responseReturn = await _teacherServices.InactivateTeacherById(idTeacher);

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
