using System.Threading.Tasks;

using TheProjector.Domain.ResponseCodes;
using TheProjector.Repository;

namespace TheProjector.Services
{
	public class AssignmentService : IAssignmentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public AssignmentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ResponseBase> AssignPersonToProject(AssignmentRequest request)
		{
			var responseBase = new ResponseBase();

			try
			{
				await _unitOfWork.ProjectAssignmentRepository.Add(new Domain.Entities.ProjectAssignment
				{
					PersonId = request.PersonId,
					ProjectId = request.ProjectId
				});

				await _unitOfWork.CompleteAsync();

				responseBase.ResponseCode = ResponseCodes.TP1003_01;
			}
			catch
			{
				responseBase.ResponseCode = ResponseCodes.TP1003_02;
			}

			return responseBase;
		}

		public async Task<ResponseBase> UnassignPersonToProject(AssignmentRequest request)
		{
			var responseBase = new ResponseBase();

			try
			{
				await _unitOfWork.ProjectAssignmentRepository.Remove(new Domain.Entities.ProjectAssignment
				{
					PersonId = request.PersonId,
					ProjectId = request.ProjectId
				});

				await _unitOfWork.CompleteAsync();

				responseBase.ResponseCode = ResponseCodes.TP1004_01;
			}
			catch
			{
				responseBase.ResponseCode = ResponseCodes.TP1004_02;
			}

			return responseBase;
		}
	}
}
