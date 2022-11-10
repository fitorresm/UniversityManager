using Microsoft.AspNetCore.Mvc;

namespace UniversityManager.Back.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
       public string Get()
        {
            return "Olá";
        }
    }
}
