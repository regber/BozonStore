using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip
{
    public class Mixer : SanitaryWare, IColor
    {
        public Color Color { get; set; }
        public string Purpose { get; set; }
        public string Installation { get; set; }
        public string Features { get; set; }
    }
}
