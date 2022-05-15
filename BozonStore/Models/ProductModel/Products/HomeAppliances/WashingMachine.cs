using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.HomeAppliances
{
    [Display(Name="Стиральная машина")]
    public class WashingMachine : Product, IHomeAppliances,IColor, IEmbedded,IEnergyClass,ISize
    {
        [ScaffoldColumn(false)]
        public HomeApplianceType HomeApplianceType => HomeApplianceType.WashingMachine;

        [Display(Name = "Встраиваемая")]
        public bool Embedded { get; set; }
        [Display(Name = "Класс энергопотребления")]
        public string EnergyConsumptionClass { get; set; }
        public Color Color { get; set; }


        [Display(Name = "Ширина, мм")]
        public int Width { get; set; }
        [Display(Name = "Глубина, мм")]
        public int Depth { get; set; }
        [Display(Name = "Высота, мм")]
        public int Height { get; set; }


        [Display(Name = "Загрузка белья, кг")]
        public float Volume { get; set; }
        [Display(Name = "Максимальная скорость отжима, об./мин.")]
        public int SpinSpeed { get; set; }
        [Display(Name = "Класс стирки")]
        public string WashingClass { get; set; }
        [Display(Name = "Класс отжима")]
        public string SpinClass { get; set; }
        [Display(Name = "Наличие сушки")]
        public bool HaveDrying { get; set; }
        [Display(Name = "Тип управления")]
        public string ControlType { get; set; }
        [Display(Name = "Прямой привод")]
        public bool DirectDrive { get; set; }

    }
}
