using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaIntegralReportes.AplicacionDePedidos.Migrations
{
    public partial class migracionDeInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comp_almacen",
                columns: table => new
                {
                    IdAlmacen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_almacen", x => x.IdAlmacen);
                });

            migrationBuilder.CreateTable(
                name: "comp_area_destino",
                columns: table => new
                {
                    IdAreaDestino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_area_destino", x => x.IdAreaDestino);
                });

            migrationBuilder.CreateTable(
                name: "comp_centro_de_costo",
                columns: table => new
                {
                    IdCentroDeCosto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    CodigoAlternativo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_centro_de_costo", x => x.IdCentroDeCosto);
                });

            migrationBuilder.CreateTable(
                name: "comp_departamento",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_departamento", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "comp_empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "comp_estado_de_solicitud",
                columns: table => new
                {
                    IdEstadoDeSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_estado_de_solicitud", x => x.IdEstadoDeSolicitud);
                });

            migrationBuilder.CreateTable(
                name: "comp_prioridad_de_orden",
                columns: table => new
                {
                    IdPriodidadDeOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_prioridad_de_orden", x => x.IdPriodidadDeOrden);
                });

            migrationBuilder.CreateTable(
                name: "comp_rol_de_usuario",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_rol_de_usuario", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "comp_tipo_de_unidad",
                columns: table => new
                {
                    IdTipoDeUnidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_tipo_de_unidad", x => x.IdTipoDeUnidad);
                });

            migrationBuilder.CreateTable(
                name: "comp_ubicacion_destino",
                columns: table => new
                {
                    IdUbicacionDestino = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlmacenIdAlmacen = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_ubicacion_destino", x => x.IdUbicacionDestino);
                    table.ForeignKey(
                        name: "FK_comp_ubicacion_destino_comp_almacen_AlmacenIdAlmacen",
                        column: x => x.AlmacenIdAlmacen,
                        principalTable: "comp_almacen",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comp_usuario_solicitante",
                columns: table => new
                {
                    IdUsuarioSolicitante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_usuario_solicitante", x => x.IdUsuarioSolicitante);
                    table.ForeignKey(
                        name: "FK_comp_usuario_solicitante_comp_departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "comp_departamento",
                        principalColumn: "IdDepartamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_usuario_solicitante_comp_rol_de_usuario_IdRol",
                        column: x => x.IdRol,
                        principalTable: "comp_rol_de_usuario",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comp_producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoDeProducto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CodigoDeProductoAlternativo = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CodigoDeProductoAlternativo2 = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    FechaDeRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaDeActualizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    IdTipoDeUnidad = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_comp_producto_comp_tipo_de_unidad_IdTipoDeUnidad",
                        column: x => x.IdTipoDeUnidad,
                        principalTable: "comp_tipo_de_unidad",
                        principalColumn: "IdTipoDeUnidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comp_orden_de_solicitud",
                columns: table => new
                {
                    IdOrdenDeSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaDecreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    IdEstadoDeSolicitud = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioSolicitante = table.Column<int>(type: "int", nullable: false),
                    IdPriodidadDeOrden = table.Column<int>(type: "int", nullable: false),
                    IdCentroDeCosto = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_orden_de_solicitud", x => x.IdOrdenDeSolicitud);
                    table.ForeignKey(
                        name: "FK_comp_orden_de_solicitud_comp_centro_de_costo_IdCentroDeCosto",
                        column: x => x.IdCentroDeCosto,
                        principalTable: "comp_centro_de_costo",
                        principalColumn: "IdCentroDeCosto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_orden_de_solicitud_comp_empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "comp_empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_orden_de_solicitud_comp_estado_de_solicitud_IdEstadoDeSolicitud",
                        column: x => x.IdEstadoDeSolicitud,
                        principalTable: "comp_estado_de_solicitud",
                        principalColumn: "IdEstadoDeSolicitud",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_orden_de_solicitud_comp_prioridad_de_orden_IdPriodidadDeOrden",
                        column: x => x.IdPriodidadDeOrden,
                        principalTable: "comp_prioridad_de_orden",
                        principalColumn: "IdPriodidadDeOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_orden_de_solicitud_comp_usuario_solicitante_IdUsuarioSolicitante",
                        column: x => x.IdUsuarioSolicitante,
                        principalTable: "comp_usuario_solicitante",
                        principalColumn: "IdUsuarioSolicitante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comp_stock_producto",
                columns: table => new
                {
                    IdStockProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAlmacen = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    FechaDeActualizacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_stock_producto", x => x.IdStockProducto);
                    table.ForeignKey(
                        name: "FK_comp_stock_producto_comp_almacen_IdAlmacen",
                        column: x => x.IdAlmacen,
                        principalTable: "comp_almacen",
                        principalColumn: "IdAlmacen",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_stock_producto_comp_empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalTable: "comp_empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_stock_producto_comp_producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "comp_producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comp_linea_de_solicitud",
                columns: table => new
                {
                    IdLineaDeSolicitud = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdenDeSolicitud = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdAreaDestino = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comp_linea_de_solicitud", x => x.IdLineaDeSolicitud);
                    table.ForeignKey(
                        name: "FK_comp_linea_de_solicitud_comp_area_destino_IdAreaDestino",
                        column: x => x.IdAreaDestino,
                        principalTable: "comp_area_destino",
                        principalColumn: "IdAreaDestino",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_linea_de_solicitud_comp_orden_de_solicitud_IdOrdenDeSolicitud",
                        column: x => x.IdOrdenDeSolicitud,
                        principalTable: "comp_orden_de_solicitud",
                        principalColumn: "IdOrdenDeSolicitud",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comp_linea_de_solicitud_comp_producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "comp_producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comp_linea_de_solicitud_IdAreaDestino",
                table: "comp_linea_de_solicitud",
                column: "IdAreaDestino");

            migrationBuilder.CreateIndex(
                name: "IX_comp_linea_de_solicitud_IdOrdenDeSolicitud",
                table: "comp_linea_de_solicitud",
                column: "IdOrdenDeSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_comp_linea_de_solicitud_IdProducto",
                table: "comp_linea_de_solicitud",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_comp_orden_de_solicitud_IdCentroDeCosto",
                table: "comp_orden_de_solicitud",
                column: "IdCentroDeCosto");

            migrationBuilder.CreateIndex(
                name: "IX_comp_orden_de_solicitud_IdEmpresa",
                table: "comp_orden_de_solicitud",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_comp_orden_de_solicitud_IdEstadoDeSolicitud",
                table: "comp_orden_de_solicitud",
                column: "IdEstadoDeSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_comp_orden_de_solicitud_IdPriodidadDeOrden",
                table: "comp_orden_de_solicitud",
                column: "IdPriodidadDeOrden");

            migrationBuilder.CreateIndex(
                name: "IX_comp_orden_de_solicitud_IdUsuarioSolicitante",
                table: "comp_orden_de_solicitud",
                column: "IdUsuarioSolicitante");

            migrationBuilder.CreateIndex(
                name: "IX_comp_producto_IdTipoDeUnidad",
                table: "comp_producto",
                column: "IdTipoDeUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_comp_stock_producto_IdAlmacen",
                table: "comp_stock_producto",
                column: "IdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_comp_stock_producto_IdEmpresa",
                table: "comp_stock_producto",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_comp_stock_producto_IdProducto",
                table: "comp_stock_producto",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_comp_ubicacion_destino_AlmacenIdAlmacen",
                table: "comp_ubicacion_destino",
                column: "AlmacenIdAlmacen");

            migrationBuilder.CreateIndex(
                name: "IX_comp_usuario_solicitante_IdDepartamento",
                table: "comp_usuario_solicitante",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_comp_usuario_solicitante_IdRol",
                table: "comp_usuario_solicitante",
                column: "IdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comp_linea_de_solicitud");

            migrationBuilder.DropTable(
                name: "comp_stock_producto");

            migrationBuilder.DropTable(
                name: "comp_ubicacion_destino");

            migrationBuilder.DropTable(
                name: "comp_area_destino");

            migrationBuilder.DropTable(
                name: "comp_orden_de_solicitud");

            migrationBuilder.DropTable(
                name: "comp_producto");

            migrationBuilder.DropTable(
                name: "comp_almacen");

            migrationBuilder.DropTable(
                name: "comp_centro_de_costo");

            migrationBuilder.DropTable(
                name: "comp_empresa");

            migrationBuilder.DropTable(
                name: "comp_estado_de_solicitud");

            migrationBuilder.DropTable(
                name: "comp_prioridad_de_orden");

            migrationBuilder.DropTable(
                name: "comp_usuario_solicitante");

            migrationBuilder.DropTable(
                name: "comp_tipo_de_unidad");

            migrationBuilder.DropTable(
                name: "comp_departamento");

            migrationBuilder.DropTable(
                name: "comp_rol_de_usuario");
        }
    }
}
