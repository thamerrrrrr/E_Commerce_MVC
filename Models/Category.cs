using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_MVC.Models
{
    public class Category
    {
        public int Id { set; get; }
        [MaxLength(20)]
        public string Name { set; get; }

        [ValidateNever]
        public List<Product> products{set;get;}
    }
}
