using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
	public void Configure(EntityTypeBuilder<Student> builder)
	{
		builder.HasData
		(
		new Student
		{
			StudentId = 1,
			FirstName = "Adenike",
			LastName = "Ogunbiyi",
			ClassName = "JSS1",
			Sex = Sex.Female,
			DateOfBirth = new DateTime(2016,03,09),	
			Age = 8,
			Weight = 28.118,
			Height = 133.213,
			Address = "No 34, Akunwunmi Close VI Lagos",
			ParentsPhoneNumber = "09125478954",
			Email = "adeikeOguns_33@gmail.com",
			StateOfOrigin = "Lagos",
			LGA = "Berger",
			Nationality = "Nigeria",
			DateOfAdmission = new DateTime(2023,04,23),
			ExpectedDateOfGraduation = new DateTime(2029,04,23),
			SchoolAreaCode = "VI/03",
			SchoolCode = "A03/AG",
			StudentType = StudentType.Day,
			MedicalCondition = MedicalCondition.Normal,
			ClubAffiliation = ClubAffiliation.ChessClub,
			SchoolId = 1,
			ClassId = 1
		}
		
	   );
	}

}