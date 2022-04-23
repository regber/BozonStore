using System.Collections.Generic;

namespace BozonStore.Models.CommonInterface
{
    interface ISeller<Shop>
    {
        public string Title { get; set; }

        public ICollection<Shop> Shops { get; set; }
    }
}
