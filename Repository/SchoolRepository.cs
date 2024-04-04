using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repository;

public class SchoolRepository : RepositoryBase<School>, ISchoolRepository
{
	public SchoolRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{

	}

	public async Task<IEnumerable<School>> GetAllSchoolsAsync(bool trackChanges) =>
			await FindAll(trackChanges)
			.OrderBy(c => c.SchoolId)
			.ToListAsync();

	public async Task<School> GetSchoolAsync(int schoolId, bool trackChanges) => await FindByCondition(s => s.SchoolId == schoolId, trackChanges).FirstOrDefaultAsync();	
	

	public void CreateSchool(School school)
	{
		Create(school);
	}

	public async Task<IEnumerable<School>> GetByIdsAsync(IEnumerable<int> schoolIds, bool trackChanges) => await FindByCondition(x => schoolIds.Contains(x.SchoolId), trackChanges)
			.ToListAsync();

	public void DeleteSchool(School school) => Delete(school);
	
}
