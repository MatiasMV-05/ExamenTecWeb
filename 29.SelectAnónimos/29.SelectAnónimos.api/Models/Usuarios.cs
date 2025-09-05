using System.ComponentModel.DataAnnotations;

namespace _29.SelectAnónimos.api.Usuario
{
    public class Usuarios
    {
      
            [Key]
            public int Id { get; set; }
            [Required]
            public string Nombre { get; set; }

            [Required]
            public string Apellido { get; set; }

            [Required]
            public int Edad { get; set; }
        
    }
}
