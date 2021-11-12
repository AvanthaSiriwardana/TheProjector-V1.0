using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.ResponseCodes;
using TheProjector.Repository;

namespace TheProjector.Services
{
	public class SignInService : ISIgnInService
	{
		private readonly ISignInRepository signInRepository;

		public SignInService(ISignInRepository signInRepository)
		{
			this.signInRepository = signInRepository;
		}

		public Response<Person> GetUser(PersonRequest request)
		{
			var response = new Response<Person>();

			try
			{
				var person = signInRepository.GetUser(request.UserName, request.Password);

				if (person != null)
				{
					response.ResponseCode = ResponseCodes.TP1005_01;

					response.Result = new Person { FirstName = person.FirstName, LastName = person.LastName, UserName = person.UserName };

					return response;
				}

				response.ResponseCode = ResponseCodes.TP1005_02;
				response.Result = null;
			}
			catch
			{
				response.ResponseCode = ResponseCodes.TP1005_02;
				response.Result = null;
			}

			return response;
		}
	}
}
