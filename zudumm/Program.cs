using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zudumm
{
    class Testklasse
    {
        private int zahl1 {get; set; }
        public int gekapselte_zahl1 { get => zahl1; set => zahl1 = value; }

        public Testklasse(int a)
            {
            zahl1 = a;
            }
        public Testklasse()
        {
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Testklasse a = new Testklasse();
            a.gekapselte_zahl1 = 1;
            Testklasse b = new Testklasse(2);
            

            Console.WriteLine(b.gekapselte_zahl1);
            Console.WriteLine(a.gekapselte_zahl1);
            Console.ReadKey();
        }
    }
}
