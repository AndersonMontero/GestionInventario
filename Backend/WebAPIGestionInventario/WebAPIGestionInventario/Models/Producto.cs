using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIGestionInventario.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaCreacion { get; set; } 
    }
}
