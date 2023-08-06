using Bookings.Interfaces;
using Bookings.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Services
{
    public class BookingRepo : IRepo<Booking, int>
    {
        private readonly Context _context;
        public BookingRepo(Context context)
        {
            _context = context;
        }
        public async Task<Booking?> Add(Booking item)
        {
            var res = _context.AdditionalTravellers.SingleOrDefault(u => u.AdditionalTravellerId == item.BookingId);
            if (res == null)
            {
                try
                {
                    _context.Bookings.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }

        public async Task<Booking?> Delete(int id)
        {
            try
            {
                var res = await Get(id);
                if (res != null)
                {
                    _context.Bookings.Remove(res);
                    await _context.SaveChangesAsync();
                    return res;
                }
                return null;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Booking?> Get(int id)
        {
            try
            {
                var res = await _context.Bookings.SingleOrDefaultAsync(u => u.BookingId == id);
                if (res == null)
                {
                    return null;
                }
                return res;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Booking>?> GetAll()
        {
            try
            {
                var res = await _context.Bookings.ToListAsync();
                if (res != null)
                {
                    return res;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Booking?> Update(Booking item)
        {
            var res = _context.Bookings.SingleOrDefault(u => u.BookingId == item.BookingId);
            if (res != null)
            {
                try
                {
                    res.TravellerEmail = item.TravellerEmail;
                    res.TravellerCount = item.TravellerCount;
                    res.TravelAgentId = item.TravelAgentId;
                    res.AvailableCount = item.AvailableCount;
                    res.PickUp = item.PickUp;
                    res.Drop = item.Drop;
                    res.PackageId = item.PackageId;
        
                    await _context.SaveChangesAsync();
                    return res;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;

        }
    }
}
