using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Shared.DataTranferObjects;

namespace Shared.DataTransferObjects;

public record SchoolDto
{
	public int SchoolId { get; init; }
	public string? SchoolName { get; init; }
	public string? SchoolAddress { get; init; }
	public string? PhoneNumber { get; init; }	
	public string? Email { get; init; }
	public string? Website { get; init; }	
	public string? SchoolLocation { get; init; }
	public string? SchoolAreaCode { get; init; }
	public DateTime? DateOpened { get; init; }	
	public SchoolType? SchoolType { get; init; }	
	public double LandArea { get; init; }
	public SecurityLevel? SecurityLevel { get; init; }
	public bool WAECApproved { get; init; }
	public DateTime? DateWAECApproved { get; init; }
	public bool SchoolBus { get; init; }
	public int NumberSchoolBus { get; init; }
	public string? SchoolDescription { get; init; }
	public string? SummarySchoolFacilities { get; init; }

}


