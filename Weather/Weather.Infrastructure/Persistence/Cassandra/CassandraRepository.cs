using Cassandra;
using Dapper;
using System.Data;
using System.Diagnostics.Metrics;
using Weather.Application.Common.Interfaces;
using Weather.Domain.Entities;

namespace Weather.Infrastructure.Persistence.Cassandra
{
	public class CassandraRepository : ICassandraRepository
	{

		public async Task<int> CreateWeather(DateTime date, int temperatureC, string? summary)
		{
			//using (var connection = new SqlConnection("Server=localhost;Port=5555;Database=WeatherDb;User Id=postgres;Password=24816qwerty;"))
			//{
			//	return await connection.QuerySingleAsync<int>(query, parameters);
			//}
			using (var cluster = Cluster.Builder()
					 .AddContactPoints("127.0.0.1:9042")
					 .Build())
			{
				var session = cluster.Connect("store");

				var rs = session.Execute("SELECT * FROM weather");
				var K4os = 5;
			}

			return 0;
		}

		public async Task<WeatherForecast> GetWeatherByDate(DateTime date)
		{
			try
			{
				using (var cluster = Cluster.Builder()
						.WithPort(9042)
						.AddContactPoints("127.0.0.1")
						.Build())
				{
					var session = cluster.Connect("store");

					var rs = session.Execute("SELECT * FROM weather");
					var K4os = 5;
				}
			}
			catch (Exception e)
			{
				return null;
			}


			return null;
		}
	}
}
