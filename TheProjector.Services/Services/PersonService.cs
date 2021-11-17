using System.Collections.Generic;
using System.Linq;
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

		public async Task<Response<IEnumerable<Person>>> GetPersonsInTheSelectedProject(int projectI)
		{
			var response = new Response<IEnumerable<Person>>();

			try
			{
				var projectAssignment = await _unitOfWork.ProjectAssignment.Find(x => x.ProjectId == projectI);

				var personList = new List<Person>();
				foreach (var item in projectAssignment)
				{
					var x = item.Person;

					if (x != null)
					{
						personList.Add(new Person
						{
							Id = x.Id,
							FirstName = x.FirstName,
							LastName = x.LastName
						});
					}
				}

				response.ResponseCode = "0";
				response.Result = personList;
			}
			catch
			{
				response.Result = null;
				response.ResponseCode = "-1";
			}

			return response;
		}

		public async Task<Response<IEnumerable<Person>>> GetPersonsNotInTheSelectedProject(int projectId)
		{
			var response = new Response<IEnumerable<Person>>();

			try
			{
				var projectAssignments = await _unitOfWork.ProjectAssignment.Find(x => x.ProjectId == projectId);
				var personsInTheProjectAssignment = projectAssignments.Select(x => x.Person.Id);
				var persons = await _unitOfWork.Person.GetAll();

				var personsNotInTheProjectAssignment = persons.Where(x => !personsInTheProjectAssignment.Contains(x.Id));

				var personsNotInProject = new List<Person>();
				foreach (var item in personsNotInTheProjectAssignment)
				{
					personsNotInProject.Add(new Person
					{
						Id = item.Id,
						FirstName = item.FirstName,
						LastName = item.LastName
					});
				}

				response.ResponseCode = "0";
				response.Result = personsNotInProject;
			}
			catch
			{
				response.Result = null;
				response.ResponseCode = "-1";
			}

			return response;
		}
	}
}
