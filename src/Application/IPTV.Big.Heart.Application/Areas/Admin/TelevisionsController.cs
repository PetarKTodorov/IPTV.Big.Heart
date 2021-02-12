using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Common.Constants;
using IPTV.Big.Heart.Application.Infrastructures.Filters;
using IPTV.Big.Heart.Application.Infrastructures.Helpers;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using IPTV.Big.Heart.DTOs.BindingModels.Television.Create;
using IPTV.Big.Heart.DTOs.BindingModels.Television.Edit;
using IPTV.Big.Heart.Services.Database.Television.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPTV.Big.Heart.Application.Areas.Admin
{
    public class TelevisionsController : BaseAdminController
    {
        private readonly ITelevisionService televisionService;
        public TelevisionsController(IApiResult apiResult, ITelevisionService televisionService) 
            : base(apiResult)
        {
            this.televisionService = televisionService;
        }

        [HttpPost("create")]
        [ValidateModelState]
        public async Task<IActionResult> Create(CreateTelevisionBindingModel model)
        {
            var television = await this.televisionService.GetByName(model.Name);

            if (television != null)
            {
                this.ApiResult.Errors.Add("Television allready exist.");
                return BadRequest(this.ApiResult);
            }

            television = await this.televisionService.CreateAsync(model);

            this.ApiResult.Data = television;

            return Ok(this.ApiResult);
        }

        [HttpPut("{televisionId}")]
        [ValidateModelState]
        public async Task<IActionResult> Edit(string televisionId, EditTelevisionBindingModel model)
        {
            var verifiedId = Verifier.CheckId(televisionId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var television = await this.televisionService.GetByIdAsync(verifiedId, false);

            if (television == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);
                return BadRequest(this.ApiResult);
            }

            television = await this.televisionService.UpdateAsync(verifiedId, model);

            this.ApiResult.Data = television;

            return Ok(this.ApiResult);
        }

        [HttpPatch("{televisionId}")]
        public async Task<IActionResult> Undelete(string televisionId)
        {
            var verifiedId = Verifier.CheckId(televisionId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var television = await this.televisionService.GetByIdAsync(verifiedId);

            if (television == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);
                return BadRequest(this.ApiResult);
            }

            television = await this.televisionService.UnDeleteAsync(verifiedId);

            this.ApiResult.Data = television;

            return Ok(this.ApiResult);
        }

        [HttpDelete("{televisionId}")]
        public async Task<IActionResult> Delete(string televisionId)
        {
            var verifiedId = Verifier.CheckId(televisionId, this.ApiResult.Errors);

            if (this.ApiResult.Errors.Count != 0)
            {
                return BadRequest(this.ApiResult);
            }

            var television = await this.televisionService.GetByIdAsync(verifiedId, false);

            if (television == null)
            {
                this.ApiResult.Errors.Add(ApplicationConstants.InvalidIdMessage);
                return BadRequest(this.ApiResult);
            }

            television = await this.televisionService.DeleteAsync(verifiedId);

            this.ApiResult.Data = television;

            return Ok(this.ApiResult);
        }
    }
}
