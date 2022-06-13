using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schiverleih4.Data.Models
{
    public class Rents
    {
        [Key]
        public int RentId { get; set; }
        [ForeignKey("Employees")]
        public string EmployeeId { get; set; }
        [ForeignKey("Customers")]
        public int CustomerId { get; set; }
        public int GiveBack { get; set; }
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public DateTime TimestampStart { get; set; }
        public DateTime TimestampEnd { get; set; }
        public Products Products { get; set; }
        public Employees Employees { get; set; }
        public Customers Customers { get; set; }
    }
}
