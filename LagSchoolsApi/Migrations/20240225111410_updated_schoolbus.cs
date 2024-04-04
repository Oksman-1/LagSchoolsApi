using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class updated_schoolbus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                column: "SchoolBus",
                value: true);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 2,
                column: "SchoolBus",
                value: true);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 3,
                column: "SchoolBus",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                column: "SchoolBus",
                value: false);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 2,
                column: "SchoolBus",
                value: false);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 3,
                column: "SchoolBus",
                value: false);
        }
    }
}
