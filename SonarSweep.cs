using System;
using System.IO;


namespace AdventofCode
{
    class SonarSweep
    {
        static void Main(string[] args)
        {
            try
            {
                string file = "../../../SonarSweepData.txt";
                using (StreamReader sr = new StreamReader(file))
                {
                    SonarSweep sweeper = new SonarSweep();
                    sweeper.TopMenu(sr, file);
                    sr.Close();
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            
        }

        void TopMenu(StreamReader sr, string file)
        {
            int option = 0;
            string response;

            do
            {
                Console.WriteLine("\nSonar Sweep Menu\n");
                Console.WriteLine("1) Count individual depth increases");
                Console.WriteLine("2) Count depth window increases");
                Console.WriteLine("3) Quit");

                Console.Write("\nYour selection: ");
                if((response = Console.ReadLine()) != null)
                {
                    option = Int16.Parse(response);
                }

                //count individual depth increases
                if (option == 1)
                {
                    int count = this.IndDepthIncrease(sr);

                    if (count == -1)
                        Console.WriteLine("No data was read");
                    else
                        Console.WriteLine("\n~~ Number of depth increases: {0} ~~", count);

                }

                //count increases between windows of specified size.
                //uses default window size of 3, can implement user input to define any size
                else if (option == 2)
                {
                    int count = this.WindowDepthIncrease(sr, 3);

                    if (count == -1)
                        Console.WriteLine("Not enough data to fill a window of the specified size");
                    else
                        Console.WriteLine("\n~~ Number of depth increases: {0} ~~", count);

                }

                //quit
                else if (option == 3)
                {
                    return;
                }

                else
                {
                    Console.WriteLine("Invalid selection");
                    continue;
                }

                sr.DiscardBufferedData();
                sr.Close();
                sr = new StreamReader(file);

            } while (true);
        }

        int IndDepthIncrease(StreamReader sr)
        {
            string line;
            if ((line = sr.ReadLine()) != null)
            {
                int count = 0;
                int prev;
                int cur = Int16.Parse(line);

                while ((line = sr.ReadLine()) != null)
                {
                    prev = cur;
                    cur = Int16.Parse(line);
                    if (cur > prev)
                        count++;
                }
                return count;
            }
            else
            {
                return -1;
            }

        }

        int WindowDepthIncrease(StreamReader sr, int sz)
        {
            string line;
            int[] data = new int[sz];
            int cur = 0;

            //collect first window data
            for (int i = 0; i < sz; ++i)
            {
                //could not fill first window
                if ((line = sr.ReadLine()) == null)
                    return -1;

                data[i] = Int16.Parse(line);
                cur += data[i];
            }

            int prev;
            int count = 0;

            while ((line = sr.ReadLine()) != null)
            {
                prev = cur;
                cur -= data[0];

                //shift data to the left
                for (int i = 0; i < sz - 1; i++)
                    data[i] = data[i + 1];

                //assign new data and sum it
                data[sz - 1] = Int16.Parse(line);
                cur += data[sz - 1];

                if (cur > prev)
                    count++;
            }

            return count;
        }
    }
}



