using Microsoft.EntityFrameworkCore;

namespace Weather.Application.Common.Interfaces
{
	public interface IApplicationDbContext
	{
		DbSet<WeatherForecast> WeatherForecasts { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
