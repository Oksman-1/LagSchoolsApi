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

[Route("api/schools/{schoolId}/classes/{classId}/students")]
[ApiController]
public class StudentsController : ControllerBase
{
	private readonly IServiceManager _service;
	public StudentsController(IServiceManager service) => _service = service;


	[HttpGet]
	public async Task<IActionResult> GetStudents(int schoolId, int classId)
	{
		var students = await _service.StudentService.GetStudentsAsync(schoolId, classId, trackChanges: false);

		return Ok(students);
	}

	[HttpGet("{studentId:int}", Name = "GetStudentForSchool")]
	public async Task<IActionResult> GetStudentForSchool(int schoolId, int classId, int studentId)
	{
		var studentToReturn = await _service.StudentService.GetStudentAsync(schoolId, classId, studentId, trackChanges: false);

		return Ok(studentToReturn);
	}

	[HttpPost]
	public async Task<IActionResult> CreatestudentForSchool(int schoolId, int classId, [FromBody] StudentForCreationDto studentDto)
	{
		if (studentDto is null)
			return BadRequest("StudentForCreationDto object is null");

		if (!ModelState.IsValid)
			return BadRequest(ModelState);

		var studentToReturn = await _service.StudentService.CreateStudentForSchoolAsync(schoolId, classId, studentDto, trackChanges: false);

		return CreatedAtRoute("GetStudentForSchool", new { schoolId, classId, studentToReturn.StudentId }, studentToReturn);

	}

	[HttpDelete("{studentId:int}")]
	public async Task<IActionResult> DeleteStudentForSchool(int schoolId, int classId, int studentId)
	{
		await _service.StudentService.DeleteStudentForSchoolAsync(schoolId, classId, studentId, trackChanges: false);

		return NoContent();
	}

	[HttpPut("{studentId:int}")]
	public async Task<IActionResult> UpdateStudentForSchool(int schoolId, int classId, int studentId, [FromBody] StudentForUpdateDto studentForUpdate)
	{
		if (studentForUpdate is null)
			return BadRequest("StudentForUpdateDto object is null");

		await _service.StudentService.UpdateStudentForschoolAsync(schoolId, classId, studentId, studentForUpdate, schoolTrackChanges: false, classTrackChanges: false, studentTrackChanges: true);

		return NoContent();
	}

	[HttpPatch("{studentId:int}")]
	public async Task<IActionResult> PartiallyUpdateClassForSchool(int schoolId, int classId, int studentId, [FromBody] JsonPatchDocument<StudentForUpdateDto> patchDoc)
	{
		if (patchDoc is null)
			return BadRequest("patchDoc Object sent from Client is null");

		var result = await _service.StudentService.GetStudentForPatchAsync(schoolId, classId, studentId, schoolTrackChanges: false, classTrackChanges: false, studentTrackChanges: true);

		patchDoc.ApplyTo(result.studentToPatch, ModelState);
		TryValidateModel(result.studentToPatch);

		if (!ModelState.IsValid)
			return UnprocessableEntity(ModelState);

		await _service.StudentService.SaveChangesForPatchAsync(result.studentToPatch, result.studentEntity);

		return NoContent();
	}


}
