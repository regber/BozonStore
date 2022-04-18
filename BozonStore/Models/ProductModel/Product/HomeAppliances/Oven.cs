using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.HomeAppliances
{
    public class Oven : BaseProduct, IHomeAppliances,IColor,IEmbedded,IEnergyClass,ISize
    {
        public HomeApplianceType HomeApplianceType => HomeApplianceType.Oven;


        public Color Color { get; set; }
        public bool Embedded { get; set; }
        public string EnergyConsumptionClass { get; set; }


        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }

    }
}
