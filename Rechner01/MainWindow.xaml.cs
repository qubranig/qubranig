using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Rechner01
{
    class Numbs
    {
        public double Zahl1 { get; set; }
        public double Zahl2 { get; set; }

        public double Ergebniss { get; set; }

        public string Operant { get; set; }

    }

    public partial class MainWindow : Window
    {
        List<Numbs> speicher = new List<Numbs>();
        bool operant = false;
        bool ende = false;
        double zahl1 = 0;
        double zahl2 = 0;
        Numbs hmmm = new Numbs();


        public MainWindow()
        {
            Numbs unclever = new Numbs();
            InitializeComponent();

            hmmm.Zahl1 = 2;
            hmmm.Zahl2 = 3;
            hmmm.Ergebniss = 4;


        }//endemain


        public void zahl_click(object sender, RoutedEventArgs e)
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

            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }

        public void op_click(object sender, RoutedEventArgs e)
        {
            operant = true;
            hmmm.Operant = Convert.ToString((sender as System.Windows.Controls.Button).Content);
            opzeichen.Text = hmmm.Operant.ToString();
            
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }

    
  
        private void Gleich_Click(object sender, RoutedEventArgs e)
        {
            ergebnis();
            operant = false;
        }
        private void ergebnis()
        {
            switch (hmmm.Operant)
            {
                case "+":
                    addition(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Zahl1.ToString();
                    break;
                case "-":
                    opas2.methodetest(hmmm);
                    textbox1.Clear();
                    textbox1.Text = hmmm.Ergebniss.ToString();

                    break;

            }
            string stringspeicher = hmmm.Zahl1 + "\n" + hmmm.Zahl2 + "\n" + hmmm.Ergebniss;
            textboxspeicher.Text = stringspeicher;
        }
        private void addition(Numbs numbs)
        {
            if (numbs.Zahl2 != 0)
            {
                numbs.Ergebniss = numbs.Zahl1 + numbs.Zahl2;
                numbs.Zahl1 = numbs.Zahl1 + numbs.Zahl2;
                numbs.Zahl2 =0;
            }
        }
        static void hallo(int r)
        {
           ////
        }
        private void Ce_Click_1(object sender, RoutedEventArgs e)
        {
            textbox1.Clear();
            hmmm.Zahl1 = 0;
            hmmm.Zahl2 = 0;
            hmmm.Ergebniss = 0;
            hmmm.Operant = "";
        }

    
    }
}
