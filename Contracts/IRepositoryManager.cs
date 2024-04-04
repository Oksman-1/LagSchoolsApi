namespace Contracts;

public interface IRepositoryManager
{
	IClassRepository Class { get; }
	IStudentRepository Student { get; }
	ISchoolRepository School { get; }
	Task SaveAsync();
}
