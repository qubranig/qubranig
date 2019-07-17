using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Timers;
using System.Windows;
using System.Windows.Input; //für die tasten Funktionalität


namespace Rechner01
{
    

    public static class Operanten
    {
        public static void Addition(Numbs numbs)
        {
            numbs.Ergebniss = numbs.Zahl1 + numbs.Zahl2;
            numbs.Zahl1 = numbs.Zahl1 + numbs.Zahl2;
            numbs.Zahl2 = 0;
          //MainWindow.StaticMainWindow.textbox1   so bekomm ich die events aus der main !!!!
        }
        public static void Subtraktion(Numbs numbs)
        {
            
                numbs.Ergebniss = numbs.Zahl1 - numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 - numbs.Zahl2;
                numbs.Zahl2 = 0;
            
        }
        public static void Multiplikation(Numbs numbs)
        {
        
                numbs.Ergebniss = numbs.Zahl1 * numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 * numbs.Zahl2;
                numbs.Zahl2 = 0;
            
        }
        public static void Division(Numbs numbs)
        {
            
                numbs.Ergebniss = numbs.Zahl1 / numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 / numbs.Zahl2;
                numbs.Zahl2 = 0;
           
        }
        public static void Modulo(Numbs numbs)
        {
                numbs.Ergebniss = numbs.Zahl1 % numbs.Zahl2;

        }
        public static void Quadrat(Numbs numbs)
        {
            if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0) 
            {
                numbs.Ergebniss = Math.Pow(numbs.Zahl2, 2);
            }
            else 
            {
                numbs.Ergebniss = Math.Pow(numbs.Zahl1, 2);
            }
        }
        public static void Wurzel(Numbs numbs)
        {
            if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0) 
            {
                numbs.Ergebniss = Math.Sqrt(numbs.Zahl2);
            }
            else
            {
                numbs.Ergebniss = Math.Sqrt(numbs.Zahl1);
            }
            numbs.Zahl1 = numbs.Ergebniss;
        }
        public static void Sinus(Numbs numbs)
        {
            if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0) 
            {
                numbs.Ergebniss = Math.Sin(numbs.Zahl2);
            }
            else
            {
                numbs.Ergebniss = Math.Sin(numbs.Zahl1);
            }
        }
        public static void Cosinus(Numbs numbs)
        {
            if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0) 
            {
                numbs.Ergebniss = Math.Cos(numbs.Zahl2);
            }
            else 
            {
                numbs.Ergebniss = Math.Cos(numbs.Zahl1);
            }
        }
        public static void Tangenz(Numbs numbs)
        {
            if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = Math.Tan(numbs.Zahl2);
            }
            else 
            {
                numbs.Ergebniss = Math.Tan(numbs.Zahl1);
            }
        }
        public static void Xquadrat(Numbs numbs)
        {
            try
            {
                numbs.Ergebniss = Math.Pow(numbs.Zahl1, numbs.Zahl2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public static void DritteWurzel(Numbs numbs)
        {
            double n = 3.0;
            if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0) 
            {
                numbs.Ergebniss = Math.Pow(numbs.Zahl2, 1.0 / n);
            }
            else 
            {
                numbs.Ergebniss = Math.Pow(numbs.Zahl1, 1.0 / n);
            }
        }
        public static void Pi(Numbs numbs)
        {
            { //https://matheguru.com/allgemein/die-kreiszahl-pi.html
                if (numbs.Zahl1 != 0 && numbs.Zahl2 != 0) //dann wurde ja die 2. zahl zuletzt eingegeben
                {
                    numbs.Zahl2 = 3.14159265301;
                    MainWindow.StaticMainWindow.textbox1.Text = numbs.Zahl2.ToString();
                }
                else //dann war es die 1. zahl die zuletzt eingegeben wurde
                {
                    numbs.Zahl1 = 3.14159265301;
                    MainWindow.StaticMainWindow.textbox1.Text = numbs.Zahl1.ToString();
                }
            }

        }
    }

}
