using KaraokePartyWebApp.Data;
using KaraokePartyWebApp.Interfaces;
using KaraokePartyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KaraokePartyWebApp.Repository
{
    public class KaraokeGroupRepository : IKaraokeGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public KaraokeGroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(KaraokeGroup karaokeGroup)
        {
            _context.Add(karaokeGroup);
            return Save();
        }

        public bool Delete(KaraokeGroup karaokeGroup)
        {
            _context.Remove(karaokeGroup);
            return Save();
        }

        public async Task<IEnumerable<KaraokeGroup>> GetAll()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<KaraokeGroup> GetByIdAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(KaraokeGroup karaokeGroup)
        {
            _context.Update(karaokeGroup);
            return Save();
        }
    }
}
