using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTranferObjects;
using System.ComponentModel.Design;

namespace Service;

internal sealed class StudentService : IStudentService
{
	private readonly IRepositoryManager _repository;
	private readonly ILoggerManager _logger;
	private readonly IMapper _mapper;
	public StudentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
	{
		_repository = repository;
		_logger = logger;
		_mapper = mapper;
	}

	public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges)
	{
		var students = await _repository.Student.GetAllStudentsAsync(trackChanges);

		var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);

		return studentsDto;

	}

	public async Task<IEnumerable<StudentDto>> GetStudentsAsync(int schoolId, int classId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, trackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var students = await _repository.Student.GetStudentsAsync(schoolId, classId, trackChanges);

		var studentsDto = _mapper.Map<IEnumerable<StudentDto>>(students);

		return studentsDto;
	}

	public async Task<StudentDto> GetStudentAsync(int schoolId, int classId, int studentId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, trackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var student = await _repository.Student.GetStudentAsync(schoolId, classId, studentId, trackChanges);

		var studentDto = _mapper.Map<StudentDto>(student);

		return studentDto;

	}

	public async Task<StudentDto> CreateStudentForSchoolAsync(int schoolId, int classId, StudentForCreationDto studentForCreation, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, trackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var student = _mapper.Map<Student>(studentForCreation);

		_repository.Student.CreateStudentForSchool(schoolId,classId,student);

		await _repository.SaveAsync();

		var studentDto = _mapper.Map<StudentDto>(student);

		return studentDto;
	}

	public async Task DeleteStudentForSchoolAsync(int schoolId, int classId, int studentId, bool trackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, trackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, trackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var studentForSchool = await _repository.Student.GetStudentAsync(schoolId, classId, studentId, trackChanges);
				
		if (studentForSchool is null)
			throw new StudentNotFoundException(studentId);

		_repository.Student.DeleteStudent(studentForSchool);

		await _repository.SaveAsync();

	}

	public async Task UpdateStudentForschoolAsync(int schoolId, int classId, int studentId, StudentForUpdateDto studentForUpdate, bool schoolTrackChanges, bool classTrackChanges, bool studentTrackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, schoolTrackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, classTrackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var student = await _repository.Student.GetStudentAsync(schoolId, classId, studentId, studentTrackChanges);

		if (student is null)
			throw new StudentNotFoundException(studentId);

		_mapper.Map(studentForUpdate, student);

		await _repository.SaveAsync();
	}

	public async Task<(StudentForUpdateDto studentToPatch, Student studentEntity)> GetStudentForPatchAsync(int schoolId, int classId, int studentId, bool schoolTrackChanges, bool classTrackChanges, bool studentTrackChanges)
	{
		var school = await _repository.School.GetSchoolAsync(schoolId, schoolTrackChanges);

		if (school == null)
			throw new SchoolNotFoundException(schoolId);

		var Class = await _repository.Class.GetClassAsync(schoolId, classId, classTrackChanges);

		if (Class == null)
			throw new ClassNotFoundException(schoolId, classId);

		var student = await _repository.Student.GetStudentAsync(schoolId, classId, studentId, studentTrackChanges);

		if (student is null)
			throw new StudentNotFoundException(studentId);

		var studentToPatch = _mapper.Map<StudentForUpdateDto>(student);

		return (studentToPatch, student);
	}

	public async Task SaveChangesForPatchAsync(StudentForUpdateDto studentToPatch, Student studentEntity)
	{
		_mapper.Map(studentToPatch, studentEntity);

		await _repository.SaveAsync();
	}
}
