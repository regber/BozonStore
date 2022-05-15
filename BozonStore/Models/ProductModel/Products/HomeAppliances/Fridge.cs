using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.HomeAppliances
{
    [Display(Name ="Холодильник")]
    public class Fridge : Product, IHomeAppliances,IColor,IEmbedded,IEnergyClass, ISize
    {
        [ScaffoldColumn(false)]
        public HomeApplianceType HomeApplianceType  => HomeApplianceType.Fridge;


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

        [Display(Name = "Общий объем, л")]
        public int TotalVolume { get; set; }
        [Display(Name = "Размораживание")]
        public string DefrostingType { get; set; }
        [Display(Name = "Общий объем холодильной камеры, л")]
        public int CoolingVolume { get; set; }
        [Display(Name = "Общий объем морозильной камеры, л")]
        public int FreezerVolume { get; set; }
        [Display(Name = "Мощность замораживания (кг/сут)")]
        public int FreezingPower { get; set; }
        [Display(Name = "Вид компрессора")]
        public string CompressorType { get; set; }

    }
}
