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
            if (numeros == null || !numeros.Any())
            {
                return BadRequest("La lista de números no puede estar vacía");
            }

            List<int> numerosPares = new List<int>();

            foreach (int numero in numeros)
            {
                if (numero % 2 == 0)
                {
                   numerosPares.Add(numero) ;
                }
            }

            return Ok(new
            {
                TotalPares = numerosPares.Count,
                NumerosPares = numerosPares,
            });
        }
    }
}