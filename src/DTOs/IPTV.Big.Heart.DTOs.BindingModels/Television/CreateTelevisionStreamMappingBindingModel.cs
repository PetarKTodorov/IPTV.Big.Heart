namespace IPTV.Big.Heart.DTOs.BindingModels.Television
{
    using System;

    public class CreateTelevisionStreamMappingBindingModel
    {
        public CreateTelevisionStreamMappingBindingModel(Guid televisionId, Guid streamId)
        {
            this.TelevisionId = televisionId;
            this.StreamId = streamId;
        }

        public Guid TelevisionId { get; set; }

        public Guid StreamId { get; set; }
    }
}
