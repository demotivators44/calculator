using Weather.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Xml.Linq;
using Weather.Application.WeatherForecasts.Commands.CreateWeatherForecast;
using Azure.Core;
using Weather.Domain.Entities;

namespace Weather.Infrastructure.Persistence
{
	public class ApplicationDbContextInitialiser
	{
		private readonly ILogger<ApplicationDbContextInitialiser> _logger;
		private readonly ApplicationDbContext _context;

		public ApplicationDbContextInitialiser(
			ILogger<ApplicationDbContextInitialiser> logger,
			ApplicationDbContext context
		)
		{
			_logger = logger;
			_context = context;
		}

		public async Task InitialiseAsync()
		{
			try
			{
				//if (_context.Database.IsSqlServer())
				//{
				//	await _context.Database.MigrateAsync();
				//}

				//await _context.Database.MigrateAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while initialising the database.");
				throw;
			}
		}

		public async Task SeedAsync()
		{
			try
			{
				await TrySeedAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while seeding the database.");
				throw;
			}
		}

		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public async Task TrySeedAsync()
		{
			// Default weathers
			var weatherForecast = new WeatherForecast();

			weatherForecast.Date = DateTime.Now.Date;
			weatherForecast.TemperatureC = Random.Shared.Next(-20, 55);
			weatherForecast.Summary = Summaries[Random.Shared.Next(Summaries.Length)];

			_context.WeatherForecasts.Add(weatherForecast);

			var weatherForecast2 = new WeatherForecast();
			weatherForecast2.Date = DateTime.Now.AddDays(1).Date;
			weatherForecast2.TemperatureC = Random.Shared.Next(-20, 55);
			weatherForecast2.Summary = Summaries[Random.Shared.Next(Summaries.Length)];

			_context.WeatherForecasts.Add(weatherForecast2);

			await _context.SaveChangesAsync();
		}
	}
}
