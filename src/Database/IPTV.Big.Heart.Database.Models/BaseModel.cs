namespace IPTV.Big.Heart.Database.Models
{
    using System;

    using Interfaces;

    public abstract class BaseModel : IBaseModel
    {
        public DateTime? LastModifiedAt { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
