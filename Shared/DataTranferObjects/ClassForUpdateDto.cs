using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record ClassForUpdateDto
{
	[Required(ErrorMessage = "ClassDesignation is a required field.")]
	public Classes? ClassDesignation { get; init; }

	[Required(ErrorMessage = "ClassName is a required field.")]
	public string? ClassName { get; init; }

	[Required(ErrorMessage = "HeadClassTeacherName is a required field.")]
	public string? HeadClassTeacherName { get; init; }

	[Required(ErrorMessage = "NumberOfArms is a required field.")]
	public int NumberOfArms { get; init; }
	public double ClassSize { get; init; }	
}
