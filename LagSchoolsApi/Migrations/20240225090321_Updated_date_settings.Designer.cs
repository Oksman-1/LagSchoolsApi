﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace LagSchoolsApi.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240225090321_Updated_date_settings")]
    partial class Updated_date_settings
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<int?>("ClassDesignation")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ClassSize")
                        .HasColumnType("float");

                    b.Property<string>("HeadClassTeacherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfArms")
                        .HasColumnType("int");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Entities.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SchoolId"));

                    b.Property<DateTime?>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateWAECApproved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("LandArea")
                        .HasColumnType("float");

                    b.Property<int>("NumberSchoolBus")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolAreaCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SchoolBus")
                        .HasColumnType("bit");

                    b.Property<string>("SchoolDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolLocation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SchoolType")
                        .HasColumnType("int");

                    b.Property<int?>("SecurityLevel")
                        .HasColumnType("int");

                    b.Property<string>("SummarySchoolFacilities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WAECApproved")
                        .HasColumnType("bit");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");

                    b.HasData(
                        new
                        {
                            SchoolId = 1,
                            DateOpened = new DateTime(1988, 2, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateWAECApproved = new DateTime(1990, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "vinefields_sch@gmail.com",
                            LandArea = 2310.3449999999998,
                            NumberSchoolBus = 6,
                            PhoneNumber = "016403300",
                            SchoolAddress = "21, Sinari Daramijo, Victoria Island, Lagos Nigeria",
                            SchoolAreaCode = "VI/03",
                            SchoolBus = false,
                            SchoolDescription = "Vinefield School is an advanced educational institution sited in Victoria Island renowned for delivering qualitative and sound educational program in a conducive environment.\r\n",
                            SchoolLocation = "Victoria Island",
                            SchoolName = "Vinefield School",
                            SchoolType = 3,
                            SecurityLevel = 1,
                            SummarySchoolFacilities = "Library,Gymnasium,Swimming Pool,laboratories,School Hall,Hostels",
                            WAECApproved = true,
                            Website = "https://www.vinefield.com/"
                        });
                });

            modelBuilder.Entity("Entities.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ClubAffiliation")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfAdmission")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExpectedDateOfGraduation")
                        .HasColumnType("datetime2")
                        .HasColumnName("ExpectedDateofGrad");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Height")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("LGA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MedicalCondition")
                        .HasColumnType("int");

                    b.Property<string>("NationalIdentityNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NationalIdentityNo");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParentsPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ParentPhoneNo");

                    b.Property<int>("SchoolId")
                        .HasColumnType("int");

                    b.Property<int?>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("StateOfOrigin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentRegistrationNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("StudentRegNo");

                    b.Property<int?>("StudentType")
                        .HasColumnType("int");

                    b.Property<string>("VirtualNationalIdentityNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("VNationalIdentityNo");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("StudentId");

                    b.HasIndex("ClassId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.Models.Class", b =>
                {
                    b.HasOne("Entities.Models.School", "School")
                        .WithMany("Classes")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("School");
                });

            modelBuilder.Entity("Entities.Models.Student", b =>
                {
                    b.HasOne("Entities.Models.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("School");
                });

            modelBuilder.Entity("Entities.Models.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Entities.Models.School", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
