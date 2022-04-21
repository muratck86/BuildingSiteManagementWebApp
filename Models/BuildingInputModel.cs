using BuildingSiteManagementWebApp.Common.Constants;
using System.ComponentModel.DataAnnotations;

namespace BuildingSiteManagementWebApp.Models
{
    public class BuildingInputModel
    {
        [Required(ErrorMessage = TextsLang.IsRequired)]
        [Display(Name = TextsLang.Name)]
        public string Name { get; set; }
        [Required(ErrorMessage = TextsLang.IsRequired)]
        [Display(Name = TextsLang.NumberOfFloors)]
        public int NumberOfFloors { get; set; }
        [Required(ErrorMessage = TextsLang.IsRequired)]
        [Display(Name = TextsLang.NumberOfBasements)]
        public int Basements { get; set; }
        [Required(ErrorMessage = TextsLang.IsRequired)]
        [Display(Name = TextsLang.HasRoof)]
        public bool HasRoof { get; set; }
    }
}
