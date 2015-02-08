using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeeBerryHome3.Models
{
    public class Band
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Rating { get; set; }
        public String Timetable { get; set; }
        public String Genre { get; set; }
        public String ImageUrl { get; set; }

        // n-m sa kafanama
        public List<Kafana> PlaysAt { get; set; }

    }
}