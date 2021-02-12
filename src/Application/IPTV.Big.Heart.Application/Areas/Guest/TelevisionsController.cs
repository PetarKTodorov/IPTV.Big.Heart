using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.Application.Infrastructures.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPTV.Big.Heart.Application.Areas.Guest
{
    public class TelevisionsController : BaseGuestController
    {
        public TelevisionsController(IApiResult apiResult) 
            : base(apiResult)
        {

        }


    }
}
