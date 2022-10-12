using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ARTICULOS_API.Entities;

namespace ARTICULOS_API.DBContext
{
    public partial class ArticulosDBContext : DbContext
    {
        public ArticulosDBContext(){}

        public ArticulosDBContext(DbContextOptions<ArticulosDBContext> options): base(options){}

        public virtual DbSet<Articulos> Articulos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articulos>().HasData(new Articulos
            {
                ArticuloId = 1,
                Descripcion = "Smart Phone",
                Marca = "Samsung",
                Existencia= 10
            });

            modelBuilder.Entity<Articulos>().HasData(new Articulos
            {
                ArticuloId = 2,
                Descripcion = "Smart TV",
                Marca = "Samsung",
                Existencia= 5
            });

            modelBuilder.Entity<Articulos>().HasData(new Articulos
            {
                ArticuloId = 3,
                Descripcion = "iPhone 14",
                Marca = "Apple",
                Existencia= 10
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
