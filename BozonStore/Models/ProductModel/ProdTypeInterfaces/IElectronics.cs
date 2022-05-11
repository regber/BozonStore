using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Common;

namespace BozonStore.Models.ProductModel.ProdTypeInterfaces
{
    [InterfaceDisplay(Name: "Электроника")]
    public interface IElectronics
    {
        public ElectronicType ElectronicType { get; }

    }
}
