using Labet_Telemedicina_Back.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labet_Telemedicina_Back.Utils
{
    public class ResponseHelper : ControllerBase
    {
        public IActionResult CreateResponse(ResponseModel response)
        {
            return response.StatusCode switch
            {
                200 => Ok(String.IsNullOrEmpty(response.Message) ? response.Content : response.Message),
                500 => StatusCode(500, String.IsNullOrEmpty(response.Message) ? response.Content : response.Message),
                422 => UnprocessableEntity(String.IsNullOrEmpty(response.Message) ? response.Content : response.Message),
                409 => Conflict(String.IsNullOrEmpty(response.Message) ? response.Content : response.Message),
                401 => Unauthorized(String.IsNullOrEmpty(response.Message) ? response.Content : response.Message),
                403 => Forbid(response.Message),
                404 => NotFound(String.IsNullOrEmpty(response.Message) ? response.Content : response.Message),
                _ => null,
            };
        }
    }
}
