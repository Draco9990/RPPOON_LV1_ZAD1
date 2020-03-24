using System;
using System.Collections.Generic;
using System.Text;

namespace ForSchoolCSharpConsole
{
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
            foreach (var z in zadatci)
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
                    if (zadatci[i] is TimeZabiljeske)
                    {
                        TimeZabiljeske t = (TimeZabiljeske)zadatci[i];
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
