using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeeBerryHome3.Models
{
    public class Menu
    {
        public String Id { get; set; }
        // 1-1 sa kafanom
        public Kafana Owner { get; set; }

        // n-m sa stavkama za meni
        public List<MenuItem> Items { get; set; }

    }
}