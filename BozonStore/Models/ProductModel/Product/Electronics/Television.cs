using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;

namespace BozonStore.Models.ProductModel.Product.Electronics
{
    public class Television : BaseProduct, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.TV;
        public Color Color { get; set; }

        public int Diagonal { get; set; }
        public int VerticalResolution { get; set; }
        public int HorizontalResolution { get; set; }
        public bool FullHD { get; set; }
        public bool HD { get; set; }
        public bool SmartTV { get; set; }
        public string LightingType { get; set; }
        public string WirelessInterface { get; set; }
        public int Frequency { get; set; }
        public int CountHDMI { get; set; }
        public string BracingType { get; set; }
        public string MatrixType { get; set; }
    }
}
