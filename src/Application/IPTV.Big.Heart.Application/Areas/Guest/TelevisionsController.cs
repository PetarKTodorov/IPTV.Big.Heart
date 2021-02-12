namespace IPTV.Big.Heart.Application.Areas.Guest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using IPTV.Big.Heart.Application.Common.Constants;
    using IPTV.Big.Heart.Application.Infrastructures.Helpers;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
    using IPTV.Big.Heart.Database.Models.Television;
    using IPTV.Big.Heart.DTOs.ViewModels.Television;
    using IPTV.Big.Heart.Services.Database.Television.Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class TelevisionsController : BaseGuestController
    {
        private readonly ITelevisionService televisionService; 

        public TelevisionsController(IApiResult apiResult, ITelevisionService televisionService) 
            : base(apiResult)
        {
            this.televisionService = televisionService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var countries = this.televisionService.GetAllInformation<GetAllTelevisionViewModel>();

            this.ApiResult.Data = countries;

            return Ok(this.ApiResult);
        }

        [HttpGet("{televisionId}")]
        public async Task<IActionResult> GetById(string televisionId)
        {
            var verifiedId = Verifier.CheckId(televisionId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var country = await this.televisionService.GetByIdAsync<Guid>(verifiedId, false);

            if (country == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);

                return BadRequest(this.ApiResult);
            }

            this.ApiResult.Data = country;

            return Ok(this.ApiResult);
        }


    }
}
