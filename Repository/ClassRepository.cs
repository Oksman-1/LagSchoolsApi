using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Repository;

public class ClassRepository : RepositoryBase<Class>, IClassRepository
{
	public ClassRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{

	}

	public async Task<IEnumerable<Class>> GetClassesAsync(int schoolId, bool trackChanges) => await FindByCondition(s => s.SchoolId == schoolId, trackChanges)
		.OrderBy(s => s.ClassId)
		.ToListAsync();

	public async Task<Class> GetClassAsync(int schoolId, int classId, bool trackChanges) => await FindByCondition(s => s.SchoolId == schoolId && s.ClassId == classId, trackChanges)
		.SingleOrDefaultAsync();

	public void CreateClassForSchool(int schoolId, Class Class)
	{
		Class.SchoolId = schoolId;
		Create(Class);
	}

	public void DeleteClass(Class Class) => Delete(Class);

}
