namespace IPTV.Big.Heart.DTOs.ViewModels.Television
{
    using System;
    using System.Collections.Generic;

    using IPTV.Big.Heart.DTOs.ViewModels.Location;

    public class GetAllTelevisionViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StreamViewModel> Streams { get; set; }

        public IEnumerable<TelevisionCategoryViewModel> Categoties { get; set; }

        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}
