using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Extensions;

namespace Capstone.Web.Controllers
{
    public class ParksController : HomeController
    {
        IParkDao parkDao;
        IWeatherDao weatherDao;

        public ParksController(IParkDao parkDao, IWeatherDao weatherDao)
        {
            this.parkDao = parkDao;
            this.weatherDao = weatherDao;
        }

        public IActionResult Index()
        {
            List<Park> parks = parkDao.GetParks();      
            return View(parks);
        }
        
        public IActionResult Detail(string id)
        {
            ParkInfo parkinfo = new ParkInfo();
            //HttpContext.Session.Set();
            parkinfo.park = parkDao.GetParkDetail(id);
            parkinfo.weather = weatherDao.GetWeather(id);

            return View(parkinfo);
        }
    }
}