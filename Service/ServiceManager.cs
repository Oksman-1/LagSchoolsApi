using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
	private readonly Lazy<IClassService> _classService;
	private readonly Lazy<IStudentService> _studentService;
	private readonly Lazy<ISchoolService> _schoolService;

	public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
	{
		_classService = new Lazy<IClassService>(() => new ClassService(repositoryManager, logger, mapper));
		_studentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager, logger, mapper));
		_schoolService = new Lazy<ISchoolService>(() => new SchoolService(repositoryManager, logger, mapper));
	}

	public IClassService ClassService => _classService.Value;

	public IStudentService StudentService => _studentService.Value;

	public ISchoolService SchoolService => _schoolService.Value;
}
