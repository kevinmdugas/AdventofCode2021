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
            //sub.sonar.TopMenu();
            //sub.nav.ReadCourse();
            sub.diag.BinaryDiagnostic();

        }
    }
}
