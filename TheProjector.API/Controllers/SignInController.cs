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
	[Route("projector/[controller]")]
	public class SignInController : ControllerBase
	{
		private readonly ISIgnInService signInService;

		public SignInController(ISIgnInService signInService)
		{
			this.signInService = signInService;
		}

		[HttpPost]
		public IActionResult Post([FromBody] SignInModel request)
		{

			var response = signInService.GetUser(new PersonRequest
			{
				UserName = request.UserName,
				Password = request.Password
			});

			if (response.ResponseCode == ResponseCodes.TP1005_01)
			{
				return Ok(response);
			}

			return BadRequest();
		}
	}
}
