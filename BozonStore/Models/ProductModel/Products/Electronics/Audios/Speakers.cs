using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BozonStore.Models.ProductModel.CommonClass;
using BozonStore.Models.ProductModel.ProdCommonInterfaces;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.Electronics.Audios
{
    [Display(Name ="Колонки")]
    public class Speakers : Audio, IColor
    {
        [UIHint("Color")]
        [Display(Name = "Цвет")]
        public string Color { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Тип")]
        public string Type { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Максимальная мощность, Вт")]
        public int MaxPower { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Питание колонок")]
        public string TypeOfPowerSupply { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Выходные интерфейсы")]
        public string EntriesInterfaces { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Конструктивные особенности")]
        public string DesignFeature { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Материал корпуса")]
        public string BodyMaterialType { get; set; }
    }
}
