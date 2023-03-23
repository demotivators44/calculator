using Application.Services.Abstract;
using Infrastructure.Services;
using Infrastructure.Services.Abstract;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddInfrastructureServices(this IServiceCollection services/*, IConfiguration configuration*/)
		{
			services.AddTransient<IDateDangerousCalculatorService, DateDangerousCalculatorService>();
			services.AddTransient<IAccidentService, AccidentService>();
			services.AddTransient<IWeatherService, WeatherService>();
			//Add http client services at ConfigureServices(IServiceCollection services)
			services.AddHttpClient();

			return services;
		}
	}
}