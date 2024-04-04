using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class StudentNotFoundException : NotFoundException
{
	public StudentNotFoundException(int StudentId) : base($"Student with Student id: {StudentId} doesn't exist in the database.")
	{
	}
}