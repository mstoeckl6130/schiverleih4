using Microsoft.EntityFrameworkCore;
using schiverleih4.Data.Models;
using schiverleih4.Data.VirtualModels;

namespace schiverleih4.Data.Repos
{
    public class RentsRepo
    {
        ApplicationDbContext dbContext;
        
        public RentsRepo(ApplicationDbContext context)
        {
            dbContext = context;
        }
        //UnitOfWork uow = new UnitOfWork(dbContext);
        public async Task AddRent(RentsVM rentVM)
        {
            Rents rent = new Rents { CustomerId = rentVM.CustomerId, EmployeeId = rentVM.EmployeeId, GiveBack = 0, TimestampEnd = rentVM.TimestampEnd, TimestampStart = rentVM.TimestampStart, ProductId=rentVM.ProductId };
            await dbContext.AddAsync(rent);
            await SaveData();
        }
        public async Task GiveBack(int rentId)
        {
            Rents rent = await dbContext.Rents.FirstOrDefaultAsync(x => x.RentId == rentId);
            rent.GiveBack = 1;
            dbContext.Attach(rent);
            await SaveData();
        }
        public async Task DeleteRent(int rentId)
        {
            Rents rent = await dbContext.Rents.FirstOrDefaultAsync(x => x.RentId == rentId);
            dbContext.Remove(rent);
            await SaveData();
        }
        public RentsVM GetRentById(int RentId)
        {
            Rents rent= dbContext.Rents.FirstOrDefault(x => x.RentId == RentId);
            RentsVM rentVM = new RentsVM { CustomerId = rent.CustomerId, EmployeeId = rent.EmployeeId, ProductId = rent.ProductId, RentId = rent.RentId, TimestampEnd = rent.TimestampEnd, TimestampStart = rent.TimestampStart };
            return rentVM;
        }
        public async Task UpdateRent(RentsVM rentVM)
        {
            Rents rent = new Rents { EmployeeId = rentVM.EmployeeId, RentId = rentVM.RentId, GiveBack = 0, CustomerId = rentVM.CustomerId, TimestampEnd = rentVM.TimestampEnd, TimestampStart = rentVM.TimestampStart, ProductId = rentVM.ProductId };
            dbContext.Attach(rent);
            await SaveData();

        }
        public async Task<List<RentsVM>> GetAllRents()
        {
            if (dbContext.Rents.Any())  //checkt ob datensätze vorhanden
            {
                List<RentsVM> rentsVM = new List<RentsVM>();
                var rents = from r in dbContext.Rents
                            where r.GiveBack == 0
                            select new Rents
                            {
                                RentId = r.RentId,
                                ProductId = r.ProductId,
                                CustomerId = r.CustomerId,
                                TimestampEnd = r.TimestampEnd,
                                TimestampStart = r.TimestampStart,
                                EmployeeId = r.EmployeeId
                            };
                RentsVM rentVM;
                List<Customers> customers = new List<Customers>();
                List<Products> products = new List<Products>();
                CustomersRepo cRepo= new CustomersRepo(dbContext);
                ProductsRepo rRepo = new ProductsRepo(dbContext);
                
                products = await rRepo.GetProducts();
                customers = await cRepo.GetCustomers();
                foreach (Rents rent in rents)
                {
                    Customers customer=customers.FirstOrDefault(x => x.CustomerId == rent.CustomerId);
                    Employees employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == rent.EmployeeId);
                    Products product = products.FirstOrDefault(x => x.ProductNumber == rent.ProductId);
                    rentVM = new RentsVM { CustomerId = rent.CustomerId, EmployeeId = rent.EmployeeId, ProductTitle=product.ProductTitle, ProductId = rent.ProductId, RentId = rent.RentId, TimestampEnd = rent.TimestampEnd, TimestampStart = rent.TimestampStart, CustomerFirstName=customer.FirstName, CustomerLastName=customer.LastName };
                    rentsVM.Add(rentVM);
                }
                return rentsVM;
            }
            else
            {
                return null;
            }
        }
        public async Task SaveData()
        {
           // try
           // {
                await dbContext.SaveChangesAsync();
            // }
            //catch
            //{
            throw new DbUpdateException();
            // }

        }
        public void Error()
        {

        }
    }
}
