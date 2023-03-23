using Application.Models;
using Application.Services.Abstract;
using Infrastructure.Services.Abstract;

namespace Infrastructure.Services
{
	public class DateDangerousCalculatorService : IDateDangerousCalculatorService
	{
		private readonly IAccidentService _accidentService;
		private readonly IWeatherService _weatherService;

		public DateDangerousCalculatorService(IAccidentService accidentService, IWeatherService weatherService)
		{
			_accidentService = accidentService;
			_weatherService = weatherService;
		}

		public async Task<DangerousDateDto> GetDangerousDateInfoAsync(DateTime date)
		{
			DangerousDateDto dangerousDateInfo = new DangerousDateDto()
			{
				Date = date,
				Weather = await _weatherService.GetWeatherDtoByDateAsync(date),
				AccidentsCount = await _accidentService.GetAccidentsCountByDate(date)
			};

			return dangerousDateInfo;
		}
	}
}
