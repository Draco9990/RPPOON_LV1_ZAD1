using System;
using System.Collections.Generic;
using System.Text;

namespace ForSchoolCSharpConsole
{
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
            return base.ToString() + " - " + Vrijeme;
        }
    }
}
