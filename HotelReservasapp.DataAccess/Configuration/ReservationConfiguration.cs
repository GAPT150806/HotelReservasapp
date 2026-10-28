using HotelReservasapp.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservasapp.DataAccess.Configurations;

public class ReservationConfiguration
    : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.ToTable("Reservas");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.FechaEntrada)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(r => r.FechaSalida)
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(r => r.CantidadHuespedes)
            .HasColumnType("smallint")
            .IsRequired();

        builder.Property(r => r.TarifaPorNoche)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(r => r.Total)
            .HasPrecision(12, 2)
            .IsRequired();

        builder.Property(r => r.Estado)
            .HasColumnType("varchar(15)")
            .HasConversion<string>()
            .IsRequired();

        builder.HasOne<Bedroom>()
            .WithMany()
            .HasForeignKey(r => r.IdHabitacion)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Guest>()
            .WithMany()
            .HasForeignKey(r => r.IdHuesped)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => new
        {
            r.IdHabitacion,
            r.FechaEntrada,
            r.FechaSalida
        })
            .HasDatabaseName("IX_Reservas_Habitacion_Fechas");
    }
}