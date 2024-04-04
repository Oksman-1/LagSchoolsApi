using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTranferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LagSchoolsApi.Presentation.Controllers;

[Route("api/schools/{schoolId}/classes")]
[ApiController]
public class ClassesController : ControllerBase
{
		
	private readonly IServiceManager _service;
	public ClassesController(IServiceManager service) => _service = service;

	[HttpGet]
	public async Task<IActionResult> GetClassesForSchool(int schoolId)
	{
		var classes = await _service.ClassService.GetClassesForSchoolAsync(schoolId, trackChanges: false);

		return Ok(classes);
	}

	[HttpGet("{classId:int}", Name = "GetClassForSchool")]
	public async Task<IActionResult> GetClassForSchool(int schoolId, int classId)
	{
		var classToReturn = await _service.ClassService.GetClassForSchoolAsync(schoolId, classId, trackChanges: false);

		return Ok(classToReturn);
	}

	[HttpPost]
	public async Task<IActionResult> CreateClassForSchool(int schoolId, [FromBody] ClassForCreationDto classDto)
	{
		if (classDto is null)
			return BadRequest("ClassForCreationDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		var classToReturn = await _service.ClassService.CreateClassForSchoolAsync(schoolId, classDto, trackChanges: false);

		return CreatedAtRoute("GetClassForSchool", new { schoolId, classToReturn.ClassId }, classToReturn);

	}

	[HttpDelete("{classId:int}")]
	public async Task<IActionResult> DeleteClassForSchool(int schoolId, int classId)
	{
		await _service.ClassService.DeleteClassForSchoolAsync(schoolId, classId, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{classId:int}")]
	public async Task<IActionResult> UpdateClassForSchool(int schoolId, int classId, [FromBody] ClassForUpdateDto classForUpdate)
	{
		if (classForUpdate is null)
			return BadRequest("ClassForUpdateDto object is null");

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.ClassService.UpdateClassForschoolAsync(schoolId, classId, classForUpdate, schoolTrackChanges: false, classTrackChanges: true);

		return NoContent();
	}

	[HttpPatch("{classId:int}")]
	public async Task<IActionResult> PartiallyUpdateClassForSchool(int schoolId, int classId, [FromBody] JsonPatchDocument<ClassForUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc Object sent from Client is null");

		var result = await _service.ClassService.GetClassForPatchAsync(schoolId, classId, schoolTrackChanges: false, classTrackChanges: true);

		patchDoc.ApplyTo(result.classToPatch, ModelState);
		TryValidateModel(result.classToPatch);

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.ClassService.SaveChangesForPatchAsync(result.classToPatch, result.classEntity);

		return NoContent();
	}
}
