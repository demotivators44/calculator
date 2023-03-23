using Application.Models;

namespace Application.Services.Abstract
{
	public interface IDateDangerousCalculatorService
	{
		Task<DangerousDateDto> GetDangerousDateInfoAsync(DateTime date);
	}
}
