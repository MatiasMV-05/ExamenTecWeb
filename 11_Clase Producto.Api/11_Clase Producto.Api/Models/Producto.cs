using System.ComponentModel.DataAnnotations;

namespace _11_Clase_Producto.Api.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public float Precio { get; set; }
   

    }
}
