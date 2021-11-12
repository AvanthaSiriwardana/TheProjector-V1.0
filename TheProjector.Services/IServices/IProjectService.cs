using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheProjector.Services
{
	public interface IProjectService
	{
		Task<ResponseBase> Add(ProjectRequest request);

		Task<Response<IEnumerable<Project>>> GetAll();
	}
} 
