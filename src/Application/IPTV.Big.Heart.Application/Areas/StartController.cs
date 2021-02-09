namespace IPTV.Big.Heart.Application.Areas
{
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    [Route("[controller]")]
    public class StartController : BaseController
    {
        public StartController(IApiResult apiResult) 
            : base(apiResult)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string helloText = "The application is started successfully.";

            return Ok(helloText);
        }
    }
}
