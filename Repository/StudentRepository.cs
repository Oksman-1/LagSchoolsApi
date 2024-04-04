using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class StudentRepository : RepositoryBase<Student>, IStudentRepository
{
	public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
	{
	}

	public async Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges) => await FindAll(trackChanges)
		                                                             .OrderBy(c => c.StudentId)
			                                                         .ToListAsync();
	

	public async Task<IEnumerable<Student>> GetStudentsAsync(int schoolId, int classId, bool trackChanges) => await FindByCondition(s => s.SchoolId == schoolId && s.ClassId == classId, trackChanges)
		.OrderBy(s => s.StudentId)
		.ToListAsync();
	

	public void CreateStudentForSchool(int schoolId, int classId, Student student)
	{
		student.SchoolId = schoolId;
		student.ClassId = classId;
		Create(student);
	}

	public async Task<Student> GetStudentAsync(int schoolId, int classId, int studentId, bool trackChanges) => await FindByCondition(s => s.SchoolId == schoolId && s.ClassId == classId && s.StudentId == studentId, trackChanges)
		.SingleOrDefaultAsync();

	public void DeleteStudent(Student student) => Delete(student);

}
