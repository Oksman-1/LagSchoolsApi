using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record StudentForUpdateDto 
{
	[Required(ErrorMessage = "First Name is a Required Feild")]
	public string? FirstName { get; init; }

	[Required(ErrorMessage = "Last Name is a Required Feild")]
	public string? LastName { get; init; }
	public string? ClassName { get; init; }
	public Sex? Sex { get; init; }
	public DateTime? DateOfBirth { get; init; }

	[Range(5, int.MaxValue, ErrorMessage = "Age is required and it can't be lower than 5")]
	public int Age { get; init; }
	public double? Weight { get; init; }
	public double? Height { get; init; }
	public string? Address { get; init; }

	[Required(ErrorMessage = "Parent Phone Number is a Required Feild")]
	public string? ParentsPhoneNumber { get; init; }

	[EmailAddress(ErrorMessage = "Email address is not valid")]
	public string? Email { get; init; }

	[Required(ErrorMessage = "State Of Origin is a Required Feild")]
	public string? StateOfOrigin { get; init; }

	[Required(ErrorMessage = "LGA is Required is a Required Feild")]
	public string? LGA { get; init; }
	public string? Nationality { get; init; }

	[Required(ErrorMessage = "Date Of Admission is a Required Feild")]
	public DateTime? DateOfAdmission { get; init; }
	public DateTime? ExpectedDateOfGraduation { get; init; }	
	public StudentType? StudentType { get; init; }

	[Required(ErrorMessage = "Medical Condition is a Required Feild")]
	public MedicalCondition? MedicalCondition { get; init; }
	public ClubAffiliation? ClubAffiliation { get; init; }
}
