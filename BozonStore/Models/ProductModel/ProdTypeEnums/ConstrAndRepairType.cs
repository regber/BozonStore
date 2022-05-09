using System.ComponentModel.DataAnnotations;

namespace BozonStore.Models.ProductModel.ProdTypeEnums
{
    
    public enum ConstrAndRepairType
    {
        [Display(Name = "Инструмент")]
        Tool,
        [Display(Name = "Строительные материалы")]
        BuildingMat,
        [Display(Name = "Сантехника")]
        SanitaryWare
    }
}
