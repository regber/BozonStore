using System.ComponentModel.DataAnnotations;

namespace BozonStore.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Не указан логин")]
        [Display(Name ="Логин")]
        public string Login { get; set; }


        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
