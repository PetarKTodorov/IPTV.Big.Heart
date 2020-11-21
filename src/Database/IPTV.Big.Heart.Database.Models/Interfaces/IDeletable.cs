namespace IPTV.Big.Heart.Database.Models.Interfaces
{
    using System;

    public interface IDeletable
    {
        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }
    }
}
