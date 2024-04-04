using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class Updated_date_settings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                columns: new[] { "DateOpened", "DateWAECApproved" },
                values: new object[] { new DateTime(1988, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                columns: new[] { "DateOpened", "DateWAECApproved" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(55) });
        }
    }
}
