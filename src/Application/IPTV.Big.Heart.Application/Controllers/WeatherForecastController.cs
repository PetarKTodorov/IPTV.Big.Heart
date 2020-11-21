using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTV.Big.Heart.DTOs.BindingModels.Location;
using IPTV.Big.Heart.Services.Database.Location.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IPTV.Big.Heart.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ICountryService countryService;

        public WeatherForecastController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var createCountryBindingModel = new CreateCountryBindingModel { Name = "test" };

            //var country = await this.countryService.CreateAsync<CreateCountryBindingModel>(createCountryBindingModel);

            //return Ok(country);

            return Ok();
        }
    }
}
