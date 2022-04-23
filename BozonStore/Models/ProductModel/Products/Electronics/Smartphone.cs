using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Models.ProductModel.CommonClass;
using System.Linq;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace BozonStore.Models.ProductModel.Products.Electronics
{
    public class Smartphone : Product, IElectronics, IColor
    {
        public ElectronicType ElectronicType => ElectronicType.Smartphone;
        public Color Color { get; set; }

        public float Diagonal { get; set; }
        public int BatteryVolume { get; set; }
        public string BodyMaterialType { get; set; }
        [Column]
        private string _WirelessInterface;
        [NotMapped]
        public string[] WirelessInterface 
        {
            get => _WirelessInterface.Split(';');
            set 
            {
                var _data = value;
                _WirelessInterface = String.Join(';', _data.Select(p => p.ToString()).ToArray());
            }
        }
        public int VerticalResolution { get; set; }
        public int HorizontalResolution { get; set; }
        public int CoreCount { get; set; }
        public int RAMVolume { get; set; }
        public int EmbeddedMemoryVolume { get; set; }
        public string MemoryCardType { get; set; }
    }
}
