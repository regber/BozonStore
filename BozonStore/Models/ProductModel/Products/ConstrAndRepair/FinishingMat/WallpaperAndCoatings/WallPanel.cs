using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings
{
    [Display(Name ="Стенная панель")]
    public class WallPanel:BuildingMat
    {
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Количество")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Длина, мм")]
        public int Length { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Ширина, мм")]
        public int Width { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Толщина, мм")]
        public int Thickness { get; set; }
    }
}
