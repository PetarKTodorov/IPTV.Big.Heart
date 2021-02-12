namespace IPTV.Big.Heart.DTOs.BindingModels.Television.Edit
{
    using System.ComponentModel.DataAnnotations;

    public class EditTelevisionBindingModel
    {
        [Required]
        public string Name { get; set; }
    }
}
