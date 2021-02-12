namespace IPTV.Big.Heart.Services.Database.Television
{
    using AutoMapper;

    using Interfaces;
    using IPTV.Big.Heart.Database.Repositories.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class TelevisionService : BaseDatabaseService<Television>, ITelevisionService
    {
        public TelevisionService(IRepository<Television> repositary, IMapper mapper) 
            : base(repositary, mapper)
        {

        }

        public IEnumerable<DTO> GetAllInformation<DTO>()
        {
            var televisionsFromDb = this.GetAll()
                .Where(television => television.IsDeleted == false)
                .Include(television => television.Streams)
                .ThenInclude(streams => streams.Stream)
                .Include(television => television.Categories)
                .ThenInclude(televisionCategory => televisionCategory.Category)
                .Include(television => television.Countries)
                .ThenInclude(televisionCountry => televisionCountry.Country)
                .ToArray();

            IEnumerable<DTO> collection = this.Mapper.Map<IEnumerable<DTO>>(televisionsFromDb);

            return collection;
        }

        public async Task<Television> GetByName(string televisionName)
        {
            var television = this.Repositary.GetAll().SingleOrDefault(country => country.Name == televisionName);

            return television;
        }
    }
}
