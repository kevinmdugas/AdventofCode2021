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

        public Submarine()
        {
            this.sonar = new SonarSweep();
            this.nav = new Navigation();
        }

        static void Main(string[] args)
        {
            Submarine sub = new Submarine();
            sub.sonar.TopMenu();
            sub.nav.ReadCourse();
        }
    }
}
