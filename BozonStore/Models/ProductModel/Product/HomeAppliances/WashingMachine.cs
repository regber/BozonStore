using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.HomeAppliances
{
    public class WashingMachine : BaseProduct, IHomeAppliances,IColor, IEmbedded,IEnergyClass,ISize
    {
        public HomeApplianceType HomeApplianceType => HomeApplianceType.WashingMachine;


        public Color Color { get; set; }
        public bool Embedded { get; set; }
        public string EnergyConsumptionClass { get; set; }


        public int Width { get; set; }
        public int Depth { get; set; }
        public int Height { get; set; }


        public float Volume { get; set; }
        public int SpinSpeed { get; set; }
        public string WashingClass { get; set; }
        public string SpinClass { get; set; }
        public bool HaveDrying { get; set; }
        public string ControlType { get; set; }





    }
}
