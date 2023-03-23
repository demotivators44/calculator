using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Weather.Infrastructure.Persistence.Dapper
{
	public class DapperContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;
		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("DefaultPgConnection");
		}
		public IDbConnection CreateConnection()
			=> new NpgsqlConnection(_connectionString);
	}
}
