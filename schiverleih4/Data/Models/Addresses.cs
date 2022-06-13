using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schiverleih4.Data.Models
{
    public class Addresses
    {
        [Key]
        public int AddressId { get; set; }
        [ForeignKey("Streets")]
        public int StreetId { get; set; }
        [ForeignKey("Cities")]
        public string ZIPCode { get; set; }
        [ForeignKey("Countries")]
        public string AreaCode { get; set; }
        
        
        public Streets Streets { get; set; }
        public Cities Cities { get; set; }
        public Countries Countries { get; set; }
       
        public ICollection<Customers> Customers { get; set; }


    }
}
