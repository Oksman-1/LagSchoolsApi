using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTranferObjects;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagSchoolsApi.Presentation.Controllers;

[Route("api/schools")]
[ApiController]
public class SchoolsController : ControllerBase
{
	private readonly IServiceManager _service;
	public SchoolsController(IServiceManager service) => _service = service;

	[HttpGet]
	public async Task<IActionResult> GetSchools()
	{		
		var schools = await _service.SchoolService.GetAllSchoolsAsync(trackChanges: false);

		return Ok(schools);		
	}

	[HttpGet("{schoolId:int}", Name = "SchoolById")]
	public async Task<IActionResult> GetSchool(int schoolId)
	{
		var school = await _service.SchoolService.GetSchoolAsync(schoolId, trackChanges: false);

		return Ok(school);
	}

	[HttpPost]
	public async Task<IActionResult> CreateSchool([FromBody] SchoolForCreationDto school)
	{
		if (school == null)
			return BadRequest("SchoolForCreationDto object is null");

		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var createdSchool = await _service.SchoolService.CreateSchoolAsync(school);			

		return CreatedAtRoute("SchoolById", new { createdSchool.SchoolId }, createdSchool);
	}

	[HttpPost("collection")]
	public async Task<IActionResult> CreateSchoolCollection([FromBody] IEnumerable<SchoolForCreationDto> schoolCollection)
	{
		var result = await _service.SchoolService.CreateschoolCollectionAsync(schoolCollection);		

		return Ok(result);

	}

	[HttpDelete("{schoolId:int}")]
	public async Task<IActionResult> DeleteSchool(int schoolId)
	{
		await _service.SchoolService.DeleteSchoolAsync(schoolId, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{schoolId:int}")]
	public async Task<IActionResult> UpdateSchool(int schoolId, [FromBody] SchoolForUpdateDto schoolForUpdate)
	{
		if (schoolForUpdate is null)
			return BadRequest("SchoolForUpdateDto object is null");

		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		await _service.SchoolService.UpdateSchoolAsync(schoolId, schoolForUpdate, schoolTrackChanges: true);

		return NoContent();
	}

	[HttpPatch("{schoolId:int}")]
	public async Task<IActionResult> PartiallyUpdateClassForSchool(int schoolId, [FromBody] JsonPatchDocument<SchoolForUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc Object sent from Client is null");

		var result = await _service.SchoolService.GetSchoolForPatchAsync(schoolId, schoolTrackChanges: true);

		patchDoc.ApplyTo(result.schoolToPatch, ModelState);
		TryValidateModel(result.schoolEntity);

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.SchoolService.SaveChangesForPatchAsync(result.schoolToPatch, result.schoolEntity);

		return NoContent();
	}
}
