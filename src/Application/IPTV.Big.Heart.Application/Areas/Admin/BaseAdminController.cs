using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Common.Constants;
using IPTV.Big.Heart.Application.Infrastructures.Filters;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using IPTV.Big.Heart.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPTV.Big.Heart.Application.Areas.Admin
{
    [Route(ApplicationConstants.AdminArea + "/[controller]")]
    [JwtAuthorize(Roles = new string[] { GlobalConstants.AdminRole })]
    public abstract class BaseAdminController : BaseController
    {
        public BaseAdminController(IApiResult apiResult) 
            : base(apiResult)
        {
        }
    }
}
