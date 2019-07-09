using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Timers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input; //für die tasten Funktionalität
using System.Timers;

namespace Rechner01
{

    public static class Operanten
    {
        public static void Addition(Numbs numbs)
        {
            numbs.Ergebniss = numbs.Zahl1 + numbs.Zahl2;
            numbs.Zahl1 = numbs.Zahl1 + numbs.Zahl2;
            numbs.Zahl2 = 0;
        }
        public static void Subtraktion(Numbs numbs)
        {
            if (numbs.Zahl2 != 0)// hier stimmt was nicht ...   
            {
                numbs.Ergebniss = numbs.Zahl1 - numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 - numbs.Zahl2;
                numbs.Zahl2 = 0;
            }
        }
        public static void Multiplikation(Numbs numbs)
        {
            if (numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = numbs.Zahl1 * numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 * numbs.Zahl2;
                numbs.Zahl2 = 0;
            }
        }
        public static void Division(Numbs numbs)
        {
            if (numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = numbs.Zahl1 / numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 / numbs.Zahl2;
                numbs.Zahl2 = 0;
            }
        }

    }

}
