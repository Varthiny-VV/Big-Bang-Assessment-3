using Bookings.Models;

namespace Bookings.Interfaces
{
    public interface IManageBooking
    {
        public Task<ICollection<Booking>> GetReservationByPackageId(int id);
        public Task<ICollection<Booking>> GetReservationByTravellerEmail(string id);
        public Task<ICollection<AdditionalTravellers>> GetGuestsByTravellerEmail(string id);
        public Task<Booking> AddReseration(Booking reservation);
    }
}
