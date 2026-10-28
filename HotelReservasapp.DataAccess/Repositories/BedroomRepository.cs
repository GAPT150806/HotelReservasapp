using HotelReservasapp.BusinessLogic.Entities;
using HotelReservasapp.BusinessLogic.Interfaces;
using HotelReservasapp.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelReservasapp.DataAccess.Repositories;

public class BedroomRepository : BaseRepository<Bedroom>, IBedroomRepository
{
    public BedroomRepository(HotelReservationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Bedroom>> GetByHotelAsync(int idHotel)
    {
        if (idHotel <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(idHotel));
        }
            
        return await _dbSet
            .AsNoTracking()
            .Where(h => h.IdHotel == idHotel)
            .ToListAsync();
    }

    public async Task<IEnumerable<Bedroom>> GetByPisoAsync(int idPiso)
    {
        if (idPiso <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(idPiso));
        }
           
        return await _dbSet
            .AsNoTracking()
            .Where(h => h.IdPiso == idPiso)
            .ToListAsync();
    }
}