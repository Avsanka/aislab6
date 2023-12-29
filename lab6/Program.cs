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
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                //Console.Clear();
                int userInput = Menu();
                switch (userInput)
                {
                    case 1:
                        Console.Clear();
                        WeatherToday();
                        break;
                    case 2:
                        ShowHistory();
                        break;
                    case 3:
                        ShowHistoryRequests();
                        break;
                    case 4:
                        Clear();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неизвестная команда");
                        break;
                }
            }

            //City c = new City();
            //c.Name = "Томск";
            //using (WeatherContext context = new WeatherContext())
            //{
            //    context.Cities.Add(c);
            //    context.SaveChanges();
            //}

        }

        public static int Menu()
        {
            Console.WriteLine("1 - посмотреть погоду в Томске на сегодня");
            Console.WriteLine("2 - Посмотреть историю погоды");
            Console.WriteLine("3 - Посмотреть историю запросов");
            Console.WriteLine("4 - Очистить все записи");
            Console.WriteLine("5 - Закрыть");
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public static void WeatherToday()
        {
            var parser = new Parser();
            string url = "https://www.gismeteo.ru/weather-tomsk-4652/now/";

            parser.Parse(url);
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowHistory()
        {
            using (WeatherContext context = new WeatherContext())
            {
                Console.Clear();
                var weathers = context.weathers;
                foreach(Weather w in weathers)
                {
                    Console.WriteLine("{0} Было: {1}°C. {2}\nСтанций: {3}\n"
                        , w.Time, w.Temperature, w.Description, w.Stations);
                }
                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ShowHistoryRequests()
        {
            using (WeatherContext context = new WeatherContext())
            {
                Console.Clear();
                var hs = context.Histories;

                foreach(History h in hs)
                {
                    Console.WriteLine("Запрос ({1}), {0}\n", h.Name, h.Date);
                }
            }
        }
        public static void Clear()
        {
            using (WeatherContext context = new WeatherContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE Weathers");
            }
            Console.WriteLine("Данные были удалены. Нажмите любую клавишу, чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
