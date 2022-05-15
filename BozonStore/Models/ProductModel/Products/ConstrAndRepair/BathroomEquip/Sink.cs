using System.ComponentModel.DataAnnotations;


namespace BozonStore.Models.ProductModel.Products.ConstrAndRepair.BathroomEquip
{
    [Display(Name ="Раковина")]
    public class Sink:SanitaryWare
    {
        [Display(Name = "Ширина")]
        public int Width { get; set; }


        [Display(Name = "Установка")]
        public string Installation { get; set; }


        [Display(Name = "Материал")]
        public string Material { get; set; }

        [Display(Name = "Число чаш")]
        public int CupCount { get; set; }
    }
}
