using HotelReservasapp.BusinessLogic.Entities;
using HotelReservasapp.BusinessLogic.Interfaces;
using HotelReservasapp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservasapp.DataAccess.Repositories;

public class FloorRepository : BaseRepository<Floor>, IFloorRepository
{
    public FloorRepository(HotelReservationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Floor>> GetByHotelAsync(int idHotel)
    {
        if (idHotel <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(idHotel));
        }
            
        return await _dbSet
            .AsNoTracking()
            .Where(p => p.IdHotel == idHotel)
            .ToListAsync();
    }
}