namespace IPTV.Big.Heart.Application.Infrastructures.Interfaces
{
    using System.Collections.Generic;

    public interface IApiResult
    {
        public dynamic Data { get; set; }

        public ICollection<string> Errors { get; set; }
    }
}
