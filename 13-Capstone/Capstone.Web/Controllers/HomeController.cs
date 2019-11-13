using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {

        //private const string FiveDayKey = "fiveDayForecaseValue";
        //private const string LowKey = "low";
        //private const string HighKey = "high";
        //private const string ForecastKey = "forecast";
        //protected IWeatherDao weatherDao; 

        //public void GetWeather(string id)
        //{
        //    HttpContext.Session.Set(FiveDayKey, 1);


        //}

   
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
