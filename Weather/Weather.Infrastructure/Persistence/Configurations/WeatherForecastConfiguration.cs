using Weather.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Weather.Infrastructure.Persistence.Configurations
{
	public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
	{
		public void Configure(EntityTypeBuilder<WeatherForecast> builder)
		{
			builder.HasKey(t=>t.Id);
			builder.Property(t => t.Summary).HasMaxLength(64);
		}
	}
}
