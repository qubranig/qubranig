using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input; //für die tasten Funktionalität
using System.Timers;
/// <summary>
/// to do :
/// -liste von zahlen und opereratoren -> brauchen wir andere andere methden (listezahlen[x] , operator[i] ... 
/// -liste von objekten für speicher implementierung
/// -methoden auslagern in eine statische klasse --- 
///
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
        public int Dezimalstelle { get; set; } //das nix gut
        public string Operant { get; set; }
        public List<string>listeoperanten { get; set; }

     }


    public partial class MainWindow : Window
    {//globale variablen
        List<Numbs> speicher = new List<Numbs>();
        bool operant = false;
        bool BoolDezimalStelle = false;
        double zahl1 = 0;//nur platzhalter zum testen 
        double zahl2 = 0;
        Numbs hmmm = new Numbs();
        int dezimalstelle=0;
        

        public void Aniläuftzumbus()
        {
            string[] ani = new string[] { "     .", "|   . ", " |   .  ", "| |  .   ", "| | .    ", "| |    ", "|.|     " };
            while (true)
            {
                int i = 0;
                for (i = 0; i < ani.Length; i++)
                {

                    animeerzion.Text = ani[i];
                }

            }
        }

        public MainWindow()
        {
            Numbs hmmm = new Numbs();
            InitializeComponent();
            textbox1.IsReadOnly = true;

            Task SpecialTaskForce = new Task(Aniläuftzumbus);
            SpecialTaskForce.Start();




            //animeerzion.Text = Aniläuftzumbus();
            //Timer TimerFürAni = new Timer(1000);
            //TimerFürAni.Elapsed+=Aniläuftzumbus;
            //TimerFürAni.AutoReset = true;
            //TimerFürAni.Enabled = true;

        }//endemain
   
        //event für die Zahleneingabe
        public void zahl_click(object sender, RoutedEventArgs e)//check:)
        {
            if (BoolDezimalStelle) //funktionalität für das komma und interpretation als dezimalstelle
            { // später müssen wir das zeichen ersetzen mit double.Parse(TextBox1.Text.Replace('.', ',') wie meinst
                double Zwsp=0;
                if (!operant)
                {
                        Zwsp = (Convert.ToInt32((sender as System.Windows.Controls.Button).Content));
                    dezimalstelle++;
                    hmmm.Zahl1 =hmmm.Zahl1+ Zwsp/(Math.Pow(10,dezimalstelle));

                    textbox1.Text = hmmm.Zahl1.ToString();
                }
                else
                {
                    Zwsp = (Convert.ToInt32((sender as System.Windows.Controls.Button).Content));
                    dezimalstelle++;
                    hmmm.Zahl2 = hmmm.Zahl2 + Zwsp / (Math.Pow(10, dezimalstelle));

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

        //event für die eingabe eine s operators
        public void op_click(object sender, RoutedEventArgs e) //operanten taste
        {
            dezimalstelle = 0;
            BoolDezimalStelle = false;
            operant = true;
            hmmm.Operant = Convert.ToString((sender as System.Windows.Controls.Button).Content);

            ergebnis();
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }

    
        //event für ergebnis (enter taste)
        private void Gleich_Click(object sender, RoutedEventArgs e)
        {
            ergebnis();
            dezimalstelle = 0;
            operant = false;
        }
        //TODO
        //wie auslagern ?  Die textboxen !!!  
        private void ergebnis() //ErgebnisMethode
        {
            switch (hmmm.Operant)
            {
                case "+":
                    Operanten.Addition(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "-":
                    Operanten.Subtraktion(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "*":
                    Operanten.Multiplikation(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "/":
                    Operanten.Division(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;

            }
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }
        //event ce
        private void Ce_Click_1(object sender, RoutedEventArgs e)
        {
            textbox1.Clear();
            hmmm.Zahl1 = 0;
            hmmm.Zahl2 = 0;
            dezimalstelle = 0;
            hmmm.Ergebniss = 0;
            hmmm.Operant = "";
        }
        //event komma
        private void Komma_Click(object sender, RoutedEventArgs e)
        {
            BoolDezimalStelle = true; 
            if (BoolDezimalStelle)
            {
            textbox1.Text += "," ;//display
            }
        }
        //!!!event numpad support
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
            if (e.Key == Key.Enter) // wenn Numpad ENTER, dann führe aus =
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
        //event c
        private void C_Click(object sender, RoutedEventArgs e) // C - alles (auch objekte) löschen!
        {
            BoolDezimalStelle = false; //urzustand
            hmmm = new Numbs();
            textbox1.Clear();
        }
        //todo
        private void Vorzeichen_Click(object sender, RoutedEventArgs e)
        {
            
        }

       
    }
}
