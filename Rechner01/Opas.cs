using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rechner01
{
    interface IOpas
    {
        void Methode();// isch schreib mal irgendwas rein und dann post ich das
        int x=0;

    }
    public static class opas2
    {
        static public void methodetest(Numbs numbs)
        {
            numbs.Ergebniss = numbs.Zahl1 - numbs.Zahl2;
            numbs.Zahl1 = numbs.Zahl1 - numbs.Zahl2;
            numbs.Zahl2 = 0;

        }
    }

}
