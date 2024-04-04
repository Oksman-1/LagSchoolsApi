using Entities.Models;
using Shared.DataTranferObjects;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ISchoolService
{
	Task<IEnumerable<SchoolDto>> GetAllSchoolsAsync(bool trackChanges);
	Task<SchoolDto> GetSchoolAsync(int schoolId, bool trackChanges);
	Task<SchoolDto> CreateSchoolAsync(SchoolForCreationDto school);
	Task<IEnumerable<SchoolDto>> GetSchoolByIdsAsync(IEnumerable<int> schoolIds, bool trackChanges);
	Task<IEnumerable<SchoolDto>> CreateschoolCollectionAsync(IEnumerable<SchoolForCreationDto> schoolCollection);
	Task DeleteSchoolAsync(int schoolId, bool trackChanges);
	Task UpdateSchoolAsync(int schoolId, SchoolForUpdateDto schoolForUpdate, bool schoolTrackChanges);
	Task<(SchoolForUpdateDto schoolToPatch, School schoolEntity)> GetSchoolForPatchAsync(int schoolId, bool schoolTrackChanges);
	Task SaveChangesForPatchAsync(SchoolForUpdateDto schoolToPatch, School schoolEntity);

}
