using _26.FiltrarPrecio.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _26.FiltrarPrecio.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoPrecioController : ControllerBase
    {
        private static readonly List<Productos> _productos = new List<Productos>
    {
        new Productos { Id = 1, Nombre = "Laptop Gaming", Precio = 1200.99m },
        new Productos { Id = 2, Nombre = "Mouse", Precio = 25.50m},
        new Productos { Id = 3, Nombre = "Smart TV", Precio = 899.99m },

    };
        [HttpGet("caros")]
        public IActionResult GetProductosCaros()
        {
            try
            {
                var productosCaros = _productos
                    .Where(p => p.Precio > 100)
                    .ToList();

                if (!productosCaros.Any())
                {
                    return NotFound(new { message = "No se encontraron productos con precio mayor a 100" });
                }

                return Ok(productosCaros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error interno del servidor", error = ex.Message });
            }
        }
    }
}

