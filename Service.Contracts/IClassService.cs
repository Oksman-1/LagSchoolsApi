using Entities.Models;
using Shared.DataTranferObjects;

namespace Service.Contracts;

public interface IClassService
{
	Task<IEnumerable<ClassDto>> GetClassesForSchoolAsync(int schoolId, bool trackChanges);
	Task<ClassDto> GetClassForSchoolAsync(int schoolId, int classId, bool trackChanges);
	Task<ClassDto> CreateClassForSchoolAsync(int schoolId, ClassForCreationDto classForCreation, bool trackChanges);
	Task DeleteClassForSchoolAsync(int schoolId, int classId, bool trackChanges);
	Task UpdateClassForschoolAsync(int schoolId, int classId, ClassForUpdateDto classForUpdate, bool schoolTrackChanges, bool classTrackChanges);
	Task<(ClassForUpdateDto classToPatch, Class classEntity)> GetClassForPatchAsync(int schoolId, int classId, bool schoolTrackChanges, bool classTrackChanges);
	Task SaveChangesForPatchAsync(ClassForUpdateDto classToPatch, Class classEntity);

}
