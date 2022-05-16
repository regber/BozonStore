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

        [UIHint("Color")]
        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Встраиваемая")]
        public bool Embedded { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Класс энергопотребления")]
        public string EnergyConsumptionClass { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Ширина, мм")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Глубина, мм")]
        public int Depth { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Высота, мм")]
        public int Height { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Общий объем, л")]
        public int TotalVolume { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Размораживание")]
        public string DefrostingType { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Общий объем холодильной камеры, л")]
        public int CoolingVolume { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Общий объем морозильной камеры, л")]
        public int FreezerVolume { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Мощность замораживания (кг/сут)")]
        public int FreezingPower { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Вид компрессора")]
        public string CompressorType { get; set; }

    }
}
