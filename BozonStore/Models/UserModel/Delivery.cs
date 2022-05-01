using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.UserModel
{
    public class Delivery:User
    {
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Название доставщика")]
        public string Title { get; set; }
    }
}
