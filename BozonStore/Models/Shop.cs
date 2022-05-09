using System.Collections.Generic;
using BozonStore.Models.ProductModel;
using BozonStore.Models.UserModel;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models
{
    public class Shop
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Название магазина")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Адрес магазина")]
        public string Address { get; set; }


        public int SellerId { get; set; }
        public Seller Seller { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
