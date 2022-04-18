using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models.ProductModel.Product.ConstrAndRepair.FinishingMat.WallpaperAndCoatings
{
    public class WallPanel:BuildingMat
    {
        public int Count { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Thickness { get; set; }
    }
}
