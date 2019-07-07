using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input; //für die tasten Funktionalität
/// <summary>
/// to do :
/// -liste von zahlen und opereratoren -> brauchen wir andere andere methden (listezahlen[x] , operator[i] ... 
/// -liste von objekten für speicher implementierung
/// -tetxbox abschalten dass man nix reinschreiben kann 
/// -methoden auslagern in eine statische klasse
/// -kommazahlen 
/// -
/// 
/// mögliche features: 
/// ->webbrowser (vieleicht finden wir einen taschenrechner online dem wir die zaheln und operatoren übergebn könenn als gegen check )
/// -die fertige rechungen auslagern in eine excel datei?
/// 
/// </summary>




namespace Rechner01
{
     public class Numbs
     {
        public double Zahl1 { get; set; }
        public double Zahl2 { get; set; }
        public List<double> listezahlen { get; set; }
        public double Ergebniss { get; set; }

        public string Operant { get; set; }
        public List<string>listeoperanten { get; set; }

     }

    public partial class MainWindow : Window
    {//globale variablen
        List<Numbs> speicher = new List<Numbs>();
        bool operant = false;
        bool DezimalStelle = false;
        double zahl1 = 0;
        double zahl2 = 0;
        Numbs hmmm = new Numbs();


        public MainWindow()
        {
            Numbs hmmm = new Numbs();
            InitializeComponent();
    
        }//endemain


