using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool
{
    [Display(Name ="Перфоратор")]
    public class Puncher : Tool, IPower
    {
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Мощность")]
        public int Power { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]

        [Display(Name = "Тип патрона")]
        public string HolderType { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Количество скоростей")]
        public int SpeedCount { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Скорость, об./мин")]
        public int Turnovers { get; set; }
    }
}
