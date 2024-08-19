using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PDS
{
    [Route("/")]
    [ApiController]
    public class PrincipalController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Api Tarefas: Online");
        }
        [HttpGet("Hello-World")]
        public IActionResult Gethw()
        {
            return Ok("Hello World do João");
        }
        [HttpGet ("autor")]
        public IActionResult GetAutor()
        {
            return Ok("Pedro Joaquim");
        }

    }
}
