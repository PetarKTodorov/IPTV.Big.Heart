namespace IPTV.Big.Heart.DTOs.BindingModels.Location.Edit
{
    using System.ComponentModel.DataAnnotations;

    public class EditCountryBindingModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
