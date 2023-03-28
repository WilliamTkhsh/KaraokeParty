using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaraokePartyWebApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfileImageUrl { get; set; }
        public int? Age { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<KaraokeGroup> Groups { get; set; }
    }
}
