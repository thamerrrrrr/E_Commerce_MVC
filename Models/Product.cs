namespace E_Commerce_MVC.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
       public string Description { set; get; }
        public decimal Price { set; get; }
        public double Rate { set; get; }

        public int Quantity { set; get; }

        public double Discount { set; get; }
        public string Image { set; get; }

        public int CategoryId { set; get; }
        public Category Category { set; get; }
    }
}
