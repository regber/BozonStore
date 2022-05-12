using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.Electronics
{
    [Display(Name ="Аудиотехника")]
    public class Audio : Product, IElectronics
    {
        [ScaffoldColumn(false)]
        public ElectronicType ElectronicType => ElectronicType.Audio;
    }
}
