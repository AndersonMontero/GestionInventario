using System.ComponentModel.DataAnnotations;

namespace WebAPIGestionInventario.Models.Dto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
    }
}
