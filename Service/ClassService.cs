using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTranferObjects;
using System.ComponentModel.Design;

namespace Service;

internal sealed class ClassService : IClassService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;
	public ClassService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;		
		_mapper = mapper;
	}

	public async Task<IEnumerable<ClassDto>> GetClassesForSchoolAsync(int schoolId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var classes = await _repository.Class.GetClassesAsync(schoolId, trackChanges);

		var classesDto = _mapper.Map<IEnumerable<ClassDto>>(classes);

		return classesDto;

	}

	public async Task<ClassDto> GetClassForSchoolAsync(int schoolId, int classId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);		

		var classToReturn = await _repository.Class.GetClassAsync(schoolId, classId, trackChanges);

		if(classToReturn == null)	
			throw new ClassNotFoundException(schoolId, classId);

		var classDto = _mapper.Map<ClassDto>(classToReturn);

		return classDto;	

	}

	public async Task<ClassDto> CreateClassForSchoolAsync(int schoolId, ClassForCreationDto classForCreation, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = _mapper.Map<Class>(classForCreation);

		 _repository.Class.CreateClassForSchool(schoolId,Class);

		await _repository.SaveAsync();

		var classDto = _mapper.Map<ClassDto>(Class);

		return classDto;
	}

	public async Task DeleteClassForSchoolAsync(int schoolId, int classId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, trackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);
		try
		{
			_repository.Class.DeleteClass(Class);

			await _repository.SaveAsync();
		}
		catch (Exception ex)
		{

			throw new Exception($"Student(s) with SchoolId: {schoolId} still exists in the Database, Delete first before trying again", ex);
		}
		
	}

	public async Task UpdateClassForschoolAsync(int schoolId, int classId, ClassForUpdateDto classForUpdate, bool schoolTrackChanges, bool classTrackChanges)
	{
		var school = _repository.School.GetSchoolAsync(schoolId, schoolTrackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = _repository.Class.GetClassAsync(schoolId, classId, classTrackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		await _mapper.Map(classForUpdate, Class);

		await _repository.SaveAsync();
	}

	public async Task<(ClassForUpdateDto classToPatch, Class classEntity)> GetClassForPatchAsync(int schoolId, int classId, bool schoolTrackChanges, bool classTrackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, schoolTrackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, classTrackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var classToPatch = _mapper.Map<ClassForUpdateDto>(Class);

		return (classToPatch, Class);
	}

	public async Task SaveChangesForPatchAsync(ClassForUpdateDto classToPatch, Class classEntity)
	{
		 _mapper.Map(classToPatch, classEntity);

		await _repository.SaveAsync();
	}
} 
