using KaraokePartyWebApp.Models;

namespace KaraokePartyWebApp.Interfaces
{
    public interface IKaraokeGroupRepository
    {
        Task<IEnumerable<KaraokeGroup>> GetAll();
        Task<KaraokeGroup> GetByIdAsync(int id);
        bool Add(KaraokeGroup karaokeGroup);
        bool Delete(KaraokeGroup karaokeGroup);
        bool Update(KaraokeGroup karaokeGroup);
        bool Save();
    }
}
