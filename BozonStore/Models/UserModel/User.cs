using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BozonStore.Models.UserModel
{
    public class User
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Повтор пароля")]
        [Compare("Password", ErrorMessage = "Пароль введен не верно")]
        [NotMapped]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Имя пользователя")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Адрес электронной почты")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введеный адрес не соответствует формату почты")]
        public string Email { get; set; }


        [Display(Name = "Адрес")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string NumberPhone { get; set; }
    }
}
