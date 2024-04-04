using Entities.Models;

namespace Contracts;

public interface IClassRepository
{
	Task<IEnumerable<Class>> GetClassesAsync(int schoolId, bool trackChanges);
	Task<Class> GetClassAsync(int schoolId, int classId, bool trackChanges);
	void CreateClassForSchool(int schoolId, Class Class);
	void DeleteClass(Class Class);
}
