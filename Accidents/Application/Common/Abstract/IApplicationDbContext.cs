using Microsoft.EntityFrameworkCore;

namespace Application.Common.Abstract
{
	public interface IApplicationDbContext
	{
		DbSet<Accident> Accidents { get; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken);
	}
}
