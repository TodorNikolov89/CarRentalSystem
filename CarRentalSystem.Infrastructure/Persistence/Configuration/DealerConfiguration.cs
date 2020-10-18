namespace CarRentalSystem.Infrastructure.Persistence.Configuration
{
    using Domain.Models.Dealers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using static CarRentalSystem.Domain.ModelConstants.Common;

    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .OwnsOne(d => d.PhoneNumber, p =>
                  {
                      p.WithOwner();

                      p.Property(pn => pn.Number);
                  });

            builder
                .HasMany(d => d.CarAds)
                .WithOne()
                .Metadata
                .PrincipalToDependent
                .SetField("carAds");
        }
    }
}
