using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace BozonStore.Models.ProductModel
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Название товара", Order =-100)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Описание товара", Order = -99)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Цена товара", Order = -98)]
        public int Price { get; set; }


        [UIHint("Images")]
        [Display(Name ="images", Order = -97)]
        public ICollection<Image> Images { get; set; }
    }
}
