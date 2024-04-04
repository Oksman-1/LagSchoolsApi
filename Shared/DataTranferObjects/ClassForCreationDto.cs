using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record ClassForCreationDto : ClassForUpdateDto
{
	
	[Required(ErrorMessage = "SchoolId is a required field.")]
	[ForeignKey(nameof(SchoolId))]
	public int SchoolId { get; init; }
	public IEnumerable<StudentForCreationDto>? students { get; init; }	

}

public enum Classes
{
	JSS1 = 1,
	JSS2 = 2,
	JSS3 = 3,
	SS1 = 4,
	SS2 = 5,
	SS3 = 6,
}