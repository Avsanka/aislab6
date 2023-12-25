using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab6
{
    class Weather
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Temperature { get; set; }
        public string Description { get; set; }


        public string GetInfo()
        {
            //return $"Дата: {DateAndTime}, \n Пара: {Name}, \n Преподаватель: {Prepod}, \n Место: {Building}, {Auditoria}"; 
            return $"{Name} \n{Time} {Temperature}°C\n{Description}";
        }
    }
}
