using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public bool IsCelcius { get; set; } = true;

        public void ConvertToCelcius()
        {
            if (IsCelcius == false)
            {
                Low = (Low - 32) * 5 / 9;
                High = (Low - 32) * 5 / 9;
            }
        }
    }
}
