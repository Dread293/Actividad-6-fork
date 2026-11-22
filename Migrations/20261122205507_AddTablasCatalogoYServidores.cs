using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Actividad_6.Migrations
{
    /// <inheritdoc />
    public partial class AddTablasCatalogoYServidores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "juegos",
                columns: table => new
                {
                    id_juego = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    nombre_juego = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    descripcion = table.Column<string>(type: "text", nullable: true),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_juegos", x => x.id_juego);
                });

            migrationBuilder.CreateTable(
                name: "version_juegos",
                columns: table => new
                {
                    id_version = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_juego = table.Column<int>(type: "integer", nullable: false),
                    version = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    etiqueta_imagen = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_version_juegos", x => x.id_version);
                    table.ForeignKey(
                        name: "FK_version_juegos_juegos_id_juego",
                        column: x => x.id_juego,
                        principalTable: "juegos",
                        principalColumn: "id_juego",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servidores",
                columns: table => new
                {
                    id_servidor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_usuario = table.Column<int>(type: "integer", nullable: false),
                    id_version = table.Column<int>(type: "integer", nullable: false),
                    nombre_servidor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    id_contenedor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    estado_requerido = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    estado_actual = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    fecha_creacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    fecha_actualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    fecha_eliminacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servidores", x => x.id_servidor);
                    table.ForeignKey(
                        name: "FK_servidores_version_juegos_id_version",
                        column: x => x.id_version,
                        principalTable: "version_juegos",
                        principalColumn: "id_version",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "configuracion_servidores",
                columns: table => new
                {
                    id_servidor = table.Column<int>(type: "integer", nullable: false),
                    nombre_mundo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    tamano_mundo = table.Column<int>(type: "integer", nullable: false),
                    dificultad = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    max_jugadores = table.Column<int>(type: "integer", nullable: false),
                    contrasena_cifrada = table.Column<string>(type: "text", nullable: true),
                    seguro = table.Column<bool>(type: "boolean", nullable: false),
                    activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_configuracion_servidores", x => x.id_servidor);
                    table.ForeignKey(
                        name: "FK_configuracion_servidores_servidores_id_servidor",
                        column: x => x.id_servidor,
                        principalTable: "servidores",
                        principalColumn: "id_servidor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_servidores_id_version",
                table: "servidores",
                column: "id_version");

            migrationBuilder.CreateIndex(
                name: "IX_version_juegos_id_juego",
                table: "version_juegos",
                column: "id_juego");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "configuracion_servidores");

            migrationBuilder.DropTable(
                name: "servidores");

            migrationBuilder.DropTable(
                name: "version_juegos");

            migrationBuilder.DropTable(
                name: "juegos");
        }
    }
}
