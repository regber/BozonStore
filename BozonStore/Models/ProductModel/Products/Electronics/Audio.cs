using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;

namespace BozonStore.Models.ProductModel.Products.Electronics
{
    public class Audio : Product, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.Audio;

        public Color Color { get; set; }
    }
}
