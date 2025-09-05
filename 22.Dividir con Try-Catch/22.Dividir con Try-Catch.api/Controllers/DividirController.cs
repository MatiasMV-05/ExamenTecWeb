using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _22.Dividir_con_Try_Catch.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DividirController : ControllerBase
    {
        [HttpGet("{a}/{b}")]
        public IActionResult Dividir(decimal a, decimal b)
        {
            try
            {
                decimal resultado = a / b;

                return Ok(resultado);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}