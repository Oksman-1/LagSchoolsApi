using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class Setting_up_Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolType = table.Column<int>(type: "int", nullable: true),
                    LandArea = table.Column<double>(type: "float", nullable: false),
                    SecurityLevel = table.Column<int>(type: "int", nullable: true),
                    WAECApproved = table.Column<bool>(type: "bit", nullable: false),
                    DateWAECApproved = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolBus = table.Column<bool>(type: "bit", nullable: false),
                    NumberSchoolBus = table.Column<int>(type: "int", nullable: false),
                    SchoolDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SummarySchoolFacilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassDesignation = table.Column<int>(type: "int", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeadClassTeacherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfArms = table.Column<int>(type: "int", nullable: false),
                    ClassSize = table.Column<double>(type: "float", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                    table.ForeignKey(
                        name: "FK_Classes_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentPhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LGA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfAdmission = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpectedDateofGrad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StudentRegNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalIdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VNationalIdentityNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentType = table.Column<int>(type: "int", nullable: true),
                    MedicalCondition = table.Column<int>(type: "int", nullable: true),
                    ClubAffiliation = table.Column<int>(type: "int", nullable: true),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Students_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "DateOpened", "DateWAECApproved", "Email", "LandArea", "NumberSchoolBus", "PhoneNumber", "SchoolAddress", "SchoolAreaCode", "SchoolBus", "SchoolDescription", "SchoolLocation", "SchoolName", "SchoolType", "SecurityLevel", "SummarySchoolFacilities", "WAECApproved", "Website" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(1957), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified).AddTicks(55), "vinefields_sch@gmail.com", 2310.3449999999998, 6, "016403300", "21, Sinari Daramijo, Victoria Island, Lagos Nigeria", "VI/03", false, "Vinefield School is an advanced educational institution sited in Victoria Island renowned for delivering qualitative and sound educational program in a conducive environment.\r\n", "Victoria Island", "Vinefield School", 3, 1, "Library,Gymnasium,Swimming Pool,laboratories,School Hall,Hostels", true, "https://www.vinefield.com/" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SchoolId",
                table: "Classes",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ClassId",
                table: "Students",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
