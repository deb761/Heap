using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid grid;
            using (StreamReader input = new StreamReader("TestCase1.txt"))
            {
                string line = input.ReadLine();
                int nCases = int.Parse(line);

                for (int idx = 0; idx < nCases; idx++)
                {
                    grid = new Grid(input);
                    int start = int.Parse(input.ReadLine());
                    grid.FindShortest(start);
                }
            }
        }
    }
}
