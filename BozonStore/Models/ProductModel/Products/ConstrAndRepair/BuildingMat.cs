using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair
{
    [Display(Name = "Строительные материалы")]
    public class BuildingMat : Product, IConstrAndRepair
    {
        [ScaffoldColumn(false)]
        public ConstrAndRepairType ConstrAndRepairType => ConstrAndRepairType.BuildingMat;
    }
}
