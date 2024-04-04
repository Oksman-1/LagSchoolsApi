using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class fff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Students",
                newName: "Weight(kg)");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "Students",
                newName: "Height(cm)");

            migrationBuilder.AlterColumn<double>(
                name: "Weight(kg)",
                table: "Students",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Height(cm)",
                table: "Students",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Height(cm)", "NationalIdentityNo", "VNationalIdentityNo", "Weight(kg)" },
                values: new object[] { 133.21299999999999, "19876019653", "MX26487972376P7", 28.117999999999999 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight(kg)",
                table: "Students",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "Height(cm)",
                table: "Students",
                newName: "Height");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Students",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Students",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                columns: new[] { "Height", "NationalIdentityNo", "VNationalIdentityNo", "Weight" },
                values: new object[] { 133.213m, "12202076230", "MX10326832018Q2", 28.118m });
        }
    }
}
