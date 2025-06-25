using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_MVC.Models
{
    public class Product
    {
        public int Id { set; get; }
        [Required]
        [MaxLength(20)]
        [MinLength(5)]
        public string Name { set; get; }
       public string Description { set; get; }
        [Range(0,100000)]
        public decimal Price { set; get; }
        [Range(0,5)]
        public double Rate { set; get; }
        [Range(0,500)]
        public int Quantity { set; get; }

        public double Discount { set; get; }
      
        public string? Image { set; get; }

        public int CategoryId { set; get; }
        [ValidateNever]
        public Category Category { set; get; }
    }
}
