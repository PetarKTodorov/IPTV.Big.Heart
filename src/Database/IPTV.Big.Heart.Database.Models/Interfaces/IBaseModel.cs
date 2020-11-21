namespace IPTV.Big.Heart.Database.Models.Interfaces
{
    using System;

    public interface IBaseModel : IDeletable
    {
        public DateTime? LastModifiedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
