namespace E_Commerce_MVC.Models
{
    public class Category
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public List<Product> products{set;get;}
    }
}
