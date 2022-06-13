using schiverleih4.CustomValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace schiverleih4.Data.Models
{
    public class Products
    {
        [Key]
        public int ProductNumber { get; set; }
        [Required(ErrorMessage ="Bitte geben Sie einen Wert ein.")]
        public string ProductTitle { get; set; }
        [Required(ErrorMessage = "Bitte geben Sie einen Wert ein."), PriceValidation]
        public double Price { get; set; }
        [Required]
        public int Counter { get; set; }
        [Required, ForeignKey("Categories")]
        public int CategoryId { get; set; }
        [Required, ForeignKey("States")]
        public int StatusId { get; set; }
        public States States { get; set; }
        public Categories Categories { get; set; }
        
        public ICollection<Rents> Rents { get; set; }
    }
}
