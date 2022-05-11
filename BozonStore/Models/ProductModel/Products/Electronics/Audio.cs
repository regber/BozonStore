using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.Electronics
{
    [Display(Name ="Аудиотехника")]
    public class Audio : Product, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.Audio;

        public Color Color { get; set; }
    }
}
