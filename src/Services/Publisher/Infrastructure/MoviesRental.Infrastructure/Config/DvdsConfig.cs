using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesRental.Domain.Entities;
using MoviesRental.Domain.Entities.Enums;


namespace MoviesRental.Infrastructure.Config
{
    public class DvdsConfig : IEntityTypeConfiguration<Dvd>
    {
        public void Configure(EntityTypeBuilder<Dvd> builder)
        {
            builder.ToTable("Dvds");

            builder.HasKey(d => d.Id);

            builder.HasIndex(d => d.Title)
                .IsUnique();

            builder.Property(d => d.Title)
                .IsRequired()
                .HasMaxLength(Dvd.MAX_TITLE_LENGTH);

            builder.Property(d => d.Copies)
                .IsRequired();

            builder.Property(d => d.Available)
                .IsRequired();

            builder.Property(d => d.Published)
                .IsRequired();

            builder.Property(d => d.CreatedAt)
                .IsRequired();

            builder.Property(d => d.UpdatedAt)
                .IsRequired();

            builder.Property(d => d.DirectorId)
                .IsRequired();

            builder.HasOne(d => d.Director)
                .WithMany(c => c.Dvds)
                .HasForeignKey(d => d.DirectorId);

            builder.Property(d => d.Genre)
                .HasConversion(v => v.ToString(), v => (EGenre)Enum.Parse(typeof(EGenre), v));
        }
    }
}
