using Application.Accidents.Commands;
using Application.Accidents.Queries.GetAccidentsCountByDate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Accidents.Controllers
{
	[ApiController]
	[Route("api/accidents")]
	public class AccidentsController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

		private readonly ILogger<AccidentsController> _logger;
		private readonly IMediator _mediator;
		public AccidentsController(IMediator mediator, ILogger<AccidentsController> logger)
		{
			_mediator = mediator;
			_logger = logger;
		}

		[HttpGet("countbydate")]
		public async Task<ActionResult<int>> GetAccidenceCount(DateTime date)
		{
			return await _mediator.Send(new GetAccidentsCountByDateQuery { Date = date });
		}

		[HttpPost("create")]
		public async Task<ActionResult<int>> Post(CreateAccidentCommand request)
		{
			return await _mediator.Send(request);
		}
	}
}