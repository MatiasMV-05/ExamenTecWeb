using _28.AgruparCategoría.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _28.AgruparCategoría.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private static readonly List<Producto> _productos = new List<Producto>
        {
            new Producto { Id = 1, Nombre = "Laptop", Precio = 1200.99m, Categoria = "Electrónicos" },
            new Producto { Id = 2, Nombre = "Mouse", Precio = 25.50m, Categoria = "Electrónicos"},
            new Producto { Id = 3, Nombre = "Camiseta", Precio = 29.99m, Categoria = "Ropa"},
            new Producto { Id = 4, Nombre = "Zapatos", Precio = 89.99m, Categoria = "Ropa" },
            new Producto { Id = 5, Nombre = "Sofá", Precio = 499.99m, Categoria = "mueble" },
            new Producto { Id = 6, Nombre = "Auriculares", Precio = 79.99m, Categoria = "Electrónicos"}
        };

        [HttpGet("por-categoria")]
        public ActionResult<Producto> GetProductosPorCategoria()
        {
            try
            {
                var productosPorCategoria = _productos
                    .GroupBy(p => p.Categoria)
                    .Select(grupo => new
                    {
                        Categoria = grupo.Key,
                        Productos = grupo.Select(p => new
                        {
                            p.Nombre,
                            p.Precio,

                        }).ToList()
                    })
                    .OrderBy(g => g.Categoria)
                    .ToList();

                return Ok(new
                {
                    Categorias = productosPorCategoria
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
