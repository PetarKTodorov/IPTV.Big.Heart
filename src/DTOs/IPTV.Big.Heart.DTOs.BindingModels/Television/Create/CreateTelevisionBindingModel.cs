using System.ComponentModel.DataAnnotations;

namespace IPTV.Big.Heart.DTOs.BindingModels.Television.Create
{
    public class CreateTelevisionBindingModel
    {
        public CreateTelevisionBindingModel(string name)
        {
            this.Name = name;
        }

        [Required]
        public string Name { get; set; }
    }
}
