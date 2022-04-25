using System;
using BozonStore.Models.CommonInterface;

namespace BozonStore.Models
{
    public class Image:IImage
    {
        public int Id { get; set; }
        public Uri Uri { get; set; }
    }
}
