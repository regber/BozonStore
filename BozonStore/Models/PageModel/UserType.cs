using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.PageModel
{
    public enum UserType
    {
        [Display(Name = "Покупатель")]
        Buyer,
        [Display(Name = "Продавец")]
        Seller,
        [Display(Name = "Доставщик")]
        Delivery
    }
}
