using KaraokePartyWebApp.Models;

namespace KaraokePartyWebApp.Interfaces
{
    public interface IKaraokeClubRepository
    {
        Task<IEnumerable<KaraokeClub>> GetAll();
        Task<KaraokeClub> GetByIdAsync(int id);
        Task<IEnumerable<KaraokeClub>> GetClubsByCity(string city);
        bool Add(KaraokeClub club);
        bool Delete(KaraokeClub club);
        bool Update(KaraokeClub club);
        bool Save();

    }
}
