using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_moreschools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                column: "SchoolDescription",
                value: "Vinefield School is an advanced educational institution sited in Victoria Island renowned for delivering qualitative and sound educational program in a conducive environment.");

            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "SchoolId", "DateOpened", "DateWAECApproved", "Email", "LandArea", "NumberSchoolBus", "PhoneNumber", "SchoolAddress", "SchoolAreaCode", "SchoolBus", "SchoolDescription", "SchoolLocation", "SchoolName", "SchoolType", "SecurityLevel", "SummarySchoolFacilities", "WAECApproved", "Website" },
                values: new object[,]
                {
                    { 2, new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2001, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "white_dove@gmail.com", 1310.345, 2, "015412680", "The White Dove Drive, Off Monastery Road, By New Road Bus Stop, Km 47 Lekki-Epe Expressway, Lekki- Ajah, Lagos Nigeria", "LA/07", false, "White Dove High School is an educational institution providing outstanding all-round education of international standard while encouraging leadership qualities such as high moral standards, truthfulness, determination, hard-work, diligence and integrity.", "Lekki Ajah", "White Dove High School", 3, 3, "Library,laboratories,School Hall,Hostels", true, "https://www.whitedove.com/" },
                    { 3, new DateTime(1983, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "wisdomgate01@gmail.com", 1762.2090000000001, 4, "010025680", "4-6 Odegbami Street, Off Adeniyi Jones Avenue, Ikeja, Lagos Nigeria", "IKJ/02", false, "Wisdom Gate High School provides professional secondary educational services in lkeja.", "Ikeja", "Wisdom Gate High School", 1, 2, "Library,laboratories,School Hall", true, "https://www.wisdom_gate.com/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolId",
                keyValue: 1,
                column: "SchoolDescription",
                value: "Vinefield School is an advanced educational institution sited in Victoria Island renowned for delivering qualitative and sound educational program in a conducive environment.\r\n");

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "Age", "ClassId", "ClassName", "ClubAffiliation", "DateOfAdmission", "DateOfBirth", "Email", "ExpectedDateofGrad", "FirstName", "Height(cm)", "LGA", "LastName", "MedicalCondition", "NationalIdentityNo", "Nationality", "ParentPhoneNo", "SchoolId", "Sex", "StateOfOrigin", "StudentRegNo", "StudentType", "VNationalIdentityNo", "Weight(kg)" },
                values: new object[] { 1, "No 34, Akunwunmi Close VI Lagos", 8, 1, "JSS1", 2, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "adeikeOguns_33@gmail.com", new DateTime(2029, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adenike", 133.21299999999999, "Berger", "Ogunbiyi", 1, "19876019653", "Nigeria", "09125478954", 1, 2, "Lagos", null, 1, "MX26487972376P7", 28.117999999999999 });
        }
    }
}
