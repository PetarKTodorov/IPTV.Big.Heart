using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Common.Constants;
using IPTV.Big.Heart.Application.Infrastructures.Filters;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using IPTV.Big.Heart.Services.Database.Location.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPTV.Big.Heart.Application.Areas.Admin
{  
    public class CountryController : BaseAdminController
    {
        private readonly ICountryService countryService;

        public CountryController(IApiResult apiResult, ICountryService countryService) 
            : base(apiResult)
        {
            this.countryService = countryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var countries = await this.countryService.GetAllAsync();

            this.ApiResult.Data = countries.ToArray();

            return Ok(this.ApiResult);
        }
    }
}
