using Microsoft.AspNetCore.Identity;

namespace schiverleih4.Data.Models
{
    public class Employees:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Rents> Rents { get; set; }
    }
}
