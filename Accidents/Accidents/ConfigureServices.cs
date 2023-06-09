﻿namespace Microsoft.Extensions.DependencyInjection
{
	public static class ConfigureServices
	{
		public static IServiceCollection AddWebApiServices(this IServiceCollection services)
		{
			services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			return services;
		}
	}
}