namespace IPTV.Big.Heart.Services.Mapper.Interfaces
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IProfileExpression configuration);
    }
}
