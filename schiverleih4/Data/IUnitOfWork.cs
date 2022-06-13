using schiverleih4.Data.Repos;

namespace schiverleih4.Data
{
    public interface IUnitOfWork
    {
        
        public RentsRepo RentsRepo { get; }
        public CustomersRepo CustomersRepo { get; }
        public ProductsRepo ProductsRepo { get; }
    }
}
