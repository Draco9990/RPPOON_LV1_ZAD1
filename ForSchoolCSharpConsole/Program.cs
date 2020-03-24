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

    class Zabiljeske
    {
        private string zabiljeska;

        public string Zabiljeska
        {
            get { return zabiljeska; }
            set { zabiljeska = value; }
        }

        private string autor;

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        private int vaznost;

        public int Vaznost
        {
            get { return vaznost; }
            set { vaznost = value; }
        }

        public Zabiljeske()
        {
            autor = "Anonymous";
            Zabiljeska = "";
            vaznost = 0;
        }

        public Zabiljeske(string autorIn, string zabiljeskaIn = "", int vaznostIn = 0)
        {
            autor = autorIn;
            Zabiljeska = zabiljeskaIn;
            vaznost = vaznostIn;
        }

        public Zabiljeske(string zabiljeskaIn, int vaznostIn)
        {
            autor = "Anonymous";
            Zabiljeska = zabiljeskaIn;
            vaznost = vaznostIn;
        }

        public override string ToString()
        {
            return Autor + " - " + Zabiljeska;
        }

        //Koristeno u prijasnjim zadatcima
        /*public string GetZabiljeska()
        {
            return Zabiljeska;
        }

        public string GetAutor()
        {
            return autor;
        }

        public int GetVaznost()
        {
            return vaznost;
        }

        public bool SetZabiljeska(string zabiljeskaIn)
        {
            Zabiljeska = zabiljeskaIn;
            return Zabiljeska == zabiljeskaIn;
        }

        public bool SetVaznost(int vaznostIn)
        {
            vaznost = vaznostIn;
            return vaznost == vaznostIn;
        }*/
    }

    class TimeZabiljeske : Zabiljeske
    {
        private DateTime vrijeme;

        public DateTime Vrijeme
        {
            get { return vrijeme; }
            set { vrijeme = value; }
        }

        public TimeZabiljeske() : base()
        {
            vrijeme = DateTime.Now;
        }

        public TimeZabiljeske(string autorIn, string zabiljeskaIn = "", int vaznostIn = 0, DateTime vrijemeIn = new DateTime()) : base(autorIn, zabiljeskaIn, vaznostIn)
        {
            if (vrijemeIn == new DateTime()) vrijeme = DateTime.Now;
            else vrijeme = vrijemeIn;
        }

        public TimeZabiljeske(string zabiljeskaIn, int vaznostIn, DateTime vrijemeIn = new DateTime()) : base(zabiljeskaIn, vaznostIn)
        {
            if (vrijemeIn == new DateTime()) vrijeme = DateTime.Now;
            else vrijeme = vrijemeIn;
        }

        public override string ToString()
        {
            return Autor + " - " + Zabiljeska + " - " + Vrijeme;
        }
    }

    class ToDo
    {
        private List<Zabiljeske> zadatci;

        public ToDo()
        {
            zadatci = new List<Zabiljeske>();
        }

        public ToDo(List<Zabiljeske> zadatciIn)
        {
            zadatciIn = new List<Zabiljeske>();
        }

        public bool AddZadatak(Zabiljeske z)
        {
            zadatci.Add(z);
            return true;
        }

        public bool RemoveZadatak(int i)
        {
            zadatci.RemoveAt(i);
            return true;
        }

        public Zabiljeske GetZadatak(int i)
        {
            return zadatci[i];
        }

        public bool PrintWhole()
        {
            Console.WriteLine("Zadatci:");
            foreach(var z in zadatci)
            {
                Console.WriteLine(z.ToString());
            }

            return true;
        }

        public bool IsEmpty()
        {
            return zadatci.Count == 0;
        }

        public int GetHighest()
        {
            int i = zadatci[0].Vaznost;
            foreach (var z in zadatci)
            {
                if (z.Vaznost > i)
                {
                    i = z.Vaznost;
                }
            }

            return i;
        }

        public bool DoHighest()
        {
            Console.WriteLine("Obavljam najbitnije zadatke!");
            int najveci = GetHighest();
            for (int i = 0; i < zadatci.Count; i++)
            {
                if (zadatci[i].Vaznost == najveci)
                {
                    if(zadatci[i] is TimeZabiljeske)
                    {
                        TimeZabiljeske t = (TimeZabiljeske) zadatci[i];
                        t.Vrijeme = DateTime.Now;
                        Console.WriteLine("Obavljen zadatak: " + t.ToString());
                        zadatci.RemoveAt(i);
                        i--;
                    }
                    else
                    {
                        Console.WriteLine("Obavljen zadatak: " + zadatci[i].ToString());
                        zadatci.RemoveAt(i);
                        i--;
                    }
                }
            }

            return true;
        }
    }
}
