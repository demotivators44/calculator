using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Weather.Application.WeatherForecasts.Queries.GetWeatherByDateQuery
{
	public class GetWeatherByDateByDapperQuery : IRequest<WeatherForecastDto>
	{
		public DateTime Date { get; set; }
	}

	public class GetWeatherByDateByDapperQueryHandler : IRequestHandler<GetWeatherByDateByDapperQuery, WeatherForecastDto>
	{
		private readonly IDapperRepository _dapperRepository;

		private readonly IMapper _mapper;

		public GetWeatherByDateByDapperQueryHandler(IDapperRepository dapperRepository, IMapper mapper)
		{
			_mapper = mapper;
			_dapperRepository = dapperRepository;
		}

		public async Task<WeatherForecastDto> Handle(GetWeatherByDateByDapperQuery request, CancellationToken cancellationToken)
		{
			var entity = await _dapperRepository.GetWeatherByDate(request.Date.Date);

			var weather = _mapper.Map<WeatherForecastDto>(entity);

			return weather;
		}
	}
}
