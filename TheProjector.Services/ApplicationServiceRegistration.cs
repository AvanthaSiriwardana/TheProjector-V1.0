
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TheProjector.Repository;

namespace TheProjector.Services
{
	public static class ApplicationServiceRegistration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddScoped<IPersonService, PersonService>();
			services.AddScoped<IProjectService, ProjectService>();

			services.AddScoped<ISignInRepository, SignInRepository>();
			services.AddScoped<ISIgnInService, SignInService>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}
