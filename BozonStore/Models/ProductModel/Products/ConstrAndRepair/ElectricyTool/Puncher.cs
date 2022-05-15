using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool
{
    [Display(Name ="Перфоратор")]
    public class Puncher : Tool, IPower
    {
        [Display(Name = "Мощность")]
        public int Power { get; set; }


        [Display(Name = "Тип патрона")]
        public string HolderType { get; set; }


        [Display(Name = "Количество скоростей")]
        public int SpeedCount { get; set; }


        [Display(Name = "Скорость, об./мин")]
        public int Turnovers { get; set; }
    }
}
