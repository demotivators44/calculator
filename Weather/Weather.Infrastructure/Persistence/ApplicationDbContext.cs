using Weather.Application.Common.Interfaces;
using Weather.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;


namespace Weather.Infrastructure.Persistence
{
	public class ApplicationDbContext : DbContext, IApplicationDbContext
	{
		private readonly IMediator _mediator;

		public ApplicationDbContext(
			DbContextOptions<ApplicationDbContext> options,
			IMediator mediator
		) : base(options)
		{
			_mediator = mediator;
		}

		// WeatherForecasts
		public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.Entity<WeatherForecast>(e => e.ToTable("WeatherForecasts"));
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}