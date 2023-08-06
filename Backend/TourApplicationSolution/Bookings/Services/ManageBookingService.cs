using Bookings.Interfaces;
using Bookings.Models;

namespace Bookings.Services
{
    public class ManageBookingService : IManageBooking
    {
        private readonly IRepo<AdditionalTravellers, int> _otherTravellersRepo;
        private readonly IRepo<Booking, int> _reservationRepo;
        public ManageBookingService(IRepo<AdditionalTravellers, int> otherTravellerRepo, IRepo<Booking, int> reservationRepo)
        {
            _reservationRepo = reservationRepo;
            _otherTravellersRepo = otherTravellerRepo;
        }

        public async Task<Booking> AddReseration(Booking reservation)
        {
            try
            {
                
                    if (reservation.AvailableCount > 0 && reservation.AvailableCount >= reservation.TravellerCount)
                    {
                        var res = await _reservationRepo.Add(reservation);
                        if (res != null)
                            return res;
                        return null;
                    }
                    return null;
                
                var res1 = await _reservationRepo.Add(reservation);
                if (res1 != null) return res1;
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ICollection<AdditionalTravellers>> GetGuestsByTravellerEmail(string id)
        {
            try
            {
                var guests = await _otherTravellersRepo.GetAll();
                if (guests == null)
                {
                    return new List<AdditionalTravellers>();
                }

                return guests.Where(g => g.TravellerEmail == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Booking>> GetReservationByPackageId(int id)
        {
            try
            {
                var reservations = await _reservationRepo.GetAll();
                if (reservations == null)
                {
                    return new List<Booking>();
                }

                return reservations.Where(r => r.PackageId == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Booking>> GetReservationByTravellerEmail(string id)
        {
            try
            {
                var reservations = await _reservationRepo.GetAll();
                if (reservations == null)
                {
                    return new List<Booking>();
                }

                return reservations.Where(r => r.TravellerEmail == id).ToList();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }


    }
}
