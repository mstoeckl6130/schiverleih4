namespace schiverleih4.Data.Components
{
    public partial class UnableToSaveData
    {
        private void reloadPage()
        {
            navMan.NavigateTo(navMan.Uri, forceLoad: true);
        }
    }
}
