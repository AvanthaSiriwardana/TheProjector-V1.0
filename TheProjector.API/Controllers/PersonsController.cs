using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TheProjector.API.Models;
using TheProjector.Domain.ResponseCodes;
using TheProjector.Services;

namespace TheProjector.API.Controllers
{
	[ApiController]
	[Route("projector/[controller]")]
	public class PersonsController : ControllerBase
	{
		private readonly IPersonService personService;

		public PersonsController(IPersonService personService)
		{
			this.personService = personService;
		}

		[HttpPost]
		[Route("create")]
		public async Task<IActionResult> CreatePersonAsync([FromBody] PersonModel request)
		{
			var response = await personService.Add(new PersonRequest
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				UserName = request.UserName,
				Password = request.Password
			});

			if (response.ResponseCode == ResponseCodes.TP1002_01)
			{
				return Ok(response);
			}

			return BadRequest(response);
		}
	}
}
