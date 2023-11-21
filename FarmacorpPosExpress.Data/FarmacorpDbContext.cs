using FarmacorpPosExpress.Models.ERP;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data;

public class FarmacorpDbContext : DbContext
{
    private string connectionString = "";
    public DbSet<BarCode> BarCodes { get; set; }
    public DbSet<ErpProduct> ErpProducts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ExpProduct> ExpProducts { get; set; }
    public DbSet<ExpressSale> ExpressSaleProducts { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

    public FarmacorpDbContext() { }
    public FarmacorpDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BarCode>(barCode =>
        {
            barCode.ToTable("CodigosBarras");
            barCode.HasKey(k => k.BarCodeId);
            barCode.Property(b => b.UniqueCode).IsRequired().HasColumnName("UniqueCodigo");
            barCode.Property(b => b.Active).HasDefaultValue(true).HasColumnName("active");
            barCode.HasOne(b => b.Product).WithMany().HasForeignKey(b => b.ExpProductId);

        });

        modelBuilder.Entity<ErpProduct>(entity =>
        {
            entity.ToTable("ErpProductos");
            entity.HasKey(e => e.ErpProductId);
            entity.Property(e => e.Cost).IsRequired().HasColumnName("Costo");
            entity.Property(e => e.UniqueCode).IsRequired().HasColumnName("UniqueCodigo");
            entity.Property(e => e.RegistrationDate).HasDefaultValue(DateTime.Now);
            entity.Property(e => e.Stock);
            entity.HasOne(e => e.ExpProduct).WithMany(e => e.ErpProducts).HasForeignKey(e => e.ExpProductId);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categoria");
            entity.HasKey(e => e.CategoryId);
            entity.Property(e => e.Description).HasColumnName("Descripcion");
            entity.Property(e => e.Active).HasDefaultValue(true).HasColumnName("Activo");
            entity.Property(e => e.ParentCategoryId).HasColumnName("IdCategoriaPadre").IsRequired(false);
            entity.HasOne(e => e.ParentCategory).WithMany(e => e.ParentCategories).HasForeignKey(e => e.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
           
        });

        modelBuilder.Entity<ExpProduct>(entity => {
            entity.ToTable("ExpProducto");
            entity.HasKey(e => e.ProductId);
            entity.Property(e => e.Name).IsRequired().HasColumnName("Nombre");
            entity.Property(e => e.Price).IsRequired().HasColumnName("Precio");
            entity.Property(e => e.Active).IsRequired().HasColumnName("Activo").HasDefaultValue(true);
            entity.Property(e => e.ExpirationDate).HasColumnName("FechaVencimiento");
            entity.Property(e => e.Observations).HasColumnName("Observaciones");
            entity.HasOne(e => e.ProductType).WithMany().HasForeignKey(e => e.ProductTypeId);
        });

        modelBuilder.Entity<ExpressSale>(entity => {
            entity.ToTable("VentaExpress");
            entity.HasKey(e => e.ExpressSaleId);
            entity.Property(e => e.Date).HasColumnName("Fecha");
            entity.Property(e => e.Client).HasColumnName("Cliente");
            entity.Property(e => e.UniqueProduct).HasColumnName("UniqueProducto");
            entity.Property(e => e.Quantity).HasColumnName("Cantidad");
            entity.Property(e => e.Price).HasColumnName("Precio");
            entity.Property(e => e.Discount).HasColumnName("Descuento");
            entity.Property(e => e.Total).HasColumnName("Total");
            entity.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ExpProductId);

        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductosCategorias");
            entity.HasKey(e => e.ProductCategoryId);
            entity.Property(e => e.CreationDate).HasDefaultValue(DateTime.Now);
            entity.HasOne(e => e.Product).WithMany(e => e.ProductsCategories).HasForeignKey(e => e.ExpProductId);
            entity.HasOne(e => e.Category).WithMany(e => e.ProductCategories).HasForeignKey(e => e.CategoryId);
        });

        modelBuilder.Entity<ProductType>(entity => {
            entity.ToTable("TiposProducto");
            entity.HasKey(e => e.ProductTypeId);
            entity.Property(e => e.Description).HasColumnName("Descripcion");
            
        });

        SeedData(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


        if(!string.IsNullOrEmpty(connectionString))
        {
            optionsBuilder.UseSqlServer(connectionString);
            Console.WriteLine("Conexion exitosa");
        } else
        {
            Console.WriteLine("Error en el string de conexion");
        }
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BarCode>().HasData(
            new BarCode { BarCodeId = 1, UniqueCode = "123456", Active = true, ExpProductId = 1 },
            new BarCode { BarCodeId = 2, UniqueCode = "789012", Active = true, ExpProductId = 2 }
        );

        modelBuilder.Entity<ExpProduct>().HasData(
            new ExpProduct { ProductId = 1, Name = "Producto 1", Price = 20.0, Active = true, ProductTypeId = 1, Observations = "Producto bueno" },
            new ExpProduct { ProductId = 2, Name = "Producto 2", Price = 30.0, Active = true, ProductTypeId = 2, Observations = "Producto bueno" }
        );

        modelBuilder.Entity<ErpProduct>().HasData(
            new ErpProduct { ErpProductId = 1, Cost = 10.5, UniqueCode = "ERP001", Stock = 100, ExpProductId = 1 },
            new ErpProduct { ErpProductId = 2, Cost = 15.75, UniqueCode = "ERP002", Stock = 150, ExpProductId = 2 }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Description = "Categoría A", Active = true },
            new Category { CategoryId = 2, Description = "Categoría B", Active = true, ParentCategoryId = 1 }
        );


        modelBuilder.Entity<ExpressSale>().HasData(
            new ExpressSale { ExpressSaleId = 1, Date = DateTime.Now, Client = "Cliente 1", UniqueProduct = "123456", Quantity = 5, Price = 15.0, Discount = 0.0, Total = 75.0, ExpProductId = 1 },
            new ExpressSale { ExpressSaleId = 2, Date = DateTime.Now, Client = "Cliente 2", UniqueProduct = "789012", Quantity = 10, Price = 25.0, Discount = 0.0, Total = 250.0, ExpProductId = 2 }
        );

        modelBuilder.Entity<ProductType>().HasData(
        new ProductType { ProductTypeId = 1, Description = "Tipo 1" },
        new ProductType { ProductTypeId = 2, Description = "Tipo 2" }
);
        modelBuilder.Entity<ProductCategory>().HasData(
            new ProductCategory { ProductCategoryId = 1, CreationDate = DateTime.Now, ExpProductId = 1,CategoryId = 1}, 
        new ProductCategory { ProductCategoryId = 2, CreationDate = DateTime.Now, ExpProductId = 2, CategoryId = 1 });
    }
}
