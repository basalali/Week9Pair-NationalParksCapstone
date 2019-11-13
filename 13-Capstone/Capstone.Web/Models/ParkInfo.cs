using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class ParkInfo
    {
        public Park park { get; set; }
        public List<Weather> weather { get; set; }
    }
}
