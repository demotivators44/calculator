using Weather.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Weather.Infrastructure.Persistence.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(t => t.Id);
			builder.Property(t => t.Name).HasMaxLength(64);
			builder.Property(t => t.SurName).HasMaxLength(64);
			builder.Property(t => t.MidleName).HasMaxLength(64);
		}
	}
}
