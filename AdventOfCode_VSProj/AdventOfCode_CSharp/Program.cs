using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run2015();

            //Run2016();

            Run2017();

            int[][][] x = new int[][][]
            {
                new int[][] { },
                new int[][] { new int[] {1, 1}, new int[] {1, 1}},
                new int[][] { new int[] {2, 2} },
                new int[][] { },
                new int[][] { new int[] {3,3}, new int[] {3,3}, new int[] { 3, 3 }, new int[] { 3, 3 } }
            };

            var xString = Newtonsoft.Json.JsonConvert.SerializeObject(x);

            string jsonString = x.ToString();
        }

        static void Run2015()
        {
        }

        static void Run2016()
        {
            // Day 1
            //AdventOfCode2016.Day1.RunDay1();

            // Day 2
            //AdventOfCode2016.Day2.RunDay2();

            // Day 3
            //AdventOfCode2016.Day3.RunDay3();

            // Day 4
            //AdventOfCode2016.Day4.RunDay4();

            // Day 5
            //AdventOfCode2016.Day5.RunDay5();

            // Day 6
            //AdventOfCode2016.Day6.RunDay6();

            // Day 7
            //AdventOfCode2016.Day7.RunDay7();
        }

        static void Run2017()
        {
            // Day 1
            AdventOfCode2017.Day1.RunDay1();
        }


    }
}
