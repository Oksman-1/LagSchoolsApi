using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    /// <inheritdoc />
    public partial class Added_new_student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Address", "Age", "ClassId", "ClassName", "ClubAffiliation", "DateOfAdmission", "DateOfBirth", "Email", "ExpectedDateofGrad", "FirstName", "Height", "LGA", "LastName", "MedicalCondition", "NationalIdentityNo", "Nationality", "ParentPhoneNo", "SchoolId", "Sex", "StateOfOrigin", "StudentRegNo", "StudentType", "VNationalIdentityNo", "Weight" },
                values: new object[] { 1, "No 34, Akunwunmi Close VI Lagos", 8, 1, "JSS1", 2, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "adeikeOguns_33@gmail.com", new DateTime(2029, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adenike", 133.213m, "Berger", "Ogunbiyi", 1, "12202076230", "Nigeria", "09125478954", 1, 2, "Lagos", null, 1, "MX10326832018Q2", 28.118m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);
        }
    }
}
