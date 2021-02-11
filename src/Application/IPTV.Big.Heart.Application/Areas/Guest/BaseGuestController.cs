using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Common.Constants;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPTV.Big.Heart.Application.Areas.Guest
{
    [Route(ApplicationConstants.GuestArea + "/[controller]")]
    public class BaseGuestController : BaseController
    {
        public BaseGuestController(IApiResult apiResult) 
            : base(apiResult)
        {
        }
    }
}
