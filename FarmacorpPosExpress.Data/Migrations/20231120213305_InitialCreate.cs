using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmacorpPosExpress.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_ParentCategoryId",
                        column: x => x.ParentCategoryId,
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
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 20, 17, 33, 5, 250, DateTimeKind.Local).AddTicks(9320)),
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
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 11, 20, 17, 33, 5, 260, DateTimeKind.Local).AddTicks(8096)),
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

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_ParentCategoryId",
                table: "Categoria",
                column: "ParentCategoryId");

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
