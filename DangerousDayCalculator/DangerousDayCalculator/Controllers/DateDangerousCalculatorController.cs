using Application.Models;
using Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DangerousDayCalculator.Controllers
{
	[ApiController]
	[Route("api/datedangerouscalculator")]
	public class DateDangerousCalculatorController : ControllerBase
	{

		private readonly IDateDangerousCalculatorService _dateDangerousCalculatorService;

		public DateDangerousCalculatorController(IDateDangerousCalculatorService dateDangerousCalculatorService)
		{
			_dateDangerousCalculatorService = dateDangerousCalculatorService;
		}


		[HttpGet("{date:DateTime}", Name = "GetDangerousDateInfo")]
		public async Task<ActionResult<DangerousDateDto>> GetDangerousDateInfo(DateTime date)
		{
			return await _dateDangerousCalculatorService.GetDangerousDateInfoAsync(date.Date);
		}
	}
}