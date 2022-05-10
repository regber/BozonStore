using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Common;

namespace BozonStore.Models.ProductModel.ProdTypeInterfaces
{
    [InterfaceNameAnnotation(Name: "Электроника")]
    public interface IElectronics
    {
        public ElectronicType ElectronicType { get; }

    }
}
