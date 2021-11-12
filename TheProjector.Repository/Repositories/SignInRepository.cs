using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheProjector.Domain.Entities;

namespace TheProjector.Repository
{
	public class SignInRepository : ISignInRepository
	{
		private readonly TheProjectorContext theProjectorContext;

		public SignInRepository(TheProjectorContext context)
		{
			this.theProjectorContext = context;
		}

		public Person GetUser(string email, string password)
		{
			return  theProjectorContext.Persons.FirstOrDefault(x => x.UserName == email && x.Password == password);
		}
	}
}
