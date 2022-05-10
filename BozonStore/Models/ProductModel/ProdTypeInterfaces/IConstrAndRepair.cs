using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Common;

namespace BozonStore.Models.ProductModel.ProdTypeInterfaces
{
    [InterfaceNameAnnotation(Name:"Строительные материалы")]
    public interface IConstrAndRepair
    {
        public ConstrAndRepairType ConstrAndRepairType { get; }
    }
}
