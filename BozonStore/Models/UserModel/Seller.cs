using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BozonStore.Models.UserModel
{
    public class Seller : User
    {
        [Required]
        [Display( Name ="Название компании")]
        public string Title { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
