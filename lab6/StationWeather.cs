using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class StationWeather
    {
        public string Name { get; set; }
        public string Temperature { get; set; }
        public string GetInfo()
        {
            return $"{Name}  {Temperature}°C";
        }
    }
}
