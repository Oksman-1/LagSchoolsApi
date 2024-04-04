using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class Changed_classSize_column_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassSize",
                table: "Classes",
                newName: "ClassSize(Sq.m)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClassSize(Sq.m)",
                table: "Classes",
                newName: "ClassSize");
        }
    }
}
