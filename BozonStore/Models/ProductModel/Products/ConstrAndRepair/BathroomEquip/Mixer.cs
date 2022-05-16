using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip
{
    [Display(Name ="Смеситель")]
    public class Mixer : SanitaryWare, IColor
    {
        [UIHint("Color")]
        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name ="Назначение")]
        public string Purpose { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Установка")]
        public string Installation { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Особенности")]
        public string Features { get; set; }
    }
}
