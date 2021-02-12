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
    using System.Linq;
    using IPTV.Big.Heart.DTOs.ViewModels.Location;

    public class CountriesController : BaseGuestController
    {
        private readonly ICountryService countryService;

        public CountriesController(IApiResult apiResult, ICountryService countryService) 
            : base(apiResult)
        {
            this.countryService = countryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await this.countryService.GetAllAsync<CountryViewModel>(false);

            this.ApiResult.Data = countries.ToArray();

            return Ok(this.ApiResult);
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetById(string countryId)
        {
            var verifiedId = Verifier.CheckId(countryId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var country = await this.countryService.GetByIdAsync<Guid>(verifiedId, false);

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
