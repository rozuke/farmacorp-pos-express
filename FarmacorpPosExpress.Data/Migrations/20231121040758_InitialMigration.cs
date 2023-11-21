using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmacorpPosExpress.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    IdCategoriaPadre = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_IdCategoriaPadre",
                        column: x => x.IdCategoriaPadre,
                        principalTable: "Categoria",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TiposProducto",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProducto", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ExpProducto",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpProducto", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_ExpProducto_TiposProducto_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "TiposProducto",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpProducto_TiposProducto_ProductTypeId1",
                        column: x => x.ProductTypeId1,
                        principalTable: "TiposProducto",
                        principalColumn: "ProductTypeId");
                });

            migrationBuilder.CreateTable(
                name: "CodigosBarras",
                columns: table => new
                {
                    BarCodeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueCodigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ExpProductId = table.Column<int>(type: "int", nullable: false),
                    ExpProductProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodigosBarras", x => x.BarCodeId);
                    table.ForeignKey(
                        name: "FK_CodigosBarras_ExpProducto_ExpProductId",
                        column: x => x.ExpProductId,
                        principalTable: "ExpProducto",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CodigosBarras_ExpProducto_ExpProductProductId",
                        column: x => x.ExpProductProductId,
                        principalTable: "ExpProducto",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ErpProductos",
                columns: table => new
                {
                    ErpProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Costo = table.Column<double>(type: "float", nullable: false),
                    UniqueCodigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 21, 0, 7, 57, 736, DateTimeKind.Local).AddTicks(1127)),
                    ExpProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpProductos", x => x.ErpProductId);
                    table.ForeignKey(
                        name: "FK_ErpProductos_ExpProducto_ExpProductId",
                        column: x => x.ExpProductId,
                        principalTable: "ExpProducto",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductosCategorias",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 21, 0, 7, 57, 739, DateTimeKind.Local).AddTicks(8379)),
                    ExpProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductosCategorias", x => x.ProductCategoryId);
                    table.ForeignKey(
                        name: "FK_ProductosCategorias_Categoria_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categoria",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductosCategorias_ExpProducto_ExpProductId",
                        column: x => x.ExpProductId,
                        principalTable: "ExpProducto",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaExpress",
                columns: table => new
                {
                    ExpressSaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UniqueProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Descuento = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ExpProductId = table.Column<int>(type: "int", nullable: false),
                    ExpProductProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaExpress", x => x.ExpressSaleId);
                    table.ForeignKey(
                        name: "FK_VentaExpress_ExpProducto_ExpProductId",
                        column: x => x.ExpProductId,
                        principalTable: "ExpProducto",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaExpress_ExpProducto_ExpProductProductId",
                        column: x => x.ExpProductProductId,
                        principalTable: "ExpProducto",
                        principalColumn: "ProductId");
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Activo", "Descripcion", "IdCategoriaPadre" },
                values: new object[] { 1, true, "Categoría A", null });

            migrationBuilder.InsertData(
                table: "TiposProducto",
                columns: new[] { "ProductTypeId", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Tipo 1" },
                    { 2, "Tipo 2" }
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Activo", "Descripcion", "IdCategoriaPadre" },
                values: new object[] { 2, true, "Categoría B", 1 });

            migrationBuilder.InsertData(
                table: "ExpProducto",
                columns: new[] { "ProductId", "Activo", "FechaVencimiento", "Nombre", "Observaciones", "Precio", "ProductTypeId", "ProductTypeId1" },
                values: new object[,]
                {
                    { 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Producto 1", "Producto bueno", 20.0, 1, null },
                    { 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Producto 2", "Producto bueno", 30.0, 2, null }
                });

            migrationBuilder.InsertData(
                table: "CodigosBarras",
                columns: new[] { "BarCodeId", "active", "ExpProductId", "ExpProductProductId", "UniqueCodigo" },
                values: new object[,]
                {
                    { 1, true, 1, null, "123456" },
                    { 2, true, 2, null, "789012" }
                });

            migrationBuilder.InsertData(
                table: "ErpProductos",
                columns: new[] { "ErpProductId", "Costo", "ExpProductId", "Stock", "UniqueCodigo" },
                values: new object[,]
                {
                    { 1, 10.5, 1, 100, "ERP001" },
                    { 2, 15.75, 2, 150, "ERP002" }
                });

            migrationBuilder.InsertData(
                table: "VentaExpress",
                columns: new[] { "ExpressSaleId", "Cliente", "Fecha", "Descuento", "ExpProductId", "ExpProductProductId", "Precio", "Cantidad", "Total", "UniqueProducto" },
                values: new object[,]
                {
                    { 1, "Cliente 1", new DateTime(2023, 11, 21, 0, 7, 57, 740, DateTimeKind.Local).AddTicks(1928), 0.0, 1, null, 15.0, 5, 75.0, "123456" },
                    { 2, "Cliente 2", new DateTime(2023, 11, 21, 0, 7, 57, 740, DateTimeKind.Local).AddTicks(1934), 0.0, 2, null, 25.0, 10, 250.0, "789012" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_IdCategoriaPadre",
                table: "Categoria",
                column: "IdCategoriaPadre");

            migrationBuilder.CreateIndex(
                name: "IX_CodigosBarras_ExpProductId",
                table: "CodigosBarras",
                column: "ExpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CodigosBarras_ExpProductProductId",
                table: "CodigosBarras",
                column: "ExpProductProductId",
                unique: true,
                filter: "[ExpProductProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ErpProductos_ExpProductId",
                table: "ErpProductos",
                column: "ExpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpProducto_ProductTypeId",
                table: "ExpProducto",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpProducto_ProductTypeId1",
                table: "ExpProducto",
                column: "ProductTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosCategorias_CategoryId",
                table: "ProductosCategorias",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductosCategorias_ExpProductId",
                table: "ProductosCategorias",
                column: "ExpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaExpress_ExpProductId",
                table: "VentaExpress",
                column: "ExpProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaExpress_ExpProductProductId",
                table: "VentaExpress",
                column: "ExpProductProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodigosBarras");

            migrationBuilder.DropTable(
                name: "ErpProductos");

            migrationBuilder.DropTable(
                name: "ProductosCategorias");

            migrationBuilder.DropTable(
                name: "VentaExpress");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "ExpProducto");

            migrationBuilder.DropTable(
                name: "TiposProducto");
        }
    }
}
