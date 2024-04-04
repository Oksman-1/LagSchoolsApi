using AutoMapper;
using Entities.Models;
using Shared.DataTranferObjects;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace TESTing;

public class MappingProfile : Profile
{

	public MappingProfile()
	{
		CreateMap<School, SchoolDto>();

		CreateMap<SchoolForCreationDto, School>();		

		CreateMap<Class, ClassDto>();

		CreateMap<ClassForCreationDto, Class>();

		CreateMap<Student, StudentDto>();

		Random rand = new Random();
		string RegNum;

		RegNum = Convert.ToString((long)Math.Floor(rand.NextDouble() * 19_000_000L + 10_000_000L));

		CreateMap<StudentForCreationDto, Student>()
			.ForMember(c => c.StudentRegistrationNumber,
				opt => opt.MapFrom(x => string.Join('/', x.SchoolAreaCode, x.SchoolCode, RegNum,"LG")));

		CreateMap<ClassForUpdateDto, Class>().ReverseMap();

		CreateMap<StudentForUpdateDto, Student>().ReverseMap(); 

		CreateMap<SchoolForUpdateDto, School>().ReverseMap();

	}
}
