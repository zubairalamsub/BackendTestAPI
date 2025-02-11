using BackendTestAPI.DB;
using BackendTestAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendTestAPI.Repository
{
    public class FeedBackRepository : IRepository<Feedback>
    {
        private readonly AppDbContext _context;

        public FeedBackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync()
        {
            return await _context.Feedback.ToListAsync();
        }

        public async Task<Feedback> GetByIdAsync(int id)
        {
            return await _context.Feedback.FindAsync(id);
        }

        public async Task AddAsync(Feedback entity)
        {
            await _context.Feedback.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Feedback entity)
        {
            _context.Feedback.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Feedback.FindAsync(id);
            if (product != null)
            {
                _context.Feedback.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
