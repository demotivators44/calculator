namespace Infrastructure.Services.Abstract
{
	public interface IAccidentService
	{
		Task<int> GetAccidentsCountByDate(DateTime date);
	}
}
