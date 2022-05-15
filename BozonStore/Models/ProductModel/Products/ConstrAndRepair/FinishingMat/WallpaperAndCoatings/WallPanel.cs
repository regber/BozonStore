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
        [Display(Name = "Количество")]
        public int Count { get; set; }


        [Display(Name = "Длина, мм")]
        public int Length { get; set; }


        [Display(Name = "Ширина, мм")]
        public int Width { get; set; }


        [Display(Name = "Толщина, мм")]
        public int Thickness { get; set; }
    }
}
