using Microsoft.EntityFrameworkCore;
using TourPackages.Interfaces;
using TourPackages.Models;


namespace TourPackages.Services
{
    public class PackageRepo : IRepo<int, Package>
    {
        private readonly Context _context;
        private readonly ILogger<Package> _logger;

        public PackageRepo(Context context, ILogger<Package> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Package?> Add(Package item)
        {
            try
            {
                _context.Packages.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Package?> Delete(int key)
        {
            try
            {
                var doc = await Get(key);
                if (doc != null)
                {
                    _context.Packages.Remove(doc);
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

        public async Task<Package?> Get(int key)
        {
            try
            {
                var doc = await _context.Packages.FirstOrDefaultAsync(i => i.PackageId == key);
                return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<ICollection<Package>?> GetAll()
        {
            try
            {
                var doc = await _context.Packages.ToListAsync();
                if (doc.Count > 0)
                    return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<Package?> Update(Package item)
        {
            try
            {
                var existingDoctor = await _context.Packages.FindAsync(item.PackageId);
                if (existingDoctor != null)
                {
                    existingDoctor.TravelAgencyName = item.TravelAgencyName;
                    existingDoctor.PackageName = item.PackageName;
                    existingDoctor.Description = item.Description;
                    existingDoctor.Price = item.Price;
                    existingDoctor.StartDate = item.StartDate;
                    existingDoctor.EndDate = item.EndDate;
                    existingDoctor.Image = item.Image;
                    existingDoctor.AvailabilityCount = item.AvailabilityCount;
                    existingDoctor.Duration = item.Duration;
                    existingDoctor.Transportation = item.Transportation;


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
