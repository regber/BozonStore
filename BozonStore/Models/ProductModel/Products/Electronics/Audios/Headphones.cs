using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models.ProductModel.CommonClass;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.Electronics.Audios
{
    [Display(Name = "Наушники")]
    public class Headphones : Audio, IColor
    {
        public Color Color { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Наличие микрофона")]
        public bool MicroAvailable { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Конструкция наушников")]
        public string Design { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Шумоподавление")]
        public bool NoiseReduction { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Мин. частота, Гц")]
        public int MinFrequency { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Макс. частота, Гц")]
        public int MaxFrequency { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Сопротивление, Ом")]
        public int Resistance { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Управление наушниками")]
        public string ControlType { get; set; }

    }
}
