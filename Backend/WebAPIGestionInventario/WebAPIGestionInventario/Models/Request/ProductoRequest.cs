using System.ComponentModel.DataAnnotations;

namespace WebAPIGestionInventario.Models.Request
{
    public class ProductoRequest
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
    }
}
