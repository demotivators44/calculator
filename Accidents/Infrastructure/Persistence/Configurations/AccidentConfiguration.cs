using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
	public class AccidentConfiguration : IEntityTypeConfiguration<Accident>
	{
		public void Configure(EntityTypeBuilder<Accident> builder)
		{
			builder.Property(t => t.Date).IsRequired();
			builder.Property(t => t.Type).HasMaxLength(35);
			builder.Property(t => t.ApproximateDamages);
			builder.Property(t => t.ApproximateDamages2);
		}
	}
}
