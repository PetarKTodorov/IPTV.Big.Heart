namespace IPTV.Big.Heart.Application.Areas.Guest.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using System;

    using IPTV.Big.Heart.Application.Common.Constants;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
    using IPTV.Big.Heart.Services.Database.User.Interfaces;
    using IPTV.Big.Heart.DTOs.BindingModels.User;
    using IPTV.Big.Heart.Application.Infrastructures.Filters;

    public class UsersController : BaseGuestController
    {
        private readonly IUserService userService;

        public UsersController(IApiResult apiResult, IUserService userService) 
            : base(apiResult)
        {
            this.userService = userService;
        }

        [HttpPost("login")]
        [ValidateModelState]
        public async Task<IActionResult> Login(LoginBindingModel model)
        {
            var token = await userService.Login(model);

            if (token == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidLoginMessage);

                return BadRequest(this.ApiResult);
            }

            this.ApiResult.Data = token;

            return Ok(this.ApiResult);
        }

        [HttpPost("register")]
        [ValidateModelState]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            try
            {
                var message = await userService.Register(model);

                if (message == null)
                {
                    this.ApiResult.Errors.Add(ApplicationConstants.InvalidLoginMessage);

                    return BadRequest(this.ApiResult);
                }

                this.ApiResult.Data = message;

                return Ok(this.ApiResult);
            }
            catch (Exception e)
            {
                this.ApiResult.Errors.Add(e.Message);

                return BadRequest(this.ApiResult);
            }
            
        }


    }
}
