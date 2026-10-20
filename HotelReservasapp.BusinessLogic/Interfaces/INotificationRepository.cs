using HotelReservasapp.BusinessLogic.Entities;

namespace HotelReservasapp.BusinessLogic.Interfaces
{
    public interface INotificationRepository : IBaseRepository<Notification>
    {
        Task<Notification> GetByReservationAsync(int id);
    }
}
