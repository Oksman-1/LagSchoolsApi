using Contracts;

namespace Repository;

public class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<IClassRepository> _classRepository;
	private readonly Lazy<IStudentRepository> _studentRepository;
	private readonly Lazy<ISchoolRepository> _schoolRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		_classRepository = new Lazy<IClassRepository>(() => new ClassRepository(repositoryContext));
		_studentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
		_schoolRepository = new Lazy<ISchoolRepository>(() => new SchoolRepository(repositoryContext));
	}

	public IClassRepository Class => _classRepository.Value;
	public IStudentRepository Student => _studentRepository.Value;
	public ISchoolRepository School => _schoolRepository.Value;
	public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();

		
	
}