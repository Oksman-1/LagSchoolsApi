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

public record StudentForCreationDto : StudentForUpdateDto
{
	[Required(ErrorMessage = "School Area Code is a Required Feild")]
	public string? SchoolAreaCode { get; init; }

	[Required(ErrorMessage = "School Code is a Required Feild")]
	public string? SchoolCode { get; init; }		

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