using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using TheProjector.API.Models;
using TheProjector.Domain.ResponseCodes;
using TheProjector.Services;

namespace TheProjector.API.Controllers
{

	[ApiController]
	[Route("projector/[controller]")]
	public class ProjectsController : ControllerBase
	{
		private readonly IProjectService projectService;

		public ProjectsController(IProjectService personService)
		{
			this.projectService = personService;
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectModel request)
		{

			var response = await projectService.Add(new ProjectRequest
			{
				Code = request.Code,
				Name = request.Name,
				Remarks = request.Remarks,
				Budget = request.Budget
			});

			if (response.ResponseCode == ResponseCodes.TP1001_01)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var response = await projectService.GetAll();

			if (response.ResponseCode == ResponseCodes.TP1000_01)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}
	}
}
