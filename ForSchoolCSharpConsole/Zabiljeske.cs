using System;
using System.Collections.Generic;
using System.Text;

namespace ForSchoolCSharpConsole
{
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
}
