using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesRental.Domain.Entities;


namespace MoviesRental.Infrastructure.Config
{
    public class DirectorsConfig : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            builder.ToTable("Directors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(Director.MAX_NAME_LENGTH);

            builder.Property(d => d.Surname)
                .IsRequired()
                .HasMaxLength(Director.MAX_NAME_LENGTH);

            builder.Property(d => d.CreatedAt)
                .IsRequired();

            builder.Property(d => d.UpdatedAt)
                .IsRequired();

            builder.HasMany(d => d.Dvds)
                .WithOne(c => c.Director);
        }
    }
}
