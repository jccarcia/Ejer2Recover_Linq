using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    public class Location
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class Coche : Location
    {
        public int id { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public Location Location { get; set; }

        public override string ToString()
        {
            String resul = "";
            resul += "id : " + id + "\r\n";
            resul += "Maker :" + Maker + "\r\n";
            resul += "Model:" + Model + "\r\n";
            resul += "Year: " + Year + "\r\n";
            resul += "Color :" + Color + "\r\n";
            resul += "Location :" + Longitude + "\r\n";
            resul += "Latitude :" + Latitude + "\r\n" + "\r\n";
            return resul;
        }
    }
}
