using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shared.DataTranferObjects;

public record StudentDto
{
	public int StudentId { get; init; }
	public string? FirstName { get; init; }
	public string? LastName { get; init; }
	public string? ClassName { get; init; }
	public Sex? Sex { get; init; }
	public DateTime? DateOfBirth { get; init; }
	public int Age { get; init; }
	public double? Weight { get; init; }	
	public double? Height { get; init; }
	public string? Address { get; init; }	
	public string? ParentsPhoneNumber { get; init; }	
	public string? Email { get; init; }
	public string? StateOfOrigin { get; init; }
	public string? LGA { get; init; }
	public string? Nationality { get; init; }
	public DateTime? DateOfAdmission { get; init; }
	public DateTime? ExpectedDateOfGraduation { get; init; }	
	public string? StudentRegistrationNumber { get; init; }	
	public string? NationalIdentityNumber { get; init; }	
	public string? VirtualNationalIdentityNumber { get; init; }	
	public StudentType? StudentType { get; init; }
	public MedicalCondition? MedicalCondition { get; init; }
	public ClubAffiliation? ClubAffiliation { get; init; }
	
}
