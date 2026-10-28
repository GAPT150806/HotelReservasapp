using HotelReservasapp.BusinessLogic.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelReservasapp.DataAccess.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notificaciones");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Tipo)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(n => n.Estado)
            .HasColumnType("varchar(15)")
            .IsRequired();

        builder.Property(n => n.FechaCreacion)
            .HasColumnType("datetime2")
            .HasDefaultValueSql("SYSDATETIME()")
            .ValueGeneratedOnAdd();

        builder.Property(n => n.FechaEnvio)
            .HasColumnType("datetime2")
            .IsRequired(false);

        builder.HasOne<Reservation>()
            .WithMany()
            .HasForeignKey(n => n.IdReserva)
            .OnDelete(DeleteBehavior.Restrict);
    }
}