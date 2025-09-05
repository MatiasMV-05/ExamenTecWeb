using _29.SelectAnónimos.api.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _29.SelectAnónimos.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
            private static List<Usuarios> _usuarios = new(){

            new Usuarios { Id = 1, Nombre = "Ana", Apellido = "García", Edad = 28 },
            new Usuarios { Id = 2, Nombre = "Carlos", Apellido = "López", Edad = 35 },
            new Usuarios { Id = 3, Nombre = "María", Apellido = "Rodríguez", Edad = 22 },
            new Usuarios { Id = 4, Nombre = "Juan", Apellido = "Martínez", Edad = 42 },
            new Usuarios { Id = 5, Nombre = "Matias", Apellido = "Moron", Edad = 20 },

            };

            [HttpGet("nombre")]
            public IActionResult GetUsuariosOrdenados()
            {
                try
                {
                    var nombres = _usuarios.Select(u => new { u.Nombre }).ToList();

                    if (!nombres.Any())
                    {
                        return NotFound("No se encontraron usuarios" );
                    }

                    return Ok(nombres);
                }
                catch (Exception error)
            {
                    return BadRequest(error.Message);
                }


            }
        
    }
}
