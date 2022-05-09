using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.ProdTypeEnums
{
    public enum HomeApplianceType
    {
        [Display(Name ="Холодильник")]
        Fridge,
        [Display(Name = "Печка")]
        Stove,
        [Display(Name = "Стиральная машина")]
        WashingMachine
    }
}
