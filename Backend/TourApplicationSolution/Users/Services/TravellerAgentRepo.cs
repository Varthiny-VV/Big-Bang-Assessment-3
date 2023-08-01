using Microsoft.EntityFrameworkCore;
using SignInAndSignUp.Interfaces;
using SignInAndSignUp.Models;

namespace SignInAndSignUp.Services
{
    public class TravellerAgentRepo : IRepo<TravelAgent, string>
    {
        private readonly Context _context;

        public TravellerAgentRepo(Context context)
        {
            _context = context;
        }
        public async Task<TravelAgent?> Add(TravelAgent item)
        {
            var travelAgent_mail = _context.TravelAgents.SingleOrDefault(d => d.Email == item.Email);
            if (travelAgent_mail == null)
            {
                try
                {
                    _context.TravelAgents.Add(item);
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


        public async Task<TravelAgent?> Delete(string id)
        {
            try
            {
                var travelAgent = await Get(id);
                if (travelAgent != null)
                {
                    _context.TravelAgents.Remove(travelAgent);
                    await _context.SaveChangesAsync();

                    return travelAgent;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        

        public async Task<TravelAgent?> Get(string id)
        {
            try
            {
                var travelAgent = await _context.TravelAgents.SingleOrDefaultAsync(i => i.Email == id);
                if (travelAgent == null)
                {
                    return null;
                }
                return travelAgent;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

       

        public async Task<ICollection<TravelAgent>?> GetAll()
        {
            try
            {
                var travelAgents = await _context.TravelAgents.ToListAsync();
                if (travelAgents != null)
                {
                    return travelAgents;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<TravelAgent?> Update(TravelAgent item)
        {
            var travelAgent = _context.TravelAgents.SingleOrDefault(d => d.TravelAgentId == item.TravelAgentId);
            if (travelAgent != null)
            {
                try
                {
                    travelAgent.Name = item.Name;
                    travelAgent.DateOfBirth = item.DateOfBirth;
                    travelAgent.Address = item.Address;
                    travelAgent.Email = item.Email;
                    travelAgent.Phone = item.Phone;
                    travelAgent.AgencyName = item.AgencyName;
                    await _context.SaveChangesAsync();
                    return travelAgent;
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
