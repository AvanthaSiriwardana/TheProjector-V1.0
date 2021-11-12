using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using TheProjector.Domain.ResponseCodes;
using TheProjector.Repository;

namespace TheProjector.Services
{
	public class ProjectService : IProjectService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProjectService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ResponseBase> Add(ProjectRequest request)
		{
			var responseBase = new ResponseBase();

			try
			{
				await _unitOfWork.Project.Add(new Domain.Entities.Project
				{
					Id = 0,
					Code = request.Code,
					Name = request.Name,
					Remarks = request.Remarks,
					Budget = request.Budget,
					ProjectAssignments = null
				});

				await _unitOfWork.CompleteAsync();

				responseBase.ResponseCode = ResponseCodes.TP1001_01;
			}
			catch
			{
				responseBase.ResponseCode = ResponseCodes.TP1001_02;
			}

			return responseBase;
		}

		public async Task<Response<IEnumerable<Project>>> GetAll()
		{
			var response = new Response<IEnumerable<Project>>();

			try
			{
				var projects = await _unitOfWork.Project.GetAll();

				response.ResponseCode = ResponseCodes.TP1000_01;

				var productList = new List<Project>();
				foreach (var project in projects)
				{
					productList.Add(new Project
					{
						Id = project.Id,
						Name = project.Name,
						Budget = decimal.Round(project.Budget, 2)
					});
				}

				response.Result = productList;
			}
			catch
			{
				response.ResponseCode = ResponseCodes.TP1000_02;
			}

			return response;
		}
	}
}
