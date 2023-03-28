using KaraokePartyWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KaraokePartyWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<KaraokeClub> Clubs { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<KaraokeGroup> Groups { get; set; }
    }
}
