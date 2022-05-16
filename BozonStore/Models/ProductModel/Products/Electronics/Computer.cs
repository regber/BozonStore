using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.Electronics
{
    [Display(Name ="Компьютер")]
    public class Computer : Product, IElectronics,IColor
    {
        [ScaffoldColumn(false)]
        public ElectronicType ElectronicType => ElectronicType.PC;

        [UIHint("Color")]
        [Display(Name = "Цвет")]
        public string Color { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Наименование процессора")]
        public string ProcessorName { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Частота процессора, ГГц")]
        public float Frequency { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Объем оперативной памяти, Гб")]
        public int RAMVolume { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип оперативной памяти")]
        public string RAMType { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Объем жесткого диска")]
        public int HardDriveSize { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Видеокарта")]
        public string VideoCard { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Операционная система")]
        public string OSType { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип видеокарты")]
        public string VideoCardType { get; set; }
    }
}
