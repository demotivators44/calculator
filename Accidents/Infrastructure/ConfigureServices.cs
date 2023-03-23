using Application.Common.Abstract;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			if (configuration.GetValue<bool>("UseInMemoryDatabase"))
			{
				services.AddDbContext<ApplicationDbContext>(options =>
					options.UseInMemoryDatabase("AccidentsDb"));
			}
			else
			{
				services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
						builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
			}

			services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

			services.AddScoped<ApplicationDbContextInitialiser>();

			//services.AddTransient<IWeatherForecastService, WeatherForecastService>();

			services.AddScoped<IRabbitMqService, RabbitMqService>();

			return services;
		}
	}
}