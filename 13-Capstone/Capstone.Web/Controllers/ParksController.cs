using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Extensions;
using Microsoft.AspNetCore.Http;
using SessionExtensions = Capstone.Web.Extensions.SessionExtensions;

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

            parkinfo.park = parkDao.GetParkDetail(id);
            parkinfo.weather = weatherDao.GetWeather(id);
            string current = "";
            if (HttpContext.Session.GetString("Temperature") is null)
            {
                current = "F";
            }
            else
            {
                current = HttpContext.Session.GetString("Temperature").ToString();
            }


            if (current == "F")
            {

                foreach (var item in parkinfo.weather)
                {
                    item.High = item.ConverToCelcius(item.High);
                    item.Low = item.ConverToCelcius(item.Low);
                    item.Unit = current;
                }
            }

            else
            {
                foreach (var item in parkinfo.weather)
                {
                    item.High = item.ConverToFaren(item.High);
                    item.Low = item.ConverToFaren(item.Low);
                    item.Unit = current;
                }

            }


            return View(parkinfo);
        }


        public IActionResult SetTempMeasurement(string id)
        {
            string current = "";
            if (HttpContext.Session.GetString("Temperature") is null)
            {
                current = "F";
            }
            else
            {
                current = HttpContext.Session.GetString("Temperature").ToString();
            }
     

            if (current == "F")
            {
                current = "C";
            }

            else
            {
                current = "F";
            }


            HttpContext.Session.SetString("Temperature", current);
            
            return RedirectToAction("Detail", new {id = @id } );

        }
    }
}