using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WarThunderApplet.Models
{
   public class MapObjectModel
    {
        //Mapping based on /map_obj.json
        public string Type { get; set; }
        //Need RGB so no on this color so convert from this as two properties are name color 
        public string Color { get; set; }
       //public int[] Color { get; set; }
        //Cords for planes and vehicles 
        public double X { get; set; }
        public double Y { get; set; }
        public double DX { get; set; }
        public double DY { get; set; }
        
        //Airfields and some return theses as SX / SY /EX/EY
        public double SX { get; set; }
        public double SY { get; set; }
        public double EX { get; set; }
        public double EY { get; set; }

        //Icon
        public string Icon { get; set; }
        public string Icon_Bg { get; set; }

        //Blink
        public bool Blink { get; set; }

    }
}
