using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Common.Constants;
using IPTV.Big.Heart.Application.Infrastructures;
using IPTV.Big.Heart.Application.Infrastructures.Filters;
using IPTV.Big.Heart.Application.Infrastructures.Helpers;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using IPTV.Big.Heart.Database.Models.Location;
using IPTV.Big.Heart.DTOs.BindingModels.Location.Create;
using IPTV.Big.Heart.DTOs.BindingModels.Location.Edit;
using IPTV.Big.Heart.DTOs.ViewModels.Location;
using IPTV.Big.Heart.Services.Database.Location.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPTV.Big.Heart.Application.Areas.Admin
{  
    public class CountriesController : BaseAdminController
    {
        private readonly ICountryService countryService;

        public CountriesController(IApiResult apiResult, ICountryService countryService) 
            : base(apiResult)
        {
            this.countryService = countryService;
        }

        [HttpPost("create")]
        [ValidateModelState]
        public async Task<IActionResult> Create(CreateCountryBindingModel model)
        {
            var country = await this.countryService.GetByName(model.Name);

            if (country != null)
            {
                this.ApiResult.Errors.Add("Country allready exist.");
                return BadRequest(this.ApiResult);
            }

            country = await this.countryService.CreateAsync(model);

            this.ApiResult.Data = country;

            return Ok(this.ApiResult);
        }

        [HttpPut("{countryId}")]
        [ValidateModelState]
        public async Task<IActionResult> Edit(string countryId, EditCountryBindingModel model)
        {
            var verifiedId = Verifier.CheckId(countryId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var country = await this.countryService.GetByIdAsync(verifiedId, false);

            if (country == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);
                return BadRequest(this.ApiResult);
            }

            country = await this.countryService.UpdateAsync(verifiedId, model);

            this.ApiResult.Data = country;

            return Ok(this.ApiResult);
        }

        [HttpPatch("{countryId}")]
        public async Task<IActionResult> Undelete(string countryId)
        {
            var verifiedId = Verifier.CheckId(countryId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var country = await this.countryService.GetByIdAsync(verifiedId);

            if (country == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);
                return BadRequest(this.ApiResult);
            }

            country = await this.countryService.UnDeleteAsync(verifiedId);

            this.ApiResult.Data = country;

            return Ok(this.ApiResult);
        }

        [HttpDelete("{countryId}")]
        public async Task<IActionResult> Delete(string countryId)
        {
            var verifiedId = Verifier.CheckId(countryId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var country = await this.countryService.GetByIdAsync(verifiedId, false);

            if (country == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);
                return BadRequest(this.ApiResult);
            }

            country = await this.countryService.DeleteAsync(verifiedId);

            this.ApiResult.Data = country;

            return Ok(this.ApiResult);
        }
    }
}
