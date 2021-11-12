using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;

using TheProjector.Domain.Entities;
using TheProjector.Services;

namespace TheProjector.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private readonly string _policyName = "CorsPolicy";

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddApplicationServices(Configuration);

			services.AddCors(opt =>
			{
				opt.AddPolicy(name: _policyName, builder =>
				{
					builder.AllowAnyOrigin()
						.AllowAnyHeader()
						.AllowAnyMethod();
				});
			});

			services.AddControllers().AddNewtonsoftJson();

			// Configure Database Connection String
			services.AddDbContext<TheProjectorContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TheProjectorDbConnection")));

			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
			}).AddCookie("Cookies", options =>
			{
				options.Cookie.Name = "Cookie_Name";
				options.Cookie.SameSite = SameSiteMode.None;
				options.Events = new CookieAuthenticationEvents
				{
					OnRedirectToLogin = redirectContext =>
					{
						redirectContext.HttpContext.Response.StatusCode = 401;
						return Task.CompletedTask;
					}
				};
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseCors(_policyName);

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
