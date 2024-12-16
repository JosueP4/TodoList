using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TO_DO_LIST.Migrations
{
    /// <inheritdoc />
    public partial class segundamigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tareaI",
                table: "TO-DO-LIST");

            migrationBuilder.AlterColumn<bool>(
                name: "tareaC",
                table: "TO-DO-LIST",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "tarea",
                table: "TO-DO-LIST",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "tareaC",
                table: "TO-DO-LIST",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "tarea",
                table: "TO-DO-LIST",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<string>(
                name: "tareaI",
                table: "TO-DO-LIST",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
