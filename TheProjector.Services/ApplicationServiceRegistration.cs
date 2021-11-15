
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheProjector.Repository;

namespace TheProjector.Services
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			// Registering all the services
			services.AddScoped<IPersonService, PersonService>();
			services.AddScoped<IProjectService, ProjectService>();
			services.AddScoped<IAssignmentService, AssignmentService>();

			// Here I register both Service & Repository, because I did not follow the repository patter for the login service
			services.AddScoped<ISignInRepository, SignInRepository>();
			services.AddScoped<ISIgnInService, SignInService>();

			// This will register all the repository interfaces and no need to register individual repositories.
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
