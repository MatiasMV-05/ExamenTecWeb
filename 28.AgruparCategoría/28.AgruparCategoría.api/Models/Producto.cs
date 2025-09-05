using System.ComponentModel.DataAnnotations;

namespace _28.AgruparCategoría.api.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public string Categoria { get; set; }
    }
}
