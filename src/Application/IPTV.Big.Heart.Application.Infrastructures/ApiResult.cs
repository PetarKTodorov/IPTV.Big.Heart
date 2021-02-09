namespace IPTV.Big.Heart.Application.Infrastructures
{
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;

    using System.Collections.Generic;

    public class ApiResult : IApiResult
    {
        public ApiResult()
        {
            this.Errors = new HashSet<string>();
        }

        public dynamic Data { get; set; }

        public ICollection<string> Errors { get; set; }
    }
}
