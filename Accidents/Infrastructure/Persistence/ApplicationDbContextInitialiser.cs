using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence
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
				if (_context.Database.IsSqlServer())
				{
					await _context.Database.MigrateAsync();
				}
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

		private static readonly string[] Types = new[]
		{
			"Auto", "Truck", "Moto", "Auto & Moto", "Auto & Truck", "Moto & Truck", "Auto & Moto & Truck"
		};

		public async Task TrySeedAsync()
		{
			// Default weathers
			var accident = new Accident();

			accident.Date = DateTime.Now.Date;
			accident.Type = Types[Random.Shared.Next(Types.Length)];
			accident.ApproximateDamages = Random.Shared.Next(1, 1000000);

			_context.Accidents.Add(accident);

			var accident1 = new Accident();

			accident1.Date = DateTime.Now.Date;
			accident1.Type = Types[Random.Shared.Next(Types.Length)];
			accident1.ApproximateDamages = Random.Shared.Next(1, 1000000);

			_context.Accidents.Add(accident1);

			var accident2 = new Accident();
			accident2.Date = DateTime.Now.AddDays(1).Date;
			accident2.Type = Types[Random.Shared.Next(Types.Length)];
			accident2.ApproximateDamages = Random.Shared.Next(1, 10000000);

			_context.Accidents.Add(accident2);

			await _context.SaveChangesAsync();
		}
	}
}
