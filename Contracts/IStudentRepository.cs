using Entities.Models;

namespace Contracts;

public interface IStudentRepository
{
	Task<IEnumerable<Student>> GetAllStudentsAsync(bool trackChanges);
	Task<IEnumerable<Student>> GetStudentsAsync(int schoolId, int classId, bool trackChanges);
	Task<Student> GetStudentAsync(int schoolId, int classId, int studentId, bool trackChanges);
	void CreateStudentForSchool(int schoolId, int classId, Student student);
	void DeleteStudent(Student student);
}
