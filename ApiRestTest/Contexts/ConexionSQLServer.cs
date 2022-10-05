using System;
using Microsoft.EntityFrameworkCore;
using ApiRestTest.Models;

namespace ApiRestTest.Contexts
{
    public class ConexionSQLServer:DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Producto> Producto { get; set; }

        public DbSet<Compra> Compra { get; set; }

    }
}

