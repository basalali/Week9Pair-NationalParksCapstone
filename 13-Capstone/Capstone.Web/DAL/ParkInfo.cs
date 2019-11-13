using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkInfo
    {
        public Park park { get; set; }
        public Weather weather { get; set; }
    }
}
