using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BozonStore.Models.UserModel;

namespace BozonStore.ViewModels.Account
{
    public class RegisterViewModel
    {
        public PartialViewResult PartialView { get; set; }
        public User User { get; set; }
    }
}
