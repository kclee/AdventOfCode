using System.Collections.Generic;
using System.IO;

namespace AdventOfCode_CSharp.Helper
{
    class InputHandler
    {
        public static List<string[]> GetLinesFromString(string inputString)
        {
            /// eg, input = @"1 2 3
            ///               4 5 6
            ///               7 8 9"
            ///
            ///      return = List [ ["1", "2", "3"], ["4", "5", "6"], ["7", "8", "9"]]

            StringReader stringReader = new StringReader(inputString);
            List<string[]> lines = new List<string[]>();
            while (true)
            {
                string line = stringReader.ReadLine();
                if (line != null)
                {
                    lines.Add(line.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {
                    break;
                }
            }
            return lines;
        }

        public static string[] GetSplitSubstringsWithSeparators(string originalString, string[] separators)
        {
            return originalString.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
