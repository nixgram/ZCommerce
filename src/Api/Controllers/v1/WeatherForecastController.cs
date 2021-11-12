using System;
using System.Collections.Generic;
using System.Linq;
using Api.Controllers.Common;
using Application.Common.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers.v1
{
    [AllowAnonymous]
    public class WeatherForecastController : ApiBaseController
    {
        private readonly IIdentityService _identityService;
        private readonly ICurrentUserService _currentUserService;

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IIdentityService identityService,
            ICurrentUserService currentUserService)
        {
            _logger = logger;
            _identityService = identityService;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            /*if (await _identityService.IsInRoleAsync(_currentUserService.UserId, Role.Admin))
            {
                return null;
            }*/

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}