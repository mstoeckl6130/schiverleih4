using System.ComponentModel.DataAnnotations;

namespace schiverleih4.Data.Models
{
    public class Cities
    {
        [Key]
        public string ZIPCode { get; set; }
        public string CityName { get; set; }
        public ICollection<Addresses> Addresses { get; set; }
    }
}
