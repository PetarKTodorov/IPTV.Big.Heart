namespace IPTV.Big.Heart.Application.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using IPTV.Big.Heart.Application.Common.Constants;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;
    using IPTV.Big.Heart.DTOs.BindingModels.User;

    public class UserController : BaseGuestController
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
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidLoginMessage);

                return BadRequest(this.ApiResult);
            }

            this.ApiResult.Data = token;

            return Ok(this.ApiResult);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            var message = userService.Register(model);

            if (message == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidLoginMessage);

                return BadRequest(this.ApiResult);
            }

            this.ApiResult.Data = message;

            return Ok(this.ApiResult);
        }


    }
}
