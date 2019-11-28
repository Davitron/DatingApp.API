using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.Api.Controllers {
  [Authorize]
  [ApiController]
  [Route ("[controller]")]
  public class WeatherForecastController : ControllerBase {
    private static readonly string[] Summaries = new [] {
      "Freezing",
      "Bracing",
      "Chilly",
      "Cool",
      "Mild",
      "Warm",
      "Balmy",
      "Hot",
      "Sweltering",
      "Scorching"
    };

    private readonly DataContext _context;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController (ILogger<WeatherForecastController> logger, DataContext context) {
      _logger = logger;
      _context = context; 
    }

    [HttpGet]
    public async Task<IActionResult> GetWeathers() {
        var weathers = await _context.Weathers.ToListAsync();
        return Ok(weathers);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeather(int id) {
        var weather = await _context.Weathers.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(weather);
    }
  }

//     [HttpGet]
//     public IEnumerable<WeatherForecast> Get () {
//       var rng = new Random ();
//       return Enumerable.Range (1, 5).Select (index => new WeatherForecast {
//           Date = DateTime.Now.AddDays (index),
//             TemperatureC = rng.Next (-20, 55),
//             Summary = Summaries[rng.Next (Summaries.Length)]
//         })
//         .ToArray ();
//     }
//   }
}