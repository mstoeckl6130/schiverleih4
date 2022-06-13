using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schiverleih4.Data.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public long PhoneNumber { get; set; }
        [ForeignKey("Addresses")]
        public int AddressId { get; set; }
       
        public Addresses Addresses { get; set; }
        public ICollection<Rents> Rents { get; set; }
    }
}
