using Entities.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Contracts;

public interface ISchoolRepository
{
	Task<IEnumerable<School>> GetAllSchoolsAsync(bool trackChanges);
	Task<School> GetSchoolAsync(int schoolId, bool trackChanges);
	void CreateSchool(School school);
	Task<IEnumerable<School>> GetByIdsAsync(IEnumerable<int> schoolIds, bool trackChanges);
	void DeleteSchool(School school);
}
