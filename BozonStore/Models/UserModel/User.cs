using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BozonStore.Common;

namespace BozonStore.Models.UserModel
{
    [System.Serializable]
    public class User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }


        [Required(ErrorMessage = "Поле не заполнено")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Поле не заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = StrToHashStr.Hash(value);
            }
        }
        private string _Password;


        [Required(ErrorMessage = "Поле не заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Повтор пароля")]
        [Compare("Password", ErrorMessage = "Пароль введен не верно")]
        [NotMapped]
        public string ConfirmPassword 
        {
            get
            {
                return _ConfirmPassword;
            }
            set
            {
                _ConfirmPassword= StrToHashStr.Hash(value);
            }
        }
        private string _ConfirmPassword;


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
