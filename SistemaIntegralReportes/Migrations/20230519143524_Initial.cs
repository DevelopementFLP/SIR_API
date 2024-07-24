using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaIntegralReportes.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conf_modulo",
                columns: table => new
                {
                    id_modulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    icono = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    routeLink = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conf_modulo", x => x.id_modulo);
                });

            migrationBuilder.CreateTable(
                name: "conf_perfiles",
                columns: table => new
                {
                    id_perfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_perfil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conf_perfiles", x => x.id_perfil);
                });

            migrationBuilder.CreateTable(
                name: "reportes",
                columns: table => new
                {
                    id_reporte = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_modulo = table.Column<int>(type: "int", nullable: false),
                    nombre_reporte = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    icono = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    routeLink = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable: true),
                    target = table.Column<string>(type: "nchar(50)", fixedLength: true, maxLength: 50, nullable:true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.reportes", x => x.id_reporte);
                });

            migrationBuilder.CreateTable(
                name: "conf_accesos",
                columns: table => new
                {
                    id_acceso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_modulo = table.Column<int>(type: "int", nullable: false),
                    id_perfil = table.Column<int>(type: "int", nullable: false),
                    permitido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conf_accesos", x => new { x.id_acceso, x.id_modulo, x.id_perfil });
                    table.ForeignKey(
                        name: "FK_conf_accesos_conf_modulo",
                        column: x => x.id_modulo,
                        principalTable: "conf_modulo",
                        principalColumn: "id_modulo");
                    table.ForeignKey(
                        name: "FK_conf_accesos_conf_perfiles",
                        column: x => x.id_perfil,
                        principalTable: "conf_perfiles",
                        principalColumn: "id_perfil");
                });

            migrationBuilder.CreateTable(
                name: "conf_usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_perfil = table.Column<int>(type: "int", nullable: false),
                    nombre_usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    contrasenia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    nombre_completo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conf_usuarios", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_conf_usuarios_conf_perfiles",
                        column: x => x.id_perfil,
                        principalTable: "conf_perfiles",
                        principalColumn: "id_perfil");
                });

            migrationBuilder.CreateIndex(
                name: "IX_conf_accesos_id_modulo",
                table: "conf_accesos",
                column: "id_modulo");

            migrationBuilder.CreateIndex(
                name: "IX_conf_accesos_id_perfil",
                table: "conf_accesos",
                column: "id_perfil");

            migrationBuilder.CreateIndex(
                name: "IX_conf_usuarios_id_perfil",
                table: "conf_usuarios",
                column: "id_perfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conf_accesos");

            migrationBuilder.DropTable(
                name: "conf_usuarios");

            migrationBuilder.DropTable(
                name: "reportes");

            migrationBuilder.DropTable(
                name: "conf_modulo");

            migrationBuilder.DropTable(
                name: "conf_perfiles");
        }
    }
}
