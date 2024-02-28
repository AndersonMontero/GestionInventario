using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIGestionInventario.Models.Dto
{
    public class MovimientoProductosDto
    {
        public int IdMovimiento { get; set; }
        public int ProductoId { get; set; }
        public int IdTipoMovimiento { get; set; }
        public string TipoMovimiento { get; set; }
        public int Cantidad { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaMovimiento { get; set; }
    }
}
