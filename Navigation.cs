using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    internal class Navigation
    {
        protected int depth;
        protected int horiz;
        protected StreamReader sr;

        public Navigation()
        {
            this.depth = this.horiz = 0;

            try
            {
                string file = "../../../NavigationInput.txt";
                this.sr = new StreamReader(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("The navigation file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        
        public void ReadCourse()
        {
            string line;
            string[] substrings;

            while((line = this.sr.ReadLine()) != null)
            {
                substrings = line.Split(' ');

                if (substrings[0] == "forward")
                    this.horiz += Int16.Parse(substrings[1]);

                else if (substrings[0] == "up")
                    this.depth -= Int16.Parse(substrings[1]);

                else if (substrings[0] == "down")
                    this.depth += Int16.Parse(substrings[1]);

                else
                    Console.WriteLine("\nInvalid entry.");
            }

            Console.WriteLine("\n~~ Final horizontal position: {0} units ~~", this.horiz);
            Console.WriteLine("~~ Final depth: {0} units ~~", this.depth);
            Console.WriteLine("~~ Final product: {0} units^2 ~~", this.depth * this.horiz);
        }
        
    }
    

}
