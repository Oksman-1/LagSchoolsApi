using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Entities.Models;

public class School
{
	[Key]
	public int SchoolId { get; set; }
	public string? SchoolName { get; set; }
	public string? SchoolAddress { get; set; }
	public string? PhoneNumber { get; set; }

	[EmailAddress(ErrorMessage = "Email address is not valid")]
	public string? Email { get; set; }

	[Url(ErrorMessage = "URL is not valid")]
	public string? Website { get; set; }
	public string? SchoolLocation { get; set; }
	public string? SchoolAreaCode { get; set; }
	public DateTime? DateOpened { get; set; }

	[EnumDataType(typeof(SchoolType), ErrorMessage = "Please enter a valid School Type")]
	public SchoolType? SchoolType { get; set; }

	[Column("LandArea(Sq.km)")]
	public double LandArea { get; set; }

	[EnumDataType(typeof(SecurityLevel))]
	public SecurityLevel? SecurityLevel { get; set; }	
	public bool WAECApproved { get; set; }
	public DateTime? DateWAECApproved { get; set; }
	public bool SchoolBus { get; set; }
	public int NumberSchoolBus { get; set; }
	public string? SchoolDescription { get; set; }
	public string? SummarySchoolFacilities { get; set; }	
	public IList<Student>? Students { get; set; }
	public IList<Class>? Classes { get; set; }

}


public enum SchoolType
{
	Day = 1,
	Boarding = 2,
	Mixed = 3,
}

public enum SecurityLevel
{
	Excellent = 1,
	Good = 2,
	Average = 3,
	Fair = 4
}