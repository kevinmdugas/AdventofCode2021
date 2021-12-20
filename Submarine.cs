using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    internal class Submarine
    {
        protected SonarSweep sonar;
        protected Navigation nav;
        protected Diagnostic diag;

        public Submarine()
        {
            this.sonar = new SonarSweep();
            this.nav = new Navigation();
            this.diag = new Diagnostic();
        }

        static void Main(string[] args)
        {
            Submarine sub = new Submarine();
            string response;

            do
            {
                Console.WriteLine("\n\t| Submarine Main Menu |");
                Console.WriteLine("\t-----------------------");
                Console.WriteLine("\n1) Sonar Sweeper");
                Console.WriteLine("2) Navigation");
                Console.WriteLine("3) Run Diagnostics");

                Console.Write("\nSelect an option or (q) to exit: ");
                response = Console.ReadLine().ToLower();
                //response = response.ToLower();

                if (String.Compare(response, "1") == 0)
                    sub.sonar.TopMenu();
                else if (String.Compare(response, "2") == 0)
                    sub.nav.ReadCourse();
                else if (String.Compare(response, "3") == 0)
                    sub.diag.PowerConsumption();

            } while (String.Compare(response, "q") != 0);

        }
    }
}
