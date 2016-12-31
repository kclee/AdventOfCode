using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_CSharp.AdventOfCode2016
{
    class Day5
    {
        readonly static string input_1 = "abc"; // Part 1: 18f47a30, Part 2: 05ace8e3
        readonly static string input_2 = "ojvtpuvg"; // Part 1: 4543c154, Part 2: 1050cbbd

        public static void RunDay5()
        {
            string input = input_1;
            string password = "";
            MD5 md5Hash = MD5.Create();

            // Part 1
            password = ResolvePasswordPartOne(md5Hash, input);

            // Part 2
            //password = ResolvePasswordPartTwo(md5Hash, input);

            System.Diagnostics.Debug.WriteLine("Password: " + password);
        }

        static string ResolvePasswordPartOne(MD5 md5Hash, string input)
        {
            string hashedInput = "";
            string passwordResult = "";

            for (int i = 0; i < int.MaxValue; ++i)
            {
                hashedInput = GetMd5Hash(md5Hash, input + i.ToString());

                if (hashedInput.StartsWith("00000"))
                {
                    passwordResult += hashedInput[5];
                    System.Diagnostics.Debug.WriteLine("Password: " + passwordResult + " | " + i); // see the password grow
                }

                if (passwordResult.Length >= 8)
                {
                    break;
                }
            }
            return passwordResult;
        }

        static string ResolvePasswordPartTwo(MD5 md5Hash, string input)
        {
            string hashedInput = "";
            string passwordResult = "--------";

            for (int i = 0; i < int.MaxValue; ++i)
            {
                hashedInput = GetMd5Hash(md5Hash, input + i.ToString());

                if (hashedInput.StartsWith("00000"))
                {
                    int inserttedIndex;
                    bool validIndexNumber = int.TryParse(hashedInput[5].ToString(), out inserttedIndex);
                    char inserttedChar = hashedInput[6];

                    if (validIndexNumber && inserttedIndex < passwordResult.Length && passwordResult[inserttedIndex].Equals('-'))
                    {
                        // Edit the password string. Replace dash - with correct character
                        char[] passwordTemp = passwordResult.ToCharArray();
                        passwordTemp[inserttedIndex] = inserttedChar;
                        passwordResult = new string(passwordTemp);

                        System.Diagnostics.Debug.WriteLine("Password: " + passwordResult + " | " + i); // see the password grow
                    }
                }

                // Complete when no dash '-' in the result
                if (passwordResult.IndexOf('-') == -1)
                {
                    break;
                }
            }
            return passwordResult;
        }
        
        /// <summary>
        /// Source from:
        /// https://msdn.microsoft.com/en-us/library/system.security.cryptography.md5%28v=vs.110%29.aspx
        /// </summary>
        static string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] inputToByte = Encoding.UTF8.GetBytes(input);

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(inputToByte);

            // Only transform byte to hex when it begin with "0000"
            if(data[0] == byte.MinValue && data[1] == byte.MinValue)
            { 
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
            return "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; //return something not begin with "00000" if skipped transforming byte to hex
        }
    }
}
