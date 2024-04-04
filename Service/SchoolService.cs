using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTranferObjects;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Service;

internal sealed class SchoolService : ISchoolService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;
	public SchoolService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync(bool trackChanges)
	{
		
			var schools = await _repository.School.GetAllSchoolsAsync(trackChanges);

			var schoolsDto = _mapper.Map<IEnumerable<SchoolDto>>(schools);

			return schoolsDto;
		
	}

	public async Task<SchoolDto> GetSchoolAsync(int schoolId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var schoolDto = _mapper.Map<SchoolDto>(school);	

		return schoolDto;	
	}

	public async Task<SchoolDto> CreateSchoolAsync(SchoolForCreationDto school)
	{
		var schoolEntity = _mapper.Map<School>(school);
		
		_repository.School.CreateSchool(schoolEntity);

		await _repository.SaveAsync();

		var schoolToReturn = _mapper.Map<SchoolDto>(schoolEntity);

		return schoolToReturn;
	}

	public async Task<IEnumerable<SchoolDto>> GetSchoolByIdsAsync(IEnumerable<int> schoolIds, bool trackChanges)
	{
		if (schoolIds is null)
			throw new IdParametersBadRequestException();

		var schoolEntities = await _repository.School.GetByIdsAsync(schoolIds, trackChanges);	

		if (schoolIds.Count() != schoolEntities.Count())
			throw new CollectionByIdsBadRequestException();

		var schoolsToReturn = _mapper.Map<IEnumerable<SchoolDto>>(schoolEntities);

		return schoolsToReturn;
	}

	public async Task<IEnumerable<SchoolDto>> CreateschoolCollectionAsync(IEnumerable<SchoolForCreationDto> schoolCollection)
	{
		if (schoolCollection is null)
			throw new SchoolCollectionBadRequest();

		var schoolEntities = _mapper.Map<IEnumerable<School>>(schoolCollection);
		foreach (var school in schoolEntities)
		{
			_repository.School.CreateSchool(school);
		}

		await _repository.SaveAsync();

		var schoolCollectionToReturn = _mapper.Map<IEnumerable<SchoolDto>>(schoolEntities);

		//var ids = string.Join(",", schoolCollectionToReturn.Select(c => c.SchoolId));

		return schoolCollectionToReturn;
	}

	public async Task DeleteSchoolAsync(int schoolId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		_repository.School.DeleteSchool(school);

		await _repository.SaveAsync();
	}

	public async Task UpdateSchoolAsync(int schoolId, SchoolForUpdateDto schoolForUpdate, bool schoolTrackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, schoolTrackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);		

		_mapper.Map(schoolForUpdate, school);

		await _repository.SaveAsync();
	}

	public async Task<(SchoolForUpdateDto schoolToPatch, School schoolEntity)> GetSchoolForPatchAsync(int schoolId, bool schoolTrackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, schoolTrackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);	
		
		var schoolToPatch = _mapper.Map<SchoolForUpdateDto>(school);

		return (schoolToPatch, school);
	}

	public async Task SaveChangesForPatchAsync(SchoolForUpdateDto schoolToPatch, School schoolEntity)
	{
		_mapper.Map(schoolToPatch, schoolEntity);

		await _repository.SaveAsync();
	}
}
