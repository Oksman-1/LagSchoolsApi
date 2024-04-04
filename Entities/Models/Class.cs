using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Class
{
	[Key]
	public int ClassId { get; set; }

	[EnumDataType(typeof(Classes))]
	public Classes? ClassDesignation { get; set; }	
	public string? ClassName { get; set; }
	public string? HeadClassTeacherName { get; set; }
	public int NumberOfArms { get; set; }

	[Column("ClassSize(Sq.m)")]
	public double ClassSize { get; set; }

	[ForeignKey(nameof(School))]
	public int SchoolId { get; set; }
	public School? School { get; set; }
	public IList<Student>? Students { get; set; }

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
