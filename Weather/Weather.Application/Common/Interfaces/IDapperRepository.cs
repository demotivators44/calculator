using Microsoft.AspNetCore.Mvc;

namespace Weather.Application.Common.Interfaces
{
	public interface IDapperRepository
	{
		Task<WeatherForecast> GetWeatherByDate(DateTime date);
		Task<int> CreateWeather(DateTime date, int temparatureC, string? summary);
	}
}
