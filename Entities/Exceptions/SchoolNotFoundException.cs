using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class SchoolNotFoundException : NotFoundException
{
	public SchoolNotFoundException(int SchoolId) : base($"The school with id: {SchoolId} doesn't exist in the database.")
	{
	}
}
