using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using Weather.Application.WeatherForecasts.Commands.CreateWeatherForecast;
using Weather.Application.WeatherForecasts.Queries;
using Weather.Application.WeatherForecasts.Queries.GetWeatherByDateQuery;

namespace Weather.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ApiControllerBase
	{
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        //private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(
            IMediator mediator,
            ILogger<WeatherForecastController> logger
        ) => _mediator = mediator;
        //{
        //    _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        //    _logger = logger;
        //}




		[HttpGet("GetByDate")]
		public async Task<ActionResult<WeatherForecastDto>> GetByDate(DateTime date)
		{
			return await Mediator.Send(new GetWeatherByDateQuery { Date = date });
		}

		[HttpPost("Create")]
		public async Task<ActionResult<int>> Post(CreateWeatherCommand request)
		{
			return await Mediator.Send(request);
		}
		
		//[HttpGet("GetByDateDapper")]
		//public async Task<ActionResult<WeatherForecastDto>> GetByDateDapper(DateTime date)
		//{
			//return await Mediator.Send(new GetWeatherByDateByDapperQuery { Date = date });
		//}

		//[HttpPost("CreateDapper")]
		//public async Task<ActionResult<int>> PostDapper(CreateWeatherByDapperCommand request)
		//{
			//return await Mediator.Send(request);
		//}

		//[HttpGet("GetByDateCassandra")]
		//public async Task<ActionResult<WeatherForecastDto>> GetByDateCassandra(DateTime date)
		//{
			//return await Mediator.Send(new GetWeatherByDateByCassandraQuery { Date = date });
		//}






		//      [HttpGet(Name = "GetWeatherForecast")]
		//public async Task<IEnumerable<WeatherForecastDto>> Get()
		//{
		//	var list = await Task.Run(() => GetList());

		//	return list;
		//}

		//private IEnumerable<WeatherForecastDto> GetList()
		//      {
		//          return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
		//          {
		//              Date = DateTime.Now.AddDays(index),
		//              TemperatureC = Random.Shared.Next(-20, 55),
		//              Summary = Summaries[Random.Shared.Next(Summaries.Length)]
		//          })
		//          .ToList();
		//}
	}
}