using System.ComponentModel.DataAnnotations;

namespace IPTV.Big.Heart.DTOs.BindingModels.Location.Create
{
    public class CreateCountryBindingModel
    {
        public CreateCountryBindingModel()
        {

        }

        public CreateCountryBindingModel(string name)
        {
            this.Name = name;
        }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
    }
}
