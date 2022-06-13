using System.ComponentModel.DataAnnotations;

namespace schiverleih4.Data.Models
{
    public class Streets
    {
        [Key]
        public int StreetId { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
