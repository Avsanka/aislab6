using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace lab6
{
    class WeatherContext : DbContext
    {
        public WeatherContext() : base("DbConnection") { }
        public DbSet<Weather> weathers { get; set; }
    }
}
