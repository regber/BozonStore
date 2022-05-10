using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Common;

namespace BozonStore.Models.ProductModel.ProdTypeInterfaces
{
    [InterfaceNameAnnotation(Name: "Бытовая техника")]
    public interface IHomeAppliances
    {
        public HomeApplianceType HomeApplianceType { get; }
    }
}
