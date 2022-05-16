using System.ComponentModel.DataAnnotations;


namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip
{
    [Display(Name ="Раковина")]
    public class Sink:SanitaryWare
    {
        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Ширина")]
        public int Width { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Установка")]
        public string Installation { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Материал")]
        public string Material { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Число чаш")]
        public int CupCount { get; set; }
    }
}
