using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    internal class Diagnostic
    {
        protected int gamma;
        protected int epsilon;
        protected StreamReader sr;

        public Diagnostic()
        {
            this.gamma = this.epsilon = 0;

            try
            {
                string file = "../../../BinaryDiagnosticInput.txt";
                this.sr = new StreamReader(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("The diagnostic file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void BinaryDiagnostic()
        {
            string line;

            if((line = this.sr.ReadLine()) != null)
            {
                int sz = line.Length;
                char[] chars = line.ToCharArray();
                int[] count = new int[sz];
                int n = 1;

                // Initialize array
                for (int i = 0; i < sz; i++)
                    count[i] = chars[i] - 48; 
                
                while ((line = this.sr.ReadLine()) != null)
                {
                    if (line.Length != sz)
                    {
                        Console.WriteLine("Invalid entry");
                        continue;
                    }

                    chars = line.ToCharArray();
                    n++;

                    for (int i = 0; i < sz; i++)
                        count[i] += chars[i] - 48;
                }

                n = n / 2;
                int k = sz;

                for (int i = 0; i < sz; i++)
                {
                    if (count[i] > n)
                        this.gamma += (int) Math.Pow(2, k);
                    k--;
                }

                this.epsilon = ~this.gamma;
                Console.WriteLine("gamma = {0}, epsilon = {1}", this.gamma, this.epsilon);
            }
            else
            {
                Console.WriteLine("No data to read");
            }
        }

    }
}
