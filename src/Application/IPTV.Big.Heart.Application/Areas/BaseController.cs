namespace IPTV.Big.Heart.Application.Areas
{
    using Microsoft.AspNetCore.Mvc;

    using IPTV.Big.Heart.Application.Infrastructures;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;

    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController(IApiResult apiResult)
        {
            this.ApiResult = apiResult;
        }

        public IApiResult ApiResult { get; set; }
    }
}
