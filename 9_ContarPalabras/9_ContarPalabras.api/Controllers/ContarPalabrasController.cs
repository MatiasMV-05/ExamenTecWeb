using Microsoft.AspNetCore.Mvc;

namespace _9_ContarPalabras.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ContarPalabrasController : ControllerBase
    {
        [HttpPost]
        public IActionResult ContarPalabras([FromBody] string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return BadRequest( "El texto no puede estar vacío" );
            }

            char[] separadores = new[] { ' ' };

            string[] palabras = texto.Split(separadores, StringSplitOptions.RemoveEmptyEntries);

            return Ok(new
            {
                Texto = texto,
                TotalPalabras = palabras.Length,
        
            });

        }

        
    }

    public class TextoRequest
    {
        public string Texto { get; set; }
    }
}