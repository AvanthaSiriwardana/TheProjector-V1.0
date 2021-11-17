using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheProjector.Services
{
	public interface IPersonService
	{
		Task<ResponseBase> Add(PersonRequest request);

		Task <Response<IEnumerable<Person>>> GetPersonsInTheSelectedProject(int projectId);

		Task<Response<IEnumerable<Person>>> GetPersonsNotInTheSelectedProject(int projectId);
	}
}
