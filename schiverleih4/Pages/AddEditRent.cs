using Microsoft.AspNetCore.Components;
using schiverleih4.Data.Models;
using schiverleih4.Data.VirtualModels;
using System.Security.Claims;

namespace schiverleih4.Pages
{
    public partial class AddEditRent
    {
        [Parameter]
        public string rentId { get; set; }
        private RentsVM rent = new RentsVM();
        private List<Customers> customers = new List<Customers>();
        private List<Products> products = new List<Products>();
        private int productId;
        private int customerId;
        protected async override Task OnInitializedAsync()
        {
            if(rentId!=null)
            {
                try
                {
                    rent = uow.RentsRepo.GetRentById(Int32.Parse(rentId));
                }
                catch
                {
                    throw new ArgumentException();
                }
            }
            customers = await uow.CustomersRepo.GetCustomers();
            products = await uow.ProductsRepo.GetProducts();
            productId = products.First().ProductNumber;
            customerId = customers.First().CustomerId;
            
        }
        private async Task SaveData()
        {
            rent.ProductId = productId;
            rent.CustomerId = customerId;
            rent.EmployeeId = accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if(rentId==null)
            {
                await uow.RentsRepo.AddRent(rent);
            }
        }
    }
}
