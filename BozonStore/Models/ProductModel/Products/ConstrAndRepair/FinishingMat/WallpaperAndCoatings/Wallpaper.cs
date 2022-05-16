using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.FinishingMat.WallpaperAndCoatings
{
    [Display(Name ="Обои")]
    public class Wallpaper:BuildingMat
    {
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Артикул")]
        public string Article { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Вид обоев")]
        public string WallpaperType { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Длина, м")]
        public float Length { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Ширина, м")]
        public float Width { get; set; }
    }
}
