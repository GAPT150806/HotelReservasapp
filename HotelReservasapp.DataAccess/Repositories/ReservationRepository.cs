using HotelReservasapp.BusinessLogic.Entities;
using HotelReservasapp.BusinessLogic.Interfaces;
using HotelReservasapp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservasapp.DataAccess.Repositories;

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(HotelReservationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Reservation>> GetByHabitacionAsync(int idHabitacion)
    {
        if (idHabitacion <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(idHabitacion));
        }
           
        return await _dbSet
            .AsNoTracking()
            .Where(r => r.IdHabitacion == idHabitacion)
            .ToListAsync();
    }
}