using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Common;

namespace BozonStore.Models.ProductModel.ProdTypeInterfaces
{
    [InterfaceNameAnnotation(Name:"Строительство и ремонт")]
    public interface IConstrAndRepair
    {
        public ConstrAndRepairType ConstrAndRepairType { get; }
    }
}
