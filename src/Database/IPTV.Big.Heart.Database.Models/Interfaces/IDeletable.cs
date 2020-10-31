namespace IPTV.Big.Heart.Database.Models.Interfaces
{
    using System;

    public interface IDeletable
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
