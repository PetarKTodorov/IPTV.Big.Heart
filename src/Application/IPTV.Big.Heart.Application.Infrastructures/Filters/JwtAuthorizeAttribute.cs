namespace IPTV.Big.Heart.Application.Infrastructures.Filters
{
    using IPTV.Big.Heart.Database.Models.User;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Linq;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JwtAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            bool isInRole = false;

            for (int index = 0; index < this.Roles.Length; index++)
            {
                string role = this.Roles[index];

                isInRole = user.Roles.Any(x => x.Role.Name == role);

                if (isInRole)
                {
                    break;
                }
            }

            if (isInRole == false)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

        public string[] Roles { get; set; }
    }
}
