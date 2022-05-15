using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.HomeAppliances
{
    [Display(Name="Печь")]
    public class Stove : Product, IHomeAppliances,IColor,IEmbedded,IEnergyClass,ISize
    {
        [ScaffoldColumn(false)]
        public HomeApplianceType HomeApplianceType => HomeApplianceType.Stove;


        public Color Color { get; set; }
        [Display(Name = "Встраиваемая")]
        public bool Embedded { get; set; }
        [Display(Name = "Класс энергопотребления")]
        public string EnergyConsumptionClass { get; set; }


        [Display(Name = "Ширина, мм")]
        public int Width { get; set; }
        [Display(Name = "Глубина, мм")]
        public int Depth { get; set; }
        [Display(Name = "Высота, мм")]
        public int Height { get; set; }


        [Display(Name = "Тип конфорок")]
        public string BurnersType { get; set; }
        [Display(Name = "Тип духовки")]
        public string OvenType { get; set; }
        [Display(Name = "Объем духовки, л")]
        public int OvenVolume { get; set; }
        [Display(Name = "Тип управления")]
        public string ControlType { get; set; }


    }
}
