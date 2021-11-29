using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Emigrante.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDoc = table.Column<int>(type: "int", nullable: false),
                    NumDoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionActual = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaginaWeb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sector = table.Column<int>(type: "int", nullable: true),
                    Categoria = table.Column<int>(type: "int", nullable: true),
                    Situacionlaboral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntidadId = table.Column<int>(type: "int", nullable: true),
                    Dependencia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grupos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Relacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MigranteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grupos_Personas_MigranteId",
                        column: x => x.MigranteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MigranteId = table.Column<int>(type: "int", nullable: true),
                    EntidadId = table.Column<int>(type: "int", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Categoria = table.Column<int>(type: "int", nullable: false),
                    Cupos = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Personas_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servicios_Personas_MigranteId",
                        column: x => x.MigranteId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_MigranteId",
                table: "Grupos",
                column: "MigranteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EntidadId",
                table: "Personas",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_EntidadId",
                table: "Servicios",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_MigranteId",
                table: "Servicios",
                column: "MigranteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grupos");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
