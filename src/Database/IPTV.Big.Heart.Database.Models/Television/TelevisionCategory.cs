namespace IPTV.Big.Heart.Database.Models.Television
{
    using System.Collections.Generic;

    using Interfaces;

    public class TelevisionCategory : BaseModel, IDable<int>
    {
        public TelevisionCategory()
        {
            this.Televisions = new HashSet<TelevisionCategoryMapping>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TelevisionCategoryMapping> Televisions { get; set; }
    }
}
