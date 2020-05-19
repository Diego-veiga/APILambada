using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APILambada.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tecnico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 25, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tecnico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lambada",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    DataLambada = table.Column<DateTime>(nullable: false),
                    TecnicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lambada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lambada_Tecnico_TecnicoId",
                        column: x => x.TecnicoId,
                        principalTable: "Tecnico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lambada_TecnicoId",
                table: "Lambada",
                column: "TecnicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lambada");

            migrationBuilder.DropTable(
                name: "Tecnico");
        }
    }
}
