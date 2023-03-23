using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Weather.Application.WeatherForecasts.Queries.GetWeatherByDateQuery
{
	public class GetWeatherByDateQuery : IRequest<WeatherForecastDto>
	{
		public DateTime Date { get; set; }
	}

	public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherByDateQuery, WeatherForecastDto>
	{
		private readonly IApplicationDbContext _context;

		private readonly IMapper _mapper;

		public GetWeatherForecastQueryHandler(IApplicationDbContext context, IMapper mapper)
		{
			_mapper = mapper;
			_context = context;
		}

		public async Task<WeatherForecastDto> Handle(GetWeatherByDateQuery request, CancellationToken cancellationToken)
		{
			var entity = await _context.WeatherForecasts.SingleOrDefaultAsync(u => u.Date.Date == request.Date.Date);

			var weather = _mapper.Map<WeatherForecastDto>(entity);

			return weather;
		}
	}
}
