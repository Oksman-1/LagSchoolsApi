using Entities.Models;
using Shared.DataTranferObjects;

namespace Service.Contracts;

public interface IStudentService
{
	Task<IEnumerable<StudentDto>> GetAllStudentsAsync(bool trackChanges);
	Task<IEnumerable<StudentDto>> GetStudentsAsync(int schoolId, int classId, bool trackChanges);
	Task<StudentDto> GetStudentAsync(int schoolId, int classId, int StudentId, bool trackChanges);
	Task<StudentDto> CreateStudentForSchoolAsync(int schoolId, int classId, StudentForCreationDto studentForCreation, bool trackChanges);
	Task DeleteStudentForSchoolAsync(int schoolId, int classId, int studentId, bool trackChanges);
	Task UpdateStudentForschoolAsync(int schoolId, int classId, int studentId, StudentForUpdateDto studentForUpdate, bool schoolTrackChanges, bool classTrackChanges, bool studentTrackChanges);
	Task<(StudentForUpdateDto studentToPatch, Student studentEntity)> GetStudentForPatchAsync(int schoolId, int classId, int studentId, bool schoolTrackChanges, bool classTrackChanges, bool studentTrackChanges);
	Task SaveChangesForPatchAsync(StudentForUpdateDto studentToPatch, Student studentEntity);
}
