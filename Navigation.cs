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
            this.depth = 0;
            this.horiz = 0;

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
        
        public int ReadCourse()
        {
            string line;
            string[] substrings;
            while((line = this.sr.ReadLine()) != null)
            {
                substrings = line.Split(' ');
                foreach (var substring in substrings)
                    Console.WriteLine(substring);
            }
            return 0;
        }
        
    }
    

}
