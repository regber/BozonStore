using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.Electronics
{
    [Display(Name ="Телевизор")]
    public class Television : Product, IElectronics,IColor
    {

        [ScaffoldColumn(false)]
        public ElectronicType ElectronicType => ElectronicType.TV;


        public Color Color { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Диагональ, дюймы")]
        public int Diagonal { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Вертикальное разрешение, точек")]
        public int VerticalResolution { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Горизонтальное разрешение, точек")]
        public int HorizontalResolution { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Поддержка FullHD")]
        public bool FullHD { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Поддержка HD")]
        public bool HD { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Поддержка SmartTV")]
        public bool SmartTV { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип подсветки")]
        public string LightingType { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Беспроводные интерфейсы")]
        public string WirelessInterface { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Частота кадров, Гц")]
        public int Frequency { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Кол-во портов HDMI")]
        public int CountHDMI { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Настенное крепление(VESA)")]
        public string BracingType { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип матрицы")]
        public string MatrixType { get; set; }
    }
}
