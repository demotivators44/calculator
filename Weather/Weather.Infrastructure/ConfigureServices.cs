using Weather.Application.Common.Interfaces;
using Weather.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Weather.Infrastructure.Persistence.Dapper;
using Weather.Infrastructure.Persistence.Cassandra;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
		{
			if (configuration.GetValue<bool>("UseInMemoryDatabase"))
			{
				services.AddDbContext<ApplicationDbContext>(options =>
					options.UseInMemoryDatabase("WeatherDb"));
			}
			else
			{
				//SqlServer
				services.AddDbContext<ApplicationDbContext>(options =>
					options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
						builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

				//Postgrees
				//1
				//services.AddDbContext<ApplicationDbContext>(options =>
				//	options.UseNpgsql(configuration.GetConnectionString("DefaultPgConnection"),
				//		builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
				//2
				//services.AddDbContext<ApplicationDbContext>(
				//	optionsBuilder => optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultPgConnection"))
				//);


				//Tets Dapper
				services.AddSingleton<DapperContext>();
				services.AddScoped<IDapperRepository, DapperRepository>();

				AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

				//Test cassandra
				services.AddScoped<ICassandraRepository, CassandraRepository>();
			}


			services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

			services.AddScoped<ApplicationDbContextInitialiser>();

			//services.AddTransient<IWeatherForecastService, WeatherForecastService>();

			services.AddHostedService<RabbitMqListener>();
			//services.AddSingleton<RabbitMqListener>();

			return services;
		}
	}
}