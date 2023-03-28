using KaraokePartyWebApp.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KaraokePartyWebApp.Models
{
    public class KaraokeClub
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {  get; set; }

        public string Image { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public Category Category { get; set; }
    }
}
