using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace lab6
{
    class Parser
    {


        public async void Parse(string url)
        {
            IConfiguration config = Configuration.Default.WithDefaultLoader();

            IBrowsingContext context = BrowsingContext.New(config);

            IDocument doc = await context.OpenAsync(url);

            Weather w = new Weather();

            IElement name = doc.QuerySelector("div.page-title");
            w.Name = name.TextContent;

            IElement day = doc.QuerySelector("div.now-localdate");
            w.Time = day.TextContent;

            IElement temperature = doc.QuerySelector("span.unit_temperature_c");
            w.Temperature = temperature.TextContent;


            IElement desc = doc.QuerySelector("div.now-desc");
            w.Description = desc.TextContent;

            Console.WriteLine(w.GetInfo() + "\n");

            List<string> stations = await GetLinks(url);
            foreach(string u in stations)
            {
                stationsParse(u);
            }

            SaveToDb(w);
        }

        public async void stationsParse(string url)
        {
            IConfiguration config = Configuration.Default.WithDefaultLoader();

            IBrowsingContext context = BrowsingContext.New(config);

            IDocument doc = await context.OpenAsync(url);

            StationWeather sw = new StationWeather();

            IElement name = doc.QuerySelector("div.page-title");
            IElement temp = doc.QuerySelector("span.unit_temperature_c");

            sw.Name = name.TextContent;
            sw.Temperature = temp.TextContent;

            Console.WriteLine(sw.GetInfo());
        }

        public async Task<List<string>> GetLinks(string url)
        {
            IConfiguration config = Configuration.Default.WithDefaultLoader();
            IBrowsingContext context = BrowsingContext.New(config);
            IDocument doc = await context.OpenAsync(url);

            IEnumerable<IElement> aElements = doc.All.Where(block =>
            block.LocalName == "a"
            && block.ParentElement.LocalName == "div"
            && block.ParentElement.ClassList.Contains("meteostations"));

            List<string> output = new List<string>();

            foreach (IElement a in aElements.ToList())
            {
                output.Add($"https://www.gismeteo.ru{a.GetAttribute("href")}");
            }
            return output;
        }

        public static void SaveToDb(Weather w)
        {
            using (WeatherContext context = new WeatherContext())
            {
                context.weathers.Add(w);
                context.SaveChanges();
            }
        }
    }
}
