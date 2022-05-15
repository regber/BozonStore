using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip
{
    [Display(Name ="Смеситель")]
    public class Mixer : SanitaryWare, IColor
    {

        public Color Color { get; set; }


        [Display(Name ="Назначение")]
        public string Purpose { get; set; }


        [Display(Name = "Установка")]
        public string Installation { get; set; }


        [Display(Name = "Особенности")]
        public string Features { get; set; }
    }
}
