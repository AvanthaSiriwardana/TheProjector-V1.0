using System.Threading.Tasks;
using TheProjector.Domain.ResponseCodes;
using TheProjector.Repository;

namespace TheProjector.Services
{
	public class PersonService : IPersonService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PersonService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ResponseBase> Add(PersonRequest request)
		{
			var responseBase = new ResponseBase();

			try
			{
				await _unitOfWork.Person.Add(new Domain.Entities.Person
				{
					FirstName = request.FirstName,
					LastName = request.LastName,
					UserName = request.UserName,
					Password = request.Password,
					ProjectAssignments = null,
					Id = 0
				});

				await _unitOfWork.CompleteAsync();
				responseBase.ResponseCode = ResponseCodes.TP1002_01;
			}
			catch
			{
				responseBase.ResponseCode = ResponseCodes.TP1002_02;
			}
			return responseBase;
		}
	}
}
