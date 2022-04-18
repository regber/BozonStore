using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.ConstrAndRepair
{
    public class BuildingMat : BaseProduct, IConstrAndRepair
    {
        public ConstrAndRepairType ConstrAndRepairType => ConstrAndRepairType.BuildingMat;
    }
}
