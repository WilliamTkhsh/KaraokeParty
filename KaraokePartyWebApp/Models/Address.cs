using System.ComponentModel.DataAnnotations;

namespace KaraokePartyWebApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Estado {  get; set; }
        public string CEP { get; set; }

    }
}
