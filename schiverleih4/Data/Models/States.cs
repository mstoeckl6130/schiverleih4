using System.ComponentModel.DataAnnotations;

namespace schiverleih4.Data.Models
{
    public class States
    {
        [Key]
        public int StatusId { get; set; }
        [Required, MaxLength(5, ErrorMessage ="Der Status darf nicht mehr als 5 Zeichen betragen.")]
        public string Status { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