        public void zahl_click(object sender, RoutedEventArgs e)///////////////////////////underconstruction (das wird das komma?)
        {
            if (DezimalStelle) //funktionalität für das komma und interpretation als dezimalstelle
            { // später müssen wir das zeichen ersetzen mit double.Parse(TextBox1.Text.Replace('.', ',')
                double Zwsp=0;
                if (!operant)
                {
                        Zwsp = (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                    
                    hmmm.Zahl1 =hmmm.Zahl1+ Zwsp/10;

                    textbox1.Text = hmmm.Zahl1.ToString();
                    /////////////////////nicht fertig   ich kann eine nachkommastelle anfügen zumindest 
                }
                else
                {
                    Zwsp = (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                    Zwsp = Zwsp / 10;
                    hmmm.Zahl2 += Zwsp;
                    textbox1.Text = hmmm.Zahl2.ToString();

                }
            }
            else
            {
                if (!operant)
                {
                    if (zahl1 == 0)
                    {
                        hmmm.Zahl1 = (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                        zahl1 = (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                    }
                    else
                    {
                        hmmm.Zahl1 = hmmm.Zahl1 * 10 + (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                        zahl1 = zahl1 * 10 + (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                    }

                    textbox1.Text = hmmm.Zahl1.ToString();

                }
                else
                {
                    if (zahl2 == 0)
                    {
                        hmmm.Zahl2 = (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                        zahl2 = (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                    }
                    else
                    {
                        hmmm.Zahl2 = hmmm.Zahl2 * 10 + (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                        zahl2 = zahl2 * 10 + (Convert.ToDouble((sender as System.Windows.Controls.Button).Content));
                    }
                    textbox1.Text = hmmm.Zahl2.ToString();

                }
            }
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }

        public void op_click(object sender, RoutedEventArgs e) //operanten taste
        {
            operant = true;
            hmmm.Operant = Convert.ToString((sender as System.Windows.Controls.Button).Content);
            opzeichen.Text = hmmm.Operant.ToString();
            ergebnis();
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }

    
  
        private void Gleich_Click(object sender, RoutedEventArgs e)
        {
            ergebnis();
            operant = false;
        }
        private void ergebnis() //ErgebnisMethode
        {
            switch (hmmm.Operant)
            {
                case "+":
                    addition(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "-":
                    subtraktion(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "*":
                    Multiplikation(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "/":
                    Division(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;


            }
           
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }
      private void addition(Numbs numbs)
        {
            /*
            int istDezimal = 0;
            if (numbs.Zahl2 != 0)
            {
                if (DezimalStelle)
                {
                    numbs.Zahl1 /= 10;
                    istDezimal = 10;
                }
                */
                numbs.Ergebniss = numbs.Zahl1 + numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 + numbs.Zahl2;
             //   numbs.Zahl1 *= istDezimal; //rechne das ergebnis *10 für die richtige anzeige wenn nachkomma
                numbs.Zahl2 = 0;
                    
         }
        private void subtraktion(Numbs numbs)
        {

            if (numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = numbs.Zahl1 - numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 - numbs.Zahl2;
                numbs.Zahl2 = 0;
            }
        }
        private void Multiplikation(Numbs numbs)
        {

            if (numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = numbs.Zahl1 * numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 * numbs.Zahl2;
                numbs.Zahl2 = 0;
            }
        }
        private void Division(Numbs numbs)
        {

            if (numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = numbs.Zahl1 / numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 / numbs.Zahl2;
                numbs.Zahl2 = 0;
            }
        }

        private void Ce_Click_1(object sender, RoutedEventArgs e)
        {
            textbox1.Clear();
            hmmm.Zahl1 = 0;
            hmmm.Zahl2 = 0;
            hmmm.Ergebniss = 0;
            hmmm.Operant = "";
        }
        private void Komma_Click(object sender, RoutedEventArgs e)
        {
            DezimalStelle = true; 
            if (DezimalStelle)
            {
            textbox1.Text += "," ;//display
            }
        }
        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e) //funktionalität für das drücken einer taste
        {
            //https://stackoverflow.com/questions/10626626/numpad-key-codes-in-c-sharp
            #region //nummern(pad) tasten
            if (e.Key == Key.NumPad0) // wenn 0 , dann führe aus
            {
                sender = /*button: */@null;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad1) // wenn 1, dann führe aus
            {
                sender = /*button: */eins;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad2) // wenn 2 , dann führe aus
            {
                sender = /*button: */zwei;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad3) // wenn 3, dann führe aus
            {
                sender = /*button: */drei;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad4) // wenn 4, dann führe aus
            {
                sender = /*button: */vier;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad5) // wenn 5, dann führe aus
            {
                sender = /*button: */fünf;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad6) // wenn 6, dann führe aus
            {
                sender = /*button: */sechs;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad7) // wenn 7, dann führe aus
            {
                sender = /*button: */sieben;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad8) // wenn 8, dann führe aus
            {
                sender = /*button: */acht;
                zahl_click(sender, e);
            }
            if (e.Key == Key.NumPad9) // wenn 9, dann führe aus
            {
                sender = /*button: */neun;
                zahl_click(sender, e);
            }
            #endregion // nummern(pad) tastem

            #region //operanten tasten 
            if (e.Key == Key.Add) // wenn Numpad +, dann führe aus
            {
                sender = /*button: */plus;
                op_click(sender, e);
            }
            if (e.Key == Key.Subtract) // wenn Numpad -, dann führe aus
            {
                sender = /*button: */minus;
                op_click(sender, e);
            }
            if (e.Key == Key.Divide) // wenn Numpad *, dann führe aus
            {
                sender = /*button: */geteilt;
                op_click(sender, e);
            }
            if (e.Key == Key.Multiply) // wenn Numpad /, dann führe aus
            {
                sender = /*button: */multiplikation;
                op_click(sender, e);
            }
            if (e.Key == Key.Return) // wenn Numpad ENTER, dann führe aus =
            {
                sender = /*button: */gleich;
                Gleich_Click(sender, e);
            } //Edit: irgendwas funktioniert mit dem erneuten ENTER und dem CE (löschen der textBox) nicht
            #endregion //operanten tasten

            #region //sonderzeichen wie das komma
            if (e.Key == Key.Decimal) // wenn Numpad Komma, dann führe aus ---- da brauchen wir ein neues event - wie kommst du darauf? wdie soll doch nur springen wenn die taste gedrükt wird :) und das macht sie
            {
                sender = /*button: */komma;
                Komma_Click(sender, e);
            } //das komma funktioniert bei der übergabe nicht richtig und interpretiert es nicht mit der zahl (also dranhängen), sondern löscht (!) die zahl....
            if (e.Key == Key.Delete) // wenn ENTF, dann führe CE aus
            {
                sender = /*button: */delete;
                Ce_Click_1(sender, e);
            }
            //backspace button funktionalität noch machen
            /*
            if (e.Key == Key.Back) // wenn ENTF, dann führe CE aus
            {
                sender = backspace;
                Backspace_Click(sender, e);
            }
        */

            #endregion // ende sonderzeichen
        }
        private void NeuesObjekterstellen(int x) // was ist das ??
        {
            x++;    // wir zählen eine zahl hoch mit der wir dann aussen den index der liste ansprechen
            speicher.Add(new Numbs());
        }


        private void C_Click(object sender, RoutedEventArgs e) // C - alles (auch objekte) löschen!
        {
            DezimalStelle = false; //urzustand
            hmmm = new Numbs();
            textbox1.Clear();
        }

        private void Vorzeichen_Click(object sender, RoutedEventArgs e)
        {
            /* - nach dem prinzip - aber wenn das +/- bei der 2. zahl ist, dann soll was anderes geschehen
            hmmm.Zahl1 *= -1;
            textbox1.Text = hmmm.Zahl1.ToString();
            */
        }

        /// event über window 
        /// // e.Key.toSTring();
        ///  methode zahl_click
        ///  https://stackoverflow.com/questions/7103360/how-to-get-pressed-char-from-system-windows-input-keyeventargs
        ///  /*
        ///   switch(e.Key)            {                case Key.D0: Berechne('0', null); break;                case Key.D1: Berechne('1', null); break;                case Key.D2: Berechne('2', null); break;                case Key.D3: Berechne('3', null); break;                case Key.D4: Berechne('4', null); break;                case Key.D5: Berechne('5', null); break;                case Key.D6: Berechne('6', null); break;                case Key.D7: Berechne('7', null); break;                case Key.D8: Berechne('8', null); break;                case Key.D9: Berechne('9', null); break;                case Key.NumPad0: Berechne('0', null); break;                case Key.NumPad1: Berechne('1', null); break;                case Key.NumPad2: Berechne('2', null); break;                case Key.NumPad3: Berechne('3', null); break;                case Key.NumPad4: Berechne('4', null); break;                case Key.NumPad5: Berechne('5', null); break;                case Key.NumPad6: Berechne('6', null); break; */
    }
}
