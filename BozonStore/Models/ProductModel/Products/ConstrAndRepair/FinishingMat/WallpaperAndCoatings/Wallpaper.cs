using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings
{
    [Display(Name ="Обои")]
    public class Wallpaper:BuildingMat
    {
        [Display(Name = "Артикул")]
        public string Article { get; set; }


        [Display(Name = "Вид обоев")]
        public string WallpaperType { get; set; }


        [Display(Name = "Длина, м")]
        public float Length { get; set; }


        [Display(Name = "Ширина, м")]
        public float Width { get; set; }
    }
}
