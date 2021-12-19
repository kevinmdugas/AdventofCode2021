using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventofCode
{
    internal class Diagnostic
    {
        protected uint gamma;
        protected uint epsilon;
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

            if ((line = this.sr.ReadLine()) == null)
            {
                Console.WriteLine("No data to read");
                return;
            }

            int sz = line.Length;                   // Valid data size is dependent on first data
            char[] chars = line.ToCharArray();      // Convert each string to a char array
            int[] count = new int[sz];              // Count the number of ones in each position
            int n = 1;                              // Count the number of data entries

            // Initialize array
            for (int i = 0; i < sz; i++)
                count[i] = chars[i] - 48; 
            
            // Increment each instance of 1 in each position
            while ((line = this.sr.ReadLine()) != null)
            {
                // Check for data with different lengths
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
            int k = sz - 1;

            for (int i = 0; i < sz; i++)
            {
                if (count[i] > n)
                    this.gamma += (uint) Math.Pow(2, k);
                else
                    this.epsilon += (uint) Math.Pow(2, k);
                k--;
            }

            Console.WriteLine("Power consumption: {0} units", this.gamma * this.epsilon);
        }

    }
}
