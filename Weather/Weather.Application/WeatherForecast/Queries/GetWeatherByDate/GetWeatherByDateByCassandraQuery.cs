using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Weather.Application.WeatherForecasts.Queries.GetWeatherByDateQuery
{
	public class GetWeatherByDateByCassandraQuery : IRequest<WeatherForecastDto>
	{
		public DateTime Date { get; set; }
	}

	public class GetWeatherByDateByCassandraQueryHandler : IRequestHandler<GetWeatherByDateByCassandraQuery, WeatherForecastDto>
	{
		private readonly ICassandraRepository _cassandraRepository;

		private readonly IMapper _mapper;

		public GetWeatherByDateByCassandraQueryHandler(ICassandraRepository cassandraRepository, IMapper mapper)
		{
			_mapper = mapper;
			_cassandraRepository = cassandraRepository;
		}

		public async Task<WeatherForecastDto> Handle(GetWeatherByDateByCassandraQuery request, CancellationToken cancellationToken)
		{
			var entity = await _cassandraRepository.GetWeatherByDate(request.Date.Date);

			var weather = _mapper.Map<WeatherForecastDto>(entity);

			return weather;
		}
	}
}
