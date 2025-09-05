using Microsoft.AspNetCore.Mvc;

namespace FiltersNumParser.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumParesController : ControllerBase
    {
        [HttpPost("filtrar-pares")]
        public ActionResult<object> FiltrarPares([FromBody] List<int> numeros)
        {
            if (numeros == null || numeros.Count == 0)
            {
                return BadRequest("La lista de números no puede estar vacía");
            }

            List<int> numerosPares = numeros.Where(n => n % 2 == 0).ToList();

            return Ok(new
            {
                TotalPares = numerosPares.Count,
                NumerosPares = numerosPares,
            });
        }
    }
}