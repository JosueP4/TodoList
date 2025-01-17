using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TO_DO_LIST.Migrations
{
    /// <inheritdoc />
    public partial class CreacionTablausuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TO-DO-LIST",
                table: "TO-DO-LIST");

            migrationBuilder.RenameTable(
                name: "TO-DO-LIST",
                newName: "Tareas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Tareas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUser);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUser", "Password", "User", "rol" },
                values: new object[,]
                {
                    { -2, "ariel1020", "Ariel", "empleado" },
                    { -1, "josue1020", "josue", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tareas",
                table: "Tareas");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Tareas");

            migrationBuilder.RenameTable(
                name: "Tareas",
                newName: "TO-DO-LIST");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TO-DO-LIST",
                table: "TO-DO-LIST",
                column: "id");
        }
    }
}
