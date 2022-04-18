using BozonStore.Models.ProductModel.ProdCommonInterfaces;

namespace BozonStore.Models.ProductModel.Product.ConstrAndRepair.ElectricyTool
{
    public class AngleGrinder : Tool, IPower
    {
        public int Power { get; set; }

        public int DiameterDisc { get; set; }
    }
}
