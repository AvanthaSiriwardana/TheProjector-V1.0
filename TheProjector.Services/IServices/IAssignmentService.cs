using System.Threading.Tasks;

namespace TheProjector.Services
{
	public interface IAssignmentService
	{
		Task<ResponseBase> AssignPersonToProject(AssignmentRequest request);

		Task<ResponseBase> UnassignPersonToProject(UnAssignmentRequest request);
	}
}
