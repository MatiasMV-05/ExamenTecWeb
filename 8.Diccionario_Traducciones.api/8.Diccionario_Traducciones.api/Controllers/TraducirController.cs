using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _8.Diccionario_Traducciones.api.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class TraducirController : ControllerBase
        {
            private static Dictionary<string, string> _traducciones = new()
        {
            {"hello", "hola"},
            {"goodbye", "adiós"},
            {"glass", "vaso"},
            {"please", "por favor"},
            {"yes", "sí"},
            {"school", "colegio"},
            {"water", "agua"},
            {"food", "comida"},
            {"house", "casa"},
            {"dog", "perro"},
            {"cat", "gato"},
            {"love", "amor"},
            {"friend", "amigo"},
            {"time", "tiempo"},
            {"work", "trabajo"}
        };

            [HttpGet("{palabra}")]
            public ActionResult<object> Traducir(string palabra)
            {
         

                if (_traducciones.TryGetValue(palabra, out string? traduccion))
                {
                    return Ok(new
                    {
                        PalabraIngles = palabra,
                        PalabraEspanol = traduccion,
                    });
                }
                else
                {
                    return NotFound(new
                    {
                        PalabraIngles = palabra,
                        Mensaje = "Palabra no encontrada en el diccionario"
                    });
                }
            }

            [HttpGet("todas")]
            public ActionResult<object> ObtenerTodasLasTraducciones()
            {
                return Ok(_traducciones);
            }

           
        }
}


