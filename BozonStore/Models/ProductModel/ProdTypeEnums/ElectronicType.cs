using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.ProdTypeEnums
{
    public enum ElectronicType
    {
        [Display(Name ="Телевизор")]
        TV,
        [Display(Name = "Смартфон")]
        Smartphone,
        [Display(Name = "Компьютер")]
        PC,
        [Display(Name = "Аудиотехника")]
        Audio
    }
}
