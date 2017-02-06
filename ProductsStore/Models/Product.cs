using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProductsStore.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        [RegularExpression(@"[A-Za-z0-9 ]+", ErrorMessage = "Please use only letters and digits")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a product description")]
        [RegularExpression(@"[A-Za-z0-9 ]+", ErrorMessage = "Please use only letters and digits")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a product price")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive price")]
        public int Price { get; set; }

        public DateTime CreationDate { get; set; }
    }
}