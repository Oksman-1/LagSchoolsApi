using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Student
{
	[Key]
	public int StudentId { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? ClassName { get; set; }
	public Sex? Sex { get; set; }
	public DateTime? DateOfBirth { get; set; }
	public int Age { get; set; }

	[Column("Weight(kg)")]
	public double? Weight { get; set; }

	[Column("Height(cm)")]
	public double? Height { get; set; }
	public string? Address { get; set; }

	[Display(ShortName = "ParentNumber", Name = "Parent Phonenumber(s)")]
	[Column("ParentPhoneNo")]
	public string ParentsPhoneNumber { get; set; }

	[EmailAddress(ErrorMessage = "Email address is not valid")]
	public string? Email { get; set; }
	public string? StateOfOrigin { get; set; }
	public string? LGA { get; set; }
	public string? Nationality { get; set; }
	public DateTime? DateOfAdmission { get; set; }

	[Column("ExpectedDateofGrad")]
	public DateTime? ExpectedDateOfGraduation { get; set; }

	[Column("StudentRegNo")]
	public string? StudentRegistrationNumber { get; set; }

	[NotMapped]
	public string? SchoolAreaCode { get; set; }

	[NotMapped]
	public string? SchoolCode { get; set; }

	[Display(ShortName = "NIN", Name = "National Identity Number")]
	[Column("NationalIdentityNo")]
	public string? NationalIdentityNumber { get; set; }

	[Display(ShortName = "VNIN", Name = "Virtual National Identity Number")]
	[Column("VNationalIdentityNo")]
	public string? VirtualNationalIdentityNumber { get; set; }

	[EnumDataType(typeof(StudentType), ErrorMessage = "Please enter a valid Student Type")]
	public StudentType? StudentType { get; set; }

	[EnumDataType(typeof(MedicalCondition), ErrorMessage = "Please enter a valid Medical Condition")]
	public MedicalCondition? MedicalCondition { get; set; }

	[EnumDataType(typeof(ClubAffiliation), ErrorMessage = "Please enter a valid Club Affiliation")]
	public ClubAffiliation? ClubAffiliation { get; set; }

	[ForeignKey(nameof(SchoolId))]
	public int SchoolId { get; set; }

	[ForeignKey(nameof(ClassId))]
	public int ClassId { get; set; }
	public School? School { get; set; }
	public Class? Class { get; set; }

	//Generate NationalIdentityNumber and VirtualNationalIdentityNumber in Constructor
	public Student()
	{
		var GeneratedVNIN = "";
		Random randNIN = new Random();
		
		NationalIdentityNumber = Convert.ToString((long)Math.Floor(randNIN.NextDouble() * 19_000_000_000L + 10_000_000_000L));
		GeneratedVNIN = Convert.ToString((long)Math.Floor(randNIN.NextDouble() * 19_000_000_000L + 10_000_000_000L));

		var firstCode = GeneratedVNIN[0].ToString();
		var lastCode = GeneratedVNIN[^1].ToString();

		VirtualNationalIdentityNumber = $"{VNINNumFirstCode(firstCode)}{GeneratedVNIN}{VNINNumLastCode(lastCode)}";

	}

	private static string? VNINNumFirstCode(string? firstNum)
	{
		var result = 0;

		bool validNum = int.TryParse(firstNum, out result);

		if (validNum)
		{
			for (int i = 0; i < 10; i++)
			{
				if (result >= 0 && result <= 5)
				{
					return "MX";
				}
				else if (result >= 6 && result <= 9)
				{
					return "GX";
				}
			}
		}

		return null;
	}

	private static string? VNINNumLastCode(string? lastNum)
	{
		return lastNum switch
		{
			"0" => "B1",
			"1" => "H3",
			"2" => "G5",
			"3" => "R8",
			"4" => "A6",
			"5" => "C0",
			"6" => "P7",
			"7" => "K4",
			"8" => "Q2",
			"9" => "Z9",
			_ => null
		};
	}
}

public enum Sex
{
	Male = 1,
	Female = 2,
	Other = 3
}

public enum MedicalCondition
{
	Normal = 1,
	WithCondition = 2,
	Disabled = 3
}

public enum StudentType
{
	Day = 1,
	Boarding = 2,
}

public enum ClubAffiliation
{
	JetsClub = 1,
	ChessClub = 2,
	BoysBrigade = 3,
	RedCross = 4,
	LiteraryAndDebating = 5,
}