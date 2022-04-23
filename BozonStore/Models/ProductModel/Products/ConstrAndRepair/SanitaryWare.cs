using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair
{
    public class SanitaryWare : Product, IConstrAndRepair
    {
        public ConstrAndRepairType ConstrAndRepairType => ConstrAndRepairType.SanitaryWare;
    }
}
