using MediatR;

namespace Weather.Application.WeatherForecasts.Commands.CreateWeatherForecast
{
	public record CreateWeatherCommand : IRequest<int>
	{
		public DateTime Date { get; init; }
		public int TemperatureC { get; init; }
		public string? Summary { get; init; }
	}

	public class CreateWeatherHandler : IRequestHandler<CreateWeatherCommand, int>
	{
		private readonly IApplicationDbContext _context;

		public CreateWeatherHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateWeatherCommand request, CancellationToken cancellationToken)
		{
			var entity = new WeatherForecast();

			entity.Date = request.Date.Date;
			entity.TemperatureC = request.TemperatureC;
			entity.Summary = request.Summary;

			_context.WeatherForecasts.Add(entity);

			await _context.SaveChangesAsync(cancellationToken);

			return entity.Id;
		}
	}
}