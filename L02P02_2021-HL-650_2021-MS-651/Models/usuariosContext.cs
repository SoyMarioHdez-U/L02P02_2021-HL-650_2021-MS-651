﻿using Microsoft.EntityFrameworkCore;

namespace L02P02_2021_HL_650_2021_MS_651.Models
{
	public class usuariosContext : DbContext
	{

		public usuariosContext(DbContextOptions options) : base(options) 
		{


		}
        public DbSet<clientes> clientes { get; set; }

		public DbSet<puestos> puestos { get; set; }
		public DbSet<departamentos> departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración personalizada aquí, si es necesario
            modelBuilder.Entity<clientes>()
                .Property(c => c.id)
                .ValueGeneratedOnAdd(); // Configurar id como autoincremental
        }
    }
}
