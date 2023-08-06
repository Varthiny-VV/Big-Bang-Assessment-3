using Bookings.Interfaces;
using Bookings.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookings.Services
{
    public class AdditionalTravellersRepo : IRepo<AdditionalTravellers, int>
    {
        private readonly Context _context;
        public AdditionalTravellersRepo(Context context)
        {
            _context = context;
        }
        public async Task<AdditionalTravellers?> Add(AdditionalTravellers item)
        {
            var user = _context.AdditionalTravellers.SingleOrDefault(u => u.AdditionalTravellerId == item.AdditionalTravellerId);
            if (user == null)
            {
                try
                {
                    _context.AdditionalTravellers.Add(item);
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

        public async Task<AdditionalTravellers?> Delete(int id)
        {
            try
            {
                var user = await Get(id);
                if (user != null)
                {
                    _context.AdditionalTravellers.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<AdditionalTravellers?> Get(int id)
        {
            try
            {
                var user = await _context.AdditionalTravellers.SingleOrDefaultAsync(u => u.AdditionalTravellerId == id);
                if (user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<AdditionalTravellers>?> GetAll()
        {
            try
            {
                var users = await _context.AdditionalTravellers.ToListAsync();
                if (users != null)
                {
                    return users;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<AdditionalTravellers?> Update(AdditionalTravellers item)
        {
            var user = _context.AdditionalTravellers.SingleOrDefault(u => u.AdditionalTravellerId == item.AdditionalTravellerId);
            if (user != null)
            {
                try
                {
                    user.Name = item.Name;
                    user.Age = item.Age;
                    user.PackageId = item.PackageId;
                    user.TravellerEmail = item.TravellerEmail;
                    await _context.SaveChangesAsync();
                    return user;
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
