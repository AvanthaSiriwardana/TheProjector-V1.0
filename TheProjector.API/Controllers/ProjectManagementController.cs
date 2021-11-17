using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheProjector.API.Models;
using TheProjector.Domain.ResponseCodes;
using TheProjector.Services;

namespace TheProjector.API.Controllers
{
	[ApiController]
	[Route("projector/projects")]
	public class ProjectManagementController : ControllerBase
	{
		private readonly IAssignmentService assignmentService;

		public ProjectManagementController(IAssignmentService assignmentService)
		{
			this.assignmentService = assignmentService;
		}

		[HttpPost]
		[Route("assign")]
		public async Task<IActionResult> AssignPersonToProjectAsync([FromBody] AssignProjectModel request)
		{
			var response = await assignmentService.AssignPersonToProject(new AssignmentRequest
			{
				PersonId = request.PersonId,
				ProjectId = request.ProjectId
			});

			if (response.ResponseCode == ResponseCodes.TP1003_01)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}

		[HttpDelete]
		[Route("unassign")]
		public async Task<IActionResult> UnAssignPersonToProjectAsync([FromBody] UnAssignProjectModel request)
		{
			var response = await assignmentService.UnassignPersonToProject(new UnAssignmentRequest
			{
				PersonId = request.PersonId,
				ProjectId = request.ProjectId
			});

			if (response.ResponseCode == ResponseCodes.TP1003_01)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}
	}
}
