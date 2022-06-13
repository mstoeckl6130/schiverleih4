using Microsoft.EntityFrameworkCore;
using schiverleih4.Data.Models;

namespace schiverleih4.Data.Repos
{
    public class CustomersRepo
    {
        public ApplicationDbContext dbContext;
        public CustomersRepo(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public async Task<List<Customers>> GetCustomers()
        {
            try
            {
                var customers = from c in dbContext.Customers
                                select new Customers
                                {
                                    CustomerId = c.CustomerId,
                                    FirstName = c.FirstName,
                                    LastName = c.LastName
                                };
                return await customers.ToListAsync();
            }
            catch
            {
                return null;
            }
            
            
        }
    }
}
