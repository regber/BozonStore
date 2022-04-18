using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.ConstrAndRepair.BathroomEquip
{
    public class Mixer : SanitaryWare, IColor
    {
        public Color Color { get; set; }
        public string Purpose { get; set; }
        public string Installation { get; set; }
        public string Features { get; set; }
    }
}
