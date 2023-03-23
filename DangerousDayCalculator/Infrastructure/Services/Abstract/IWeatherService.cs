using Application.Models;

namespace Infrastructure.Services.Abstract
{
	public interface IWeatherService
	{
		Task<WeatherDto?> GetWeatherDtoByDateAsync(DateTime date);
	}
}
