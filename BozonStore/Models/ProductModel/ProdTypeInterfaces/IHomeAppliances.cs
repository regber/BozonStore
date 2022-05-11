using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Common;

namespace BozonStore.Models.ProductModel.ProdTypeInterfaces
{
    [InterfaceDisplay(Name: "Бытовая техника")]
    public interface IHomeAppliances
    {
        public HomeApplianceType HomeApplianceType { get; }
    }
}
