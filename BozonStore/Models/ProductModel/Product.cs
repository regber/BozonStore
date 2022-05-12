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
        public string Discription { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Цена товара", Order = -98)]
        public int Price { get; set; }


        public Image MainImage { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
