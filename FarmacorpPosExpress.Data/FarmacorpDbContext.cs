using FarmacorpPosExpress.Models.ERP;
using FarmacorpPosExpress.Models.Express;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmacorpPosExpress.Data;

public class FarmacorpDbContext : DbContext
{
    public DbSet<BarCode> BarCodes { get; set; }
    public DbSet<ErpProduct> ErpProducts { get; set; }
    public DbSet<Category> CategoryProducts { get; set; }
    public DbSet<ExpProduct> ExpProducts { get; set; }
    public DbSet<ExpressSale> ExpressSaleProducts { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }

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
            entity.HasOne(e => e.ParentCategory).WithMany(e => e.ParentCategories).HasForeignKey(e => e.ParentCategoryId);
           
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
            entity.Property(e => e.Product).HasColumnName("Producto");
            entity.Property(e => e.UniqueProduct).HasColumnName("UniqueProducto");
            entity.Property(e => e.Quantity).HasColumnName("Cantidad");
            entity.Property(e => e.Price).HasColumnName("Precio");
            entity.Property(e => e.Discount).HasColumnName("Descuento");
            entity.Property(e => e.Total).HasColumnName("Total");
            entity.HasOne(e => e.Product).WithMany().HasForeignKey(e => e.ExpProductId);

        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId);
            entity.Property(e => e.CreationDate).HasDefaultValue(DateTime.Now);
            entity.HasOne(e => e.Product).WithMany(e => e.ProductsCategories).HasForeignKey(e => e.ExpProductId);
            entity.HasOne(e => e.Category).WithMany(e => e.ProductCategories).HasForeignKey(e => e.CategoryId);
        });

        modelBuilder.Entity<ProductType>(entity => { 
            entity.HasKey(e => e.ProductTypeId);
            entity.Property(e => e.Description).HasColumnName("Descripcion");
            
        });



        base.OnModelCreating(modelBuilder);
    }
}
