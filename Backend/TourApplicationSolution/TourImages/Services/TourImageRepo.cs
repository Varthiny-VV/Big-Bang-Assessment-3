using Microsoft.EntityFrameworkCore;
using TourImages.Interfaces;
using TourImages.Models;

namespace TourImages.Services
{
    public class TourImageRepo : IRepo<int, ImageTourism>
    {
        private readonly ImageContext _context;

        public TourImageRepo(ImageContext context)
        {
            _context = context;
        }
        public async Task<ImageTourism?> Add(ImageTourism item)
        {
            _context.ImagesTourism.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task<ImageTourism?> Delete(ImageTourism item)
        {
            throw new NotImplementedException();
        }

        public async Task<ImageTourism?> Get(int id)
        {
            return await _context.ImagesTourism.FindAsync(id);
        }

        public async Task<ICollection<ImageTourism>?> GetAll()
        {
            return await _context.ImagesTourism.ToListAsync();
        }

        public Task<ImageTourism?> Update(ImageTourism item)
        {
            throw new NotImplementedException();
        }
    }
}
