using Microsoft.EntityFrameworkCore;
using schiverleih4.Data.Models;

namespace schiverleih4.Data.Repos
{
    public class ProductsRepo
    {
        public ApplicationDbContext dbContext;
        public ProductsRepo(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        public async Task<List<Products>> GetProducts()
        {
            try
            {
                var products = from p in dbContext.Products
                               select new Products
                               {
                                   ProductNumber = p.ProductNumber,
                                   ProductTitle = p.ProductTitle,
                                   CategoryId = p.CategoryId,
                                   Price = p.Price
                               };
                return await products.ToListAsync();
            }
            catch
            {
                return null;
            }
            
        }
    }
}
