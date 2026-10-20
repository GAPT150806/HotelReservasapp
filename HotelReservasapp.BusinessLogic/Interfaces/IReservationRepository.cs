using HotelReservasapp.BusinessLogic.Entities;

namespace HotelReservasapp.BusinessLogic.Interfaces
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetByHabitacionAsync(int idHabitacion);
    }
}
