using _27.OrdenarUsuariosEdad.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _27.OrdenarUsuariosEdad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuarios> _usuarios = new ()
        {

            new Usuarios { Id = 1, Nombre = "Ana", Apellido = "García", Edad = 28 },
            new Usuarios { Id = 2, Nombre = "Carlos", Apellido = "López", Edad = 35 },
            new Usuarios { Id = 3, Nombre = "María", Apellido = "Rodríguez", Edad = 22 },
            new Usuarios { Id = 4, Nombre = "Juan", Apellido = "Martínez", Edad = 42 },
            new Usuarios { Id = 5, Nombre = "Matias", Apellido = "Moron", Edad = 20 },

        };
        [HttpGet("ordenados")]
        public IActionResult GetUsuariosOrdenados([FromBody] string orden )
        {
            try
            {
                IEnumerable<Usuarios> usuariosOrdenados;

                switch (orden)
                {
                    case "ascendente":
                        usuariosOrdenados = _usuarios
                            .OrderBy(u => u.Edad)
                            .ThenBy(u => u.Apellido)  
                            .ThenBy(u => u.Nombre);   
                        break;

                    case "descendente":
                        usuariosOrdenados = _usuarios
                            .OrderByDescending(u => u.Edad)
                            .ThenBy(u => u.Apellido)
                            .ThenBy(u => u.Nombre);
                        break;

                    default:
                        return BadRequest( "El parámetro 'orden' debe ser 'ascendente' o 'descendente'" );
                }

                if (!usuariosOrdenados.Any())
                {
                    return NotFound("No se encontraron usuarios" );
                }

                return Ok(usuariosOrdenados);
            }
            catch (Exception error) 
            {
                return BadRequest( error.Message);
            }


        }
    }
}
