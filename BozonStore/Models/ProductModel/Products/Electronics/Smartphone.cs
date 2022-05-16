using BozonStore.Models.ProductModel.ProdTypeInterfaces;
using BozonStore.Models.ProductModel.ProdTypeEnums;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using BozonStore.Common;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace BozonStore.Models.ProductModel.Products.Electronics
{
    [Display(Name ="Смартфон")]
    public class Smartphone : Product, IElectronics, IColor
    {
        [ScaffoldColumn(false)]
        public ElectronicType ElectronicType => ElectronicType.Smartphone;


        [UIHint("Color")]
        [Display(Name = "Цвет")]
        public string Color { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Диагональ экрана, дюймы")]
        public float Diagonal { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Емкость аккумулятора, мАч")]
        public int BatteryVolume { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Материал корпуса")]
        public string BodyMaterialType { get; set; }


        [Column]
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Беспроводные интерфейсы")]
        private string _WirelessInterface { get; set; }
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


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Вертикальное разрешение, точек")]
        public int VerticalResolution { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Горизонтальное разрешение, точек")]
        public int HorizontalResolution { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Кол-во ядер, шт")]
        public int CoreCount { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Объем оперативной памяти, Гб")]
        public int RAMVolume { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Объем встраиваемой памяти, Гб")]
        public int EmbeddedMemoryVolume { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип карты памяти")]
        public string MemoryCardType { get; set; }
    }
}
