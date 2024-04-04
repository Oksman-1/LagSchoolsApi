using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared.DataTranferObjects;

namespace Shared.DataTransferObjects;

public record SchoolForCreationDto
{
	[Required(ErrorMessage = "School Name is Required")]
	public string? SchoolName { get; init; }

	[Required(ErrorMessage = "School Address is Required")]
	public string? SchoolAddress { get; init; }

	[Required(ErrorMessage = "School Phone Number is Required")]
	public string? PhoneNumber { get; init; }

	[EmailAddress(ErrorMessage = "Email address is not valid")]
	public string? Email { get; init; }

	[Url(ErrorMessage = "URL is not valid")]
	public string? Website { get; init; }

	[Required(ErrorMessage = "School Location is a Required Field")]
	public string? SchoolLocation { get; init; }

	[Required(ErrorMessage = "School Area Code is a Required Field")]
	public string? SchoolAreaCode { get; init; }
	public DateTime? DateOpened { get; init; }	
	public SchoolType? SchoolType { get; init; }	
	public double LandArea { get; init; }

	[Required(ErrorMessage = "Security Level is a Required Field")]
	public SecurityLevel? SecurityLevel { get; init; }
	public bool WAECApproved { get; init; }
	public DateTime? DateWAECApproved { get; init; }
	public bool SchoolBus { get; init; }
	public int NumberSchoolBus { get; init; }
	public string? SchoolDescription { get; init; }
	public string? SummarySchoolFacilities { get; init; }	

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