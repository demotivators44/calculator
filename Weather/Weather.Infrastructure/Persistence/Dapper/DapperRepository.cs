using Dapper;
using System.Data;
using Weather.Application.Common.Interfaces;
using Weather.Domain.Entities;

namespace Weather.Infrastructure.Persistence.Dapper
{
	public class DapperRepository : IDapperRepository
	{

		private readonly DapperContext _context;
		public DapperRepository(DapperContext context)
		{
			_context = context;
		}

		public async Task<int> CreateWeather(DateTime date, int temperatureC, string? summary)
		{
			var query = "INSERT INTO WeatherForecasts (Date, TemperatureC, Summary) VALUES (@Date, @TemperatureC, @Summary)" + "SELECT CAST(SCOPE_IDENTITY() as int)";

			var parameters = new DynamicParameters();
			parameters.Add("Date", date, DbType.DateTime);
			parameters.Add("TemperatureC", temperatureC, DbType.Int32);
			parameters.Add("Summary", summary, DbType.String);

			//using (var connection = new SqlConnection("Server=localhost;Port=5555;Database=WeatherDb;User Id=postgres;Password=24816qwerty;"))
			//{
			//	return await connection.QuerySingleAsync<int>(query, parameters);
			//}
			using (var connection = _context.CreateConnection())
			{
				return await connection.QuerySingleAsync<int>(query, parameters);
			}
		}

		public async Task<WeatherForecast> GetWeatherByDate(DateTime date)
		{
			var query = "SELECT * FROM WeatherForecasts WHERE Date = @Date";
			var query2 = "SELECT Id, Date, TemperatureC, Summary FROM WeatherForecasts WHERE Date = @Date";

			//using (var connection = new SqlConnection("Server=localhost;Port=5555;Database=WeatherDb;User Id=postgres;Password=24816qwerty;"))
			//{
			//	var id = await connection.QuerySingleOrDefaultAsync<WeatherForecast>(query, new { date });
			//	return id;
			//}
			using (var connection = _context.CreateConnection())
			{
				try
				{
					var company = await connection.QuerySingleOrDefaultAsync<WeatherForecast>(query2, new { date });
					return company;
				}
				catch (Exception e)
				{

				}
				return null;
			}
		}
	}
}
