using schiverleih4.Data.Models;
using schiverleih4.Data.VirtualModels;

namespace schiverleih4.Pages
{
    public partial class RentOverview
    {
        private List<RentsVM>rents=new List<RentsVM>();
        private void Navigate(string url)
        {
            navMan.NavigateTo(url, forceLoad:true);
        }
        protected async override Task OnInitializedAsync()
        {
            rents = await uow.RentsRepo.GetAllRents();
        }
    }
}
