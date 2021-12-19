using System;
using System.IO;

/*
    This class contains two methods that solve parts 1 and 2 of
    Day 1: Sonar Sweep.
        https://adventofcode.com/2021/day/1
    It uses the included SonarSweepData.txt but could also work
    with a different specified file.
*/

namespace AdventofCode
{
    class SonarSweep
    {
        StreamReader sr;
        string file;

        public SonarSweep()
        {
            try
            {
                this.file = "../../../SonarSweepData.txt";
                this.sr = new StreamReader(file);
            }
            catch (Exception e)
            {
                Console.WriteLine("The sonar sweep file could not be read:");
                Console.WriteLine(e.Message);
            }
            
        }

        // Menu interface that allows the user to choose between counting
        // the number of individual depth increases in sequential data items
        // or the number of depth increases between sequential intervals of data.
        public void TopMenu()
        {
            int option = 0;
            string response;

            do
            {
                Console.WriteLine("\n\t~~ Sonar Sweep Menu ~~\n");
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
                    int count = this.IndDepthIncrease();

                    if (count == -1)
                        Console.WriteLine("No data was read");
                    else
                        Console.WriteLine("\n~~ Number of depth increases: {0} ~~", count);

                }

                //count increases between windows of specified size.
                //uses default window size of 3, can implement user input to define any size
                else if (option == 2)
                {
                    int count = this.WindowDepthIncrease(3);

                    if (count == -1)
                        Console.WriteLine("Not enough data to fill a window of the specified size");
                    else
                        Console.WriteLine("\n~~ Number of depth increases: {0} ~~", count);

                }

                else if (option == 3)
                    return;

                else
                {
                    Console.WriteLine("Invalid selection");
                    continue;
                }

                this.sr.DiscardBufferedData();
                this.sr.Close();
                this.sr = new StreamReader(this.file);

            } while (true);
        }

        //Count the number of depth increases between sequential data points
        //Return the count or error if no data is read
        public int IndDepthIncrease()
        {
            string line = new string(this.sr.ReadLine());
            if (line != null)
            {
                int count = 0;
                int prev;
                int cur = Int16.Parse(line);

                while ((line = this.sr.ReadLine()) != null)
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

        //Count the number of aggregate depth increases between data intervals of 
        // the passed in size. Return error if there isn't enough data to fill a single
        // interval.
        public int WindowDepthIncrease(int sz)
        {
            string line;
            int[] data = new int[sz];
            int cur = 0;

            //collect first window data
            for (int i = 0; i < sz; ++i)
            {
                //could not fill first window
                if ((line = this.sr.ReadLine()) == null)
                    return -1;

                data[i] = Int16.Parse(line);
                cur += data[i];
            }

            int prev;
            int count = 0;

            while ((line = this.sr.ReadLine()) != null)
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



