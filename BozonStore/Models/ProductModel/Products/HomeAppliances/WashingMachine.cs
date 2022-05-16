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
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Встраиваемая")]
        public bool Embedded { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Класс энергопотребления")]
        public string EnergyConsumptionClass { get; set; }

        [UIHint("Color")]
        [Display(Name = "Цвет")]
        public string Color { get; set; }

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
        [Display(Name = "Загрузка белья, кг")]
        public float Volume { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Максимальная скорость отжима, об./мин.")]
        public int SpinSpeed { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Класс стирки")]
        public string WashingClass { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Класс отжима")]
        public string SpinClass { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Наличие сушки")]
        public bool HaveDrying { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип управления")]
        public string ControlType { get; set; }
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Прямой привод")]
        public bool DirectDrive { get; set; }

    }
}
