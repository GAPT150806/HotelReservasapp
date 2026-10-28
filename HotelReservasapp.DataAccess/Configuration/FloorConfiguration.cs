using HotelReservasapp.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservasapp.DataAccess.Configurations;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.ToTable("Pisos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Numero)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(p => p.Estado)
            .HasColumnType("varchar(15)")
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne<Hotel>()
            .WithMany()
            .HasForeignKey(p => p.IdHotel)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasAlternateKey(p => new { p.Id, p.IdHotel });

        builder.HasIndex(p => new { p.IdHotel, p.Numero })
            .IsUnique()
            .HasFilter("[Estado] = 'Activo'");
    }
}