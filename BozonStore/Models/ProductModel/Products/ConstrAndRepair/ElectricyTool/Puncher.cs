using BozonStore.Models.ProductModel.ProdCommonInterfaces;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.ElectricyTool
{
    public class Puncher : Tool, IPower
    {
        public int Power { get; set; }
        public string HolderType { get; set; }
        public int SpeedCount { get; set; }
        public int Turnovers { get; set; }
    }
}
