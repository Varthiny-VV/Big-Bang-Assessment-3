using Microsoft.EntityFrameworkCore;
using SignInAndSignUp.Interfaces;
using SignInAndSignUp.Models;

namespace SignInAndSignUp.Services
{
    public class UserRepo : IRepo<Users, string>
    {
        private readonly Context _context;
        public UserRepo(Context context)
        {
            _context = context;
        }

        public async Task<Users?> Add(Users item)
        {

            try
            {
                _context.Users.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return null;
        }

        public async Task<Users?> Delete(string id)
        {
            try
            {
                var user = await Get(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
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

        public async Task<Users?> Get(string id)
        {
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.EmailId == id);
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

        public async Task<ICollection<Users>?> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
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

        public async Task<Users?> Update(Users item)
        {
            var user = _context.Users.SingleOrDefault(u => u.EmailId == item.EmailId);
            if (user != null)
            {
                try
                {
                    user.EmailId = item.EmailId;
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
