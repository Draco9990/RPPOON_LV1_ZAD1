using System;
using System.Collections.Generic;

namespace ForSchoolCSharpConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<Zabiljeske> zabiljeske = new List<Zabiljeske>();
            zabiljeske.Add(new Zabiljeske());
            zabiljeske.Add(new Zabiljeske("Marino", "Nebitno."));
            zabiljeske.Add(new Zabiljeske("Vazno!", 3));
            zabiljeske.Add(new TimeZabiljeske("Marino2", "Vremenska Zabiljeska", 0, DateTime.Now));
            foreach(var z in zabiljeske)
            {
                //Koristeno u prijasnjim zadatcima
                //Console.WriteLine(z.Autor + " - " + z.Zabiljeska);
                Console.WriteLine(z.ToString());
            }*/
            ToDo lista = new ToDo();
            while (true)
            {
                Console.Write("Unesite zadatak: ");
                string zab = Console.ReadLine();
                if (zab == "") break;

                Console.Write("Unesite autora: ");
                string autor = Console.ReadLine();
                if (autor == "") autor = "Anonymous";

                Console.Write("Unesite vaznost zadatka: ");
                int vaznost = Convert.ToInt32(Console.ReadLine());

                Console.Write("Zabiljezi vrijeme obavljanja? Y/N: ");
                string vrijeme = Console.ReadLine();
                if (vrijeme == "Y" || vrijeme == "y")
                {
                    lista.AddZadatak(new TimeZabiljeske(autor, zab, vaznost));
                }
                else
                {
                    lista.AddZadatak(new Zabiljeske(autor, zab, vaznost));
                }
                Console.WriteLine();
            }

            while (!lista.IsEmpty())
            {
                lista.PrintWhole();
                Console.WriteLine("");
                lista.DoHighest();
                Console.WriteLine("");
                Console.WriteLine();
            }
        }
    }
}
