namespace IPTV.Big.Heart.Database.Models.Interfaces
{
    using System;

    internal interface IBaseModel : IDeletable
    {
        public DateTime? LastModifiedAt { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
