﻿using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.Drawing;

namespace BozonStore.Models.ProductModel.Product.Electronics
{
    public class PC : BaseProduct, IElectronics,IColor
    {
        public ElectronicType ElectronicType => ElectronicType.PC;

        public Color Color { get; set; }

        public string ProcessorName { get; set; }
        public float Frequency { get; set; }
        public int RAMVolume { get; set; }
        public string RAMType { get; set; }
        public int HardDriveSize { get; set; }
        public string VideoCard { get; set; }
        public string OSType { get; set; }
        public string VideoCardType { get; set; }
    }
}
