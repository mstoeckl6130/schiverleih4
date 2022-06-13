using System.ComponentModel.DataAnnotations;

namespace schiverleih4.Data.Models
{
    public class Countries
    {
        [Key]
        public string AreaCode { get; set; }
        public string CountryName { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
