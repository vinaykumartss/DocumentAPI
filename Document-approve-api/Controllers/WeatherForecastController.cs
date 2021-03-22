using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Document.Approve.Domain.Entities;
using Document.Approve.Infrastructure.Configuration.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Document_approve_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IGenericRepository<User> _user;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,  IGenericRepository<User> user)
        {
            _logger = logger;
            _user = user;
        }

        [HttpGet]
        public async Task<int> Get()
        {
            try
            {
                User userIn = new User()
                {
                   
                  
                  
                };
                await _user.AddAsync(userIn);
                return 1;

            } catch(Exception ex)
            {
                return 0;
            }

           
        }
    }
}
