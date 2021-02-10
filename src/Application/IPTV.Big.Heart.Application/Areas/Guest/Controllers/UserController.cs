namespace IPTV.Big.Heart.Application.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using IPTV.Big.Heart.Application.Common.Constants;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;
    using IPTV.Big.Heart.DTOs.BindingModels.User;

    [Route(ApplicationConstants.GuestArea + "/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IApiResult apiResult, IUserService userService) 
            : base(apiResult)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            var token = userService.Login(model);

            if (token == null)
            {
                return BadRequest("Invalid email or password");
            }

            return Ok("Hi");
        }


    }
}
