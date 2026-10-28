using HotelReservasapp.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservasapp.DataAccess.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.ToTable("Hoteles");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Nombre)
            .HasMaxLength(150)
            .IsRequired();

        builder.HasIndex(h => h.Nombre)
            .IsUnique();

        builder.Property(h => h.Estado)
            .HasColumnType("varchar(15)")
            .HasConversion<string>()
            .IsRequired();
    }
}