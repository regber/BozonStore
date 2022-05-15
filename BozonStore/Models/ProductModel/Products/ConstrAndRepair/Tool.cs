using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair
{
    [Display(Name = "Инструмент")]
    public class Tool : Product, IConstrAndRepair
    {
        [ScaffoldColumn(false)]
        public ConstrAndRepairType ConstrAndRepairType => ConstrAndRepairType.Tool;
    }
}
