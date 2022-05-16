using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool
{
    [Display(Name ="УШМ")]
    public class AngleGrinder : Tool, IPower
    {
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Мощность")]
        public int Power { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Диаметр диска")]
        public int DiameterDisc { get; set; }
    }
}
