namespace IPTV.Big.Heart.Database.Models.Television
{
    using System.Collections.Generic;

    using Interfaces;

    public class TelevisionCategory : BaseModel
    {
        public TelevisionCategory()
        {
            this.Televisions = new HashSet<TelevisionCategoryMapping>();
        }

        public string Name { get; set; }

        public ICollection<TelevisionCategoryMapping> Televisions { get; set; }
    }
}
