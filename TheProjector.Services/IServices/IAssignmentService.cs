using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheProjector.Services
{
	public interface IAssignmentService
	{
		Task<ResponseBase> AssignPersonToProject(AssignmentRequest request);
	}
}
