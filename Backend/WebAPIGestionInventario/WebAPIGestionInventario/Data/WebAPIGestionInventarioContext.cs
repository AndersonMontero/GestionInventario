using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIGestionInventario.Models;

namespace WebAPIGestionInventario.Data
{
    public class WebAPIGestionInventarioContext : DbContext
    {
        public WebAPIGestionInventarioContext (DbContextOptions<WebAPIGestionInventarioContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } = default!;
        public DbSet<WebAPIGestionInventario.Models.MovimientoProductos> MovimientoProductos { get; set; } = default!;
    }
}
