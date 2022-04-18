using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.Electronics
{
    public class PC : BaseProduct, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.PC;

        public Color Color { get; set; }

    }
}
