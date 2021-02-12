using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IPTV.Big.Heart.Application.Infrastructures.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IApiResult apiResult;

        public ExceptionMiddleware(RequestDelegate next, IApiResult apiResult)
        {
            this.apiResult = apiResult;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (DbUpdateException due)
            {
                await HandleExceptionAsync(httpContext, due.InnerException.Message);
            }
            //catch (Exception e)
            //{
            //    await HandleExceptionAsync(httpContext, "Something went wrong!");
            //}
        }

        private Task HandleExceptionAsync(HttpContext context, string exceptionMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            this.apiResult.Errors.Add(exceptionMessage);

            var jsonResult = new JsonResult(apiResult);
            var jsonAsString = JsonConvert.SerializeObject(jsonResult.Value, Formatting.Indented);

            return context.Response.WriteAsync(jsonAsString);
        }
    }
}
