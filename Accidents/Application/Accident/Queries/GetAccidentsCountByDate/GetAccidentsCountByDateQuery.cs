using Application.Common.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Accidents.Queries.GetAccidentsCountByDate
{
	public class GetAccidentsCountByDateQuery : IRequest<int>
	{
		public DateTime Date { get; set; }
	}

	public class GetWeatherForecastQueryHandler : IRequestHandler<GetAccidentsCountByDateQuery, int>
	{
		private readonly IApplicationDbContext _context;

		public GetWeatherForecastQueryHandler(IApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<int> Handle(GetAccidentsCountByDateQuery request, CancellationToken cancellationToken)
		{
			// Default weathers


			return await _context.Accidents.Where(a => a.Date.Date == request.Date.Date).CountAsync();
		}
	}
}
