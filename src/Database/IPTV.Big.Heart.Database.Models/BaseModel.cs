namespace IPTV.Big.Heart.Database.Models
{
    using System;

    using Interfaces;

    public abstract class BaseModel : IBaseModel
    {
        public DateTime? LastModifiedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
