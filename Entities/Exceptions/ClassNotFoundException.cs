using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions;

public sealed class ClassNotFoundException : NotFoundException
{
	public ClassNotFoundException(int SchoolId,int ClassId) : base($"Class with School id: {SchoolId} and Class id: {ClassId} doesn't exist in the database.")
	{
	}
}
