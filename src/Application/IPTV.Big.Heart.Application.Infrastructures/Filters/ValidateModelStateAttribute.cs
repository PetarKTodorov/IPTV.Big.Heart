using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IPTV.Big.Heart.Application.Infrastructures.Filters
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid == false)
            {
                IApiResult apiResult = new ApiResult();

                IEnumerable<ModelError> allErrors = context.ModelState.Values.SelectMany(e => e.Errors);
                foreach (var error in allErrors)
                {
                    apiResult.Errors.Add(error.ErrorMessage);
                }

                context.Result = new JsonResult(apiResult) { StatusCode = StatusCodes.Status400BadRequest };
                return;
            }
        }
    }
}
