using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> atributyPostavy = new Dictionary<string, int>()
            {
                {"STR", 10 }, {"DEX", 10 }, {"INT", 10 }
            };

            bool mrtvy = false;
            int level = 1;
            int unava = 0;
            Console.Write("Zadej jmeno své postavy: ");
            string jmeno = Console.ReadLine();
            Random random = new Random();
            string[] typy = new string[]{ "STR", "DEX", "INT" };

            do
            {
                Console.Clear();
                Console.WriteLine($"Jsi unavený na {unava}%");
                Console.WriteLine("Chces jít na quest nebo se jít vyspat? Q/V ");
                string odpoved = Console.ReadLine().ToLower().Trim();
                string ukolTyp = typy[random.Next(0, 3)];

                switch (odpoved)
                {
                    case "q":

                        Console.Clear();
                        Console.WriteLine($"Vydáváš se plnit úkol na {ukolTyp}, vrať se za {level * 10} sekund");
                        Console.WriteLine(".....");
                        Thread.Sleep(level * 10000);
                        mrtvy = ((random.Next(0, 101) > unava) ? false : true);
                        if (mrtvy)
                        {
                            Console.Clear();
                            Console.WriteLine("Usnul jsi v boji a zemřel ty NOOB!!!!");
                            break;
                        }
                        level++;
                        atributyPostavy[ukolTyp] += 10;
                        unava += 10;
                        Console.WriteLine($"{jmeno} se z výpravy vrátil celý");
                        Console.WriteLine("---------------");
                        Console.WriteLine($"{jmeno} má lvl. {level} a vlastnosti:");
                        Console.WriteLine($"STR: { atributyPostavy["STR"]}\nDEX: { atributyPostavy["DEX"]}\nINT: { atributyPostavy["INT"]}");
                        Console.WriteLine("Pro pokracovani stiskni tlacitko na klavesnici");
                        Console.ReadKey();

                        break;
                    case "v":
                        Console.Clear();
                        Console.WriteLine($"{jmeno} bude spat jeste {unava} sekund, vrat se pak");
                        Thread.Sleep(unava * 1000);
                        Console.WriteLine($"{jmeno} uz je vzhuru");
                        unava = 0;
                        Console.WriteLine("Pro pokračování stiskni tlačítko na klávesnici");
                        Console.ReadKey();
                        break;
                }
            } while (!mrtvy);
            Console.ReadKey();
        }
    }
}
