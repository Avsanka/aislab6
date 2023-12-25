using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser();
            // string url = "https://www.gismeteo.ru/weather-tomsk-4652/now/";
            string url = "https://www.gismeteo.ru/weather-ufa-4588/now/";
            Console.OutputEncoding = Encoding.UTF8;
            parser.Parse(url);
            Console.ReadLine();
        }

        
    }
}
