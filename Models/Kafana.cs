using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeeBerryHome3.Models
{
    public class Kafana
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String Rating { get; set; }
        public String ImageUrl { get; set; }
        
        // 1-1 sa menijem, n-m bendom
        public Menu CurrentMenu { get; set; }
        public List<Band> CurrentBands { get; set; }
    }
}