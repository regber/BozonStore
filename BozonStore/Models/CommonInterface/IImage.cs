using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BozonStore.Models.CommonInterface
{
    interface IImage
    {
        public int Id { get; set; }
        public Uri Uri { get; set; }
    }
}
