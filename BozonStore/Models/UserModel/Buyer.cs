using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models.UserModel
{
    [Serializable]
    public class Buyer:User
    {
        public ICollection<Purchase> Purchases { get; set; }
    }
}
