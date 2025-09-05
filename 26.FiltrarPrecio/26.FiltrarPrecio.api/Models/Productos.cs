using System.ComponentModel.DataAnnotations;

namespace _26.FiltrarPrecio.api.Models
{
    public class Productos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
       
    }
}
