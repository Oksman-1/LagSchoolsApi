using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class modified_LandArea_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LandArea",
                table: "Schools",
                newName: "LandArea(Sq.km)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LandArea(Sq.km)",
                table: "Schools",
                newName: "LandArea");
        }
    }
}
