namespace Service.Contracts;

public interface IServiceManager
{
	IClassService ClassService { get; }
	IStudentService StudentService { get; }
	ISchoolService SchoolService { get; }

}
