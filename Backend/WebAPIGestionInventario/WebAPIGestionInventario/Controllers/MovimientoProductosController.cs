using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIGestionInventario.Data;
using WebAPIGestionInventario.Models;
using WebAPIGestionInventario.Models.Dto;
using WebAPIGestionInventario.Models.Request;

namespace WebAPIGestionInventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovimientoProductosController : ControllerBase
    {
        private readonly WebAPIGestionInventarioContext _context;

        public MovimientoProductosController(WebAPIGestionInventarioContext context)
        {
            _context = context;
        }

        // GET: api/MovimientoProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductoDto>>> GetMovimientoProductos()
        {
            var currentInventory = _context.Productos.ToList();
            return Ok(currentInventory);
        }


        // POST: api/MovimientoProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovimientoProductosDto>> PostMovimientoProductos(MovimientoProductosRequest movimientoProductos)
        {
            MovimientoProductos movimiento = new()
            {
                IdTipoMovimiento = movimientoProductos.IdTipoMovimiento,
                TipoMovimiento = movimientoProductos.TipoMovimiento,
                ProductoId = movimientoProductos.ProductoId,
                FechaMovimiento = DateTime.UtcNow,
                Cantidad = movimientoProductos.Cantidad
            };


            _context.MovimientoProductos.Add(movimiento);
            var producto = await _context.Productos.FindAsync(movimientoProductos.ProductoId);

            if (producto != null)
            {
                if (movimientoProductos.IdTipoMovimiento.Equals(1))
                {
                    producto.Cantidad += movimientoProductos.Cantidad;
                }
                else
                {
                    producto.Cantidad -= movimientoProductos.Cantidad;
                }
            }

           var response = await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovimientoProductos", response);
        }

    }
}
