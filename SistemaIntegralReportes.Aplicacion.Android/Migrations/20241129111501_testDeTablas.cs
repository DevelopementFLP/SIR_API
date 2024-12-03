using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaIntegralReportes.Aplicacion.Android.Migrations
{
    public partial class testDeTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "test_sector_de_incidente",
                columns: table => new
                {
                    IdSectorIncidente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_sector_de_incidente", x => x.IdSectorIncidente);
                });

            migrationBuilder.CreateTable(
                name: "test_tipo_de_incidente",
                columns: table => new
                {
                    IdTipoDeIncidente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdSectorDeIncidente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_tipo_de_incidente", x => x.IdTipoDeIncidente);
                    table.ForeignKey(
                        name: "FK_test_tipo_de_incidente_test_sector_de_incidente_IdSectorDeIncidente",
                        column: x => x.IdSectorDeIncidente,
                        principalTable: "test_sector_de_incidente",
                        principalColumn: "IdSectorIncidente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "test_incidentes",
                columns: table => new
                {
                    IdIncidente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigoQr = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PuestoDeTrabajo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoDeEmpleado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreDeEmpleado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Producto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdTipoDeIncidente = table.Column<int>(type: "int", nullable: false),
                    ImagenDeIncidente = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    CodigoDeProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test_incidentes", x => x.IdIncidente);
                    table.ForeignKey(
                        name: "FK_test_incidentes_test_tipo_de_incidente_IdTipoDeIncidente",
                        column: x => x.IdTipoDeIncidente,
                        principalTable: "test_tipo_de_incidente",
                        principalColumn: "IdTipoDeIncidente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_test_incidentes_IdTipoDeIncidente",
                table: "test_incidentes",
                column: "IdTipoDeIncidente");

            migrationBuilder.CreateIndex(
                name: "IX_test_tipo_de_incidente_IdSectorDeIncidente",
                table: "test_tipo_de_incidente",
                column: "IdSectorDeIncidente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "test_incidentes");

            migrationBuilder.DropTable(
                name: "test_tipo_de_incidente");

            migrationBuilder.DropTable(
                name: "test_sector_de_incidente");
        }
    }
}
