using _11_Clase_Producto.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _11_Clase_Producto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private static List<Producto> productos =
            new()
            {
                new Producto { Id = 1, Nombre = "Manzana", Precio = 20  },
                new Producto { Id = 2, Nombre = "Mandarina", Precio = 19  },
                new Producto { Id = 3, Nombre = "Naranja", Precio = 15  }

            };
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetAll()
        {
            return Ok(productos);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Producto>
            GetById(int id)
        {
            var producto = productos.FirstOrDefault(x => x.Id == id);
            if (producto is not null)
                return Ok(producto);
            else
                return NotFound();
        }

        

    }
}


