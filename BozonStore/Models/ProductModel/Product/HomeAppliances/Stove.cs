using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;

namespace BozonStore.Models.ProductModel.Product.HomeAppliances
{
    public class Stove : BaseProduct, IHomeAppliances,IColor,IEmbedded,IEnergyClass,ISize
    {
        public HomeApplianceType HomeApplianceType => HomeApplianceType.Stove;


        public Color Color { get; set; }
        public bool Embedded { get; set; }
        public string EnergyConsumptionClass { get; set; }


        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }


        public string BurnersType { get; set; }
        public string OvenType { get; set; }
        public int OvenVolume { get; set; }
        public string ControlType { get; set; }


    }
}
