using Microsoft.EntityFrameworkCore;
using TourPackages.Interfaces;
using TourPackages.Models;


namespace TourPackages.Services
{
    public class ContactDetailsRepo : IRepo<int, AgentContact>
    {
        private readonly Context _context;
        private readonly ILogger<AgentContact> _logger;

        public ContactDetailsRepo(Context context, ILogger<AgentContact> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<AgentContact?> Add(AgentContact item)
        {
            try
            {
                _context.AgentContacts.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<AgentContact?> Delete(int key)
        {
            try
            {
                var doc = await Get(key);
                if (doc != null)
                {
                    _context.AgentContacts.Remove(doc);
                    await _context.SaveChangesAsync();
                    return doc;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<AgentContact?> Get(int key)
        {
            try
            {
                var doc = await _context.AgentContacts.FirstOrDefaultAsync(i => i.Id == key);
                return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<AgentContact>?> GetAll()
        {
            try
            {
                var doc = await _context.AgentContacts.ToListAsync();
                if (doc.Count > 0)
                    return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<AgentContact?> Update(AgentContact item)
        {

            try
            {
                var existingDoctor = await _context.AgentContacts.FindAsync(item.Id);
                if (existingDoctor != null)
                {

                    existingDoctor.AgentName = item.AgentName;
                    existingDoctor.AgentEmail = item.AgentEmail;
                    existingDoctor.AgentPhoneNumber = item.AgentPhoneNumber;


                    await _context.SaveChangesAsync();

                    return existingDoctor;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
    }
}
