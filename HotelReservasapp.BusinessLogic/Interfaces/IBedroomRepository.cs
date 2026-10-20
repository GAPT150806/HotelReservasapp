using HotelReservasapp.BusinessLogic.Entities;

namespace HotelReservasapp.BusinessLogic.Interfaces
{
    public interface IBedroomRepository : IBaseRepository<Bedroom>
    {
        Task<IEnumerable<Bedroom>> GetByHotelAsync(int idHotel);
        Task<IEnumerable<Bedroom>> GetByPisoAsync(int idPiso);
    }
}
