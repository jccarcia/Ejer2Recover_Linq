using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    class Program
    {
        static List<Coche> listaCoche = new List<Coche>();
        static void Main(string[] args)
        {
            Ejer3();
        }

        static List<Coche> Ejer1() //Crea la clase para poder cargar el Json y cargalo.
        {
            using (StreamReader lector = new StreamReader("Cars.json"))
            {
                string json = lector.ReadToEnd();
                List<Coche> resultado = JsonConvert.DeserializeObject<List<Coche>>(json);
                return resultado;
            }
        }

        static void Ejer2() //Muestra los distintos Fabricantes, sin duplicar ningún fabricante y poniendo inicialmente "Fabricante :" en todos los elementos.
        {
            var dist = listaCoche.GroupBy(x => x.Maker).Select(y => y.First());
            foreach (var i in dist)
            {
                Console.WriteLine("Fabricante :" + i.Maker);
            }
        }

        static void Ejer3() //Muestra los diferentes colores indicando Maker y Modelo también.
        {
            var ajar = listaCoche.GroupBy(x=> x.Color).Select(y => y.First());
            foreach (var i in ajar)
            {
                Console.WriteLine("Color :" + i.Color + "Fabricante :" + i.Maker);
            }
        }

        static void Ejer4() //Muestra fabricante y modelo. Del color Verde.
        {
            var beti = listaCoche.Where(x => x.Color == "Verde");
            foreach (var i in beti)
            {
                Console.WriteLine("Frabricante :" + i.Maker + "Modelo :" + i.Model);
            }
        }

        static void Ejer5(double latitud, double longitud) //Permite al usuario introducir una latitud y una longitud. 
                                                           //Indica al usuario si encuentra un coche del año 1992 dentro de esa latitud y longitud facilitada.
        {
            var buscar = listaCoche.Where(x => x.Latitude == latitud && x.Longitude == longitud);
            foreach (var i in buscar)
            {
                if (i.Year == 1992)
                {
                    Console.WriteLine("Hay un coche del año 1992");
                }
                else
                {
                    Console.WriteLine("No hay un coche del año 1992");
                }
            }

        }
    }
}
