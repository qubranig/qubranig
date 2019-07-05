using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechner01
{
    interface IOpas
    {
        void Methode();// hallo hallo
        int x { get; set; }
        public void was_ist_was();
        public string hallo="welt!";
        string text { get; set; }
    }
    public static class opas2
    {
        static public void methodetest(Numbs numbs)
        {
            numbs.Ergebniss = numbs.Zahl1 - numbs.Zahl2;
            numbs.Zahl1 = numbs.Zahl1 - numbs.Zahl2;
            numbs.Zahl2 = 0;

            int x = 0;
        }
    }

}
