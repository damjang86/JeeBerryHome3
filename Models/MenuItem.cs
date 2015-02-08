using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JeeBerryHome3.Models
{
    public class MenuItem
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
        
        //n-m sa menijem
        public List<Menu> Owners { get; set; }
    }
}