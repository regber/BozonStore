using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.Electronics
{
    public class Smartphone : BaseProduct, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.Smartphone;
        public Color Color { get; set; }

        public float Diagonal { get; set; }
        public int BatteryVolume { get; set; }
        public string BodyMaterialType { get; set; }
        public string[] WirelessInterface { get; set; }
        public int VerticalResolution { get; set; }
        public int HorizontalResolution { get; set; }
        public int CoreCount { get; set; }
        public int RAMVolume { get; set; }
        public int EmbeddedMemoryVolume { get; set; }
        public string MemoryCardType { get; set; }
    }
}
