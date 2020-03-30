using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice_SecondTry
{
    public class Program
    {

        static void Main(string[] args)
        {
            Ejer2(Ejer1());
            Ejer3(Ejer1());
            Ejer4(Ejer1());
            Ejer5(46.4086282, 16.1508154, Ejer1());
            Ejer6(Ejer1());
            Ejer7(Ejer1());
            Ejer8(Ejer1());
            Ejer9(Ejer1());
            Ejer10(Ejer1());
            Ejer11(Ejer1());
            Ejer12(Ejer1());
            Ejer13(Ejer1());
            Ejer14(Ejer1());
            Ejer15(Ejer1());
            Ejer16(Ejer1(), "Violet", 2003);
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

        public static void Ejer2(List<Coche> listaCoche) //Muestra los distintos Fabricantes, sin duplicar ningún fabricante y poniendo inicialmente "Fabricante :" en todos los elementos.
        {
            var dist = listaCoche.GroupBy(x => x.Maker).Select(y => y.First());
            foreach (var i in dist)
            {
                Console.WriteLine("Fabricante :" + i.Maker);
                
            }

            Console.ReadKey();
        }

        public static void Ejer3(List<Coche> listaCoche) //Muestra los diferentes colores indicando Maker y Modelo también.
        {
            var ajar = listaCoche.GroupBy(x=> x.Color).Select(y => y.First());
            foreach (var i in ajar)
            {
                Console.WriteLine("Color :" + i.Color + "Fabricante :" + i.Maker);
            }

            Console.ReadKey();
        }

        static void Ejer4(List<Coche> listaCoche) //Muestra fabricante y modelo. Del color Verde.
        {
            var beti = listaCoche.Where(x => x.Color == "Green");
            foreach (var i in beti)
            {
                Console.WriteLine("Frabricante :" + i.Maker + " Modelo :" + i.Model);
            }

            Console.ReadKey();
        }

        static void Ejer5(double latitud, double longitud, List<Coche> listaCoche) //Permite al usuario introducir una latitud y una longitud. 
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

            Console.ReadKey();
        }

        static void Ejer6(List<Coche> listaCoche) //Muestra todos los coches del año posterior de 2001.
        {
            var edad = listaCoche.Where(x => x.Year >= 2001);
            foreach (var i in edad)
            {
                Console.WriteLine(i.Maker + " - " + i.Model);
            }

            Console.ReadKey();
        }

        static void Ejer7(List<Coche> listaCoche) //Genera una nueva clase con modelo y fabricante. Muestra todos los coches que tengan latitud, ni longitud Convierte en la búsqueda a esa clase.
        {
            var a = listaCoche.Where(x => x.Location.Latitude == null && x.Location.Longitude == null);

            foreach (var i in a)
            {

                Console.WriteLine("Modelo: "+ i.Model + " Fabricante: " + i.Maker);

            }

            Console.ReadKey();
        }

        static void Ejer8(List<Coche> listaCoche) //Busca todos los coches de color Blue y que sean anteriores al año 2000.
        {
            var e = listaCoche.Where(x => x.Year >= 2000 && x.Color == "Blue");
            foreach (var i in e)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        static void Ejer9(List<Coche> listaCoche) //Agrupa todos los coches por fabricante, muestralos por pantalla ordenados por año.
        {
            var rav = listaCoche.OrderBy(x => x.Year).GroupBy(x => x.Maker);
            foreach (var i in rav)
            {
                Console.WriteLine(i.Key);
            }

            Console.ReadKey();
        }

        static void Ejer10(List<Coche> listaCoche) //Agrupa todos los coches por modelo, muestra los colores disponibles sin duplicar la muestra.
        {
            var fabcolor = listaCoche.GroupBy(x => x.Model).Select(y => y.First());
            foreach (var i in fabcolor)
            {
                Console.WriteLine(i.Maker + " - " + i.Color);
            }

            Console.ReadKey();
        }

        static void Ejer11(List<Coche> listaCoche) //Página de 10 en 10 pulsando una tecla y muestra todos los coches disponibles
        {
            for (int i = 0; i < listaCoche.Count; i += 10)
            {
                var lista = listaCoche.Skip(0 + i).Take(10);
                foreach (var x in lista)
                {
                    Console.WriteLine(x.ToString());
                }
                Console.ReadKey();

            }

            Console.ReadKey();
        }

        static void Ejer12(List<Coche> listaCoche) //Encuentra el primer coche posterior del año 2001 del fabricante Suzuki
        {
            var suzu = listaCoche.Where(x => x.Maker == "Suzuki" && x.Year > 2001).Take(1);
            foreach (var i in suzu)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        static void Ejer13(List<Coche> listaCoche) //Muestra todos los coches que tengan guardado el año.
        {
            var ok = listaCoche.Where(x => x.Year != null);
            foreach (var i in ok)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        static void Ejer14(List<Coche> listaCoche) //Agrupa por año todos los coches y muestra la cantidad que hay de color Rosa
        {
            var col = listaCoche.Where(x => x.Color == "Pink").GroupBy(y => y.Year);
            foreach (var i in col)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        static void Ejer15(List<Coche> listaCoche) //Busca todos los coches BMW que no tengan ni año, ni color.
        {
            var bar = listaCoche.Where(x => x.Maker == "BMW" && x.Year == null && string.IsNullOrEmpty(x.Color));
            foreach (var i in bar)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        public static void Ejer16(List<Coche> chs, string colores, int ano) //Crea un método de extensión donde se pueda introducir color y año, devolviendo el listado de Coches que no cumplan la condición.
        {
            var list = chs.Where(x => x.Color != colores && x.Year != ano);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        public static class ExtensionMethods
        {
            public static void listVehiculos<T>(string color, int? ano, List<Coche> listaCoche)
            {
                var lv = listaCoche.Where(x => x.Year != ano && x.Color != color);
                foreach (var i in lv)
                {
                    Console.WriteLine(i);
                }

                Console.ReadKey();
            }
        }
    }
}
