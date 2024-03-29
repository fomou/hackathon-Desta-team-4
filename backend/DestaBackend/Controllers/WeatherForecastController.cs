﻿using log4net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DestaNationConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        //Logger
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WeatherForecastController));

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [EnableCors] //api/WeatherForecast/get
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

            var pass1 = passwordHasher.HashPassword("desta",  "Desta-team4");
            var pass2 = passwordHasher.HashPassword("desta1", "Desta-team4-user1");
            var pass3 = passwordHasher.HashPassword("desta2", "Desta-team4-user2");

            Logger.InfoFormat($"desta user logs with  {pass1}");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
