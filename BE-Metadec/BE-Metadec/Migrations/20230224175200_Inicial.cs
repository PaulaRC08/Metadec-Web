using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_Metadec.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MD_Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pais = table.Column<string>(type: "varchar(60)", nullable: false),
                    CodigoPais = table.Column<string>(type: "varchar(5)", nullable: false),
                    Longitud = table.Column<string>(type: "varchar(30)", nullable: false),
                    Latitud = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MD_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "varchar(50)", nullable: false),
                    TipoUsuario = table.Column<string>(type: "varchar(10)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "varchar(80)", nullable: false),
                    Nombres = table.Column<string>(type: "varchar(100)", nullable: false),
                    Apellidos = table.Column<string>(type: "varchar(100)", nullable: false),
                    Sexo = table.Column<string>(type: "varchar(10)", nullable: false),
                    Correo = table.Column<string>(type: "varchar(70)", nullable: false),
                    TratamientoDatos = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivoJuego = table.Column<bool>(type: "bit", nullable: false),
                    ActivoWeb = table.Column<bool>(type: "bit", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_MD_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "MD_Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PaisId",
                table: "Usuario",
                column: "PaisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "MD_Pais");
        }
    }
}
