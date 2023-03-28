using KaraokePartyWebApp.Data;
using KaraokePartyWebApp.Interfaces;
using KaraokePartyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace KaraokePartyWebApp.Repository
{
    public class KaraokeClubRepository : IKaraokeClubRepository
    {
        private readonly ApplicationDbContext _context;
        public KaraokeClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(KaraokeClub club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Delete(KaraokeClub club)
        {
            _context.Remove(club);
            return Save();
        }
        
        public async Task<IEnumerable<KaraokeClub>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<KaraokeClub> GetByIdAsync(int id)
        {
            return await _context.Clubs.Include(i => i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<KaraokeClub>> GetClubsByCity(string city)
        {
            return await _context.Clubs.Where(c => c.Address.Cidade.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true: false;
        }

        public bool Update(KaraokeClub club)
        {
            _context.Update(club);
            return Save();
        }
    }
}
