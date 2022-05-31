using doccplus.Data.doccplus;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace doccplus.Data
{
    public class WeatherForecastService
    {
        private readonly doccplusContext _context;
        public WeatherForecastService(doccplusContext context)
        {
            _context = context;
        }
        public async Task<List<WeatherForecast>>
            GetForecastAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.WeatherForecast
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        public Task<WeatherForecast>
           CreateForecastAsync(WeatherForecast objWeatherForecast)
        {
            _context.WeatherForecast.Add(objWeatherForecast);
            _context.SaveChanges();
            return Task.FromResult(objWeatherForecast);
        }
    }
}