using schiverleih4.Data.Components;
using schiverleih4.Data.Repos;

namespace schiverleih4.Data
{
    public class UnitOfWork:IUnitOfWork
    {
        public ApplicationDbContext dbContext;
        public RentsRepo rentsRepo;
        public ProductsRepo productsRepo;
        public CustomersRepo customersRepo;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
        public RentsRepo RentsRepo
        {
            get
            {
                if (rentsRepo == null) { rentsRepo = new RentsRepo(dbContext); }
                return rentsRepo;
            }
        }
        public ProductsRepo ProductsRepo
        {
            get
            {
                if (productsRepo == null) { productsRepo = new ProductsRepo(dbContext); }
                return productsRepo;
            }
        }
        public CustomersRepo CustomersRepo
        {
            get
            {
                if (customersRepo == null) { customersRepo = new CustomersRepo(dbContext); }
                return customersRepo;
            }
        }
        public async Task SaveData()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
   
}
