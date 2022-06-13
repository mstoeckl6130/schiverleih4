namespace schiverleih4.Data.Models
{
    public class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Products> Products { get; set; }
        

    }
}
