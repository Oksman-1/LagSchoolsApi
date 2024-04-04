using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranferObjects;

public record ClassDto
{
	public int ClassId { get; init; }
	public Classes? ClassDesignation { get; init; }
	public string? ClassName { get; init; }
	public string? HeadClassTeacherName { get; init; }
	public int NumberOfArms { get; init; }
	public double ClassSize { get; init; }
}



