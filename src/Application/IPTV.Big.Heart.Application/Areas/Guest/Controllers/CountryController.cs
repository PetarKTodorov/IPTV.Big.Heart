namespace IPTV.Big.Heart.Application.Areas.Guest.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    using IPTV.Big.Heart.Services.Database.Location.Interfaces;
    using IPTV.Big.Heart.Application.Common.Constants;
    using IPTV.Big.Heart.Application.Infrastructures;
    using System.Collections.Generic;
    using IPTV.Big.Heart.Application.Infrastructures.Helpers;
    using IPTV.Big.Heart.Application.Infrastructures.Interfaces;

    [Route(ApplicationConstants.GuestArea + "/[controller]")]
    public class CountryController : BaseController
    {
        private readonly ICountryService countryService;

        public CountryController(IApiResult apiResult, ICountryService countryService) 
            : base(apiResult)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countries = await this.countryService.GetAllAsync();

            this.ApiResult.Data = countries;

            return Ok(this.ApiResult);
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetById(string countryId)
        {
            var verifiedId = Verifier.Id(countryId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var country = await this.countryService.GetByIdAsync<Guid>(verifiedId);

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
