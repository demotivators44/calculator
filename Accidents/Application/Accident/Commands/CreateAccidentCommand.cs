using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Accidents.Commands
{
	public record CreateAccidentCommand : IRequest<int>
	{
		public DateTime Date { get; set; }
		public string? Type { get; set; }
		public int ApproximateDamages { get; set; }
	}

	public class CreateAccidentHandler : IRequestHandler<CreateAccidentCommand, int>
	{
		private readonly IApplicationDbContext _context;
		private readonly IRabbitMqService _mqService;

		public CreateAccidentHandler(IApplicationDbContext context, IRabbitMqService mqService)
		{
			_context = context;
			_mqService = mqService;
		}

		public async Task<int> Handle(CreateAccidentCommand request, CancellationToken cancellationToken)
		{
			var entity = new Accident();

			entity.Date = request.Date.Date;
			entity.Type = request.Type;
			entity.ApproximateDamages = request.ApproximateDamages;

			_context.Accidents.Add(entity);

			await _context.SaveChangesAsync(cancellationToken);


			_mqService.SendMessage(request.Type);
			return entity.Id;
		}
	}
}
