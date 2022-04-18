using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.Electronics
{
    public class TV : BaseProduct, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.TV;
        public Color Color { get; set; }
    }
}
