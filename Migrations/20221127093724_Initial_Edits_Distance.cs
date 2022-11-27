using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cars.Migrations
{
    /// <inheritdoc />
    public partial class InitialEditsDistance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Cars");

            migrationBuilder.AddColumn<float>(
                name: "Distance",
                table: "Sales",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Sales");

            migrationBuilder.AddColumn<float>(
                name: "Distance",
                table: "Cars",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
