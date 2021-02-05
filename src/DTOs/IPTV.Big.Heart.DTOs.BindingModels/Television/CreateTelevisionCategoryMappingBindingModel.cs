namespace IPTV.Big.Heart.DTOs.BindingModels.Television
{
    using System;

    public class CreateTelevisionCategoryMappingBindingModel
    {
        public CreateTelevisionCategoryMappingBindingModel(Guid televisionId, Guid categoryId)
        {
            this.TelevisionId = televisionId;
            this.CategoryId = categoryId;
        }

        public Guid TelevisionId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
