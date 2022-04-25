using BozonStore.Models.CommonInterface;
using System;

namespace BozonStore.Models.PurchaseModel
{
    public class PurchaseImage : IImage
    {
        public int Id { get; set; }
        public Uri Uri { get; set; }
    }
}
