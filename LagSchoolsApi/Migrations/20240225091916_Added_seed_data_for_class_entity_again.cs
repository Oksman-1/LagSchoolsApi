using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_seed_data_for_class_entity_again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "ClassId", "ClassDesignation", "ClassName", "ClassSize", "HeadClassTeacherName", "NumberOfArms", "SchoolId" },
                values: new object[,]
                {
                    { 1, 1, "JSS1", 231.108, "Mr Ifeanyi Eboigbe", 5, 1 },
                    { 2, 3, "JSS3", 231.108, "Mrs Dapo Oguniyi", 6, 1 },
                    { 3, 4, "SS1", 231.108, "Mr Felix Okafor", 6, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "ClassId",
                keyValue: 3);
        }
    }
}
