using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models
{
    public class Buyer:User
    {
        public ICollection<Purchas> Purchases { get; set; }
    }
}
