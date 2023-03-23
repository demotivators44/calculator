using Application.Models;
using Infrastructure.Services.Abstract;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Infrastructure.Services
{
	public class WeatherService : IWeatherService
	{
		public async Task<WeatherDto?> GetWeatherDtoByDateAsync(DateTime date)
		{
			WeatherDto? weather = null;

			try
			{
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri("https://localhost:5001/");
					client.DefaultRequestHeaders.Accept.Clear();
					client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					var path = "api/weatherforecast" + "/" + date.ToString("MM-dd-yyyy");

					// HTTP GET
					HttpResponseMessage response = await client.GetAsync(path);
					if (response.IsSuccessStatusCode)
					{
						weather = await response.Content.ReadFromJsonAsync<WeatherDto>();
					}
				}
			}
			catch (Exception ex)
			{
				return weather;
			}

			return weather;
		}
	}
}
