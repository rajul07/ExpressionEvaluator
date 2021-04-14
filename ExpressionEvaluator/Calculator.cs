

#region "Imports"
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

#region "namespace"
namespace ExpressionEvaluator
{
    /// <summary>
    /// Calculation Class
    /// </summary>
    public class Calculator
    {
        public static Dictionary<long, string> input;
        public static Dictionary<long, long> Result;

        /// <summary>
        /// Main Method
        /// </summary> 
        public static void Main(string[] args)
        {
            input = new Dictionary<long, string>();
            Result = new Dictionary<long, long>();
            string[] lines = File.ReadAllLines("input.txt");
            input = lines.Select(line => line.Split(':')).ToDictionary(keyValue => Convert.ToInt64(keyValue[0]), bits => bits[1]);
            var key = input.Take(1).Select(d => d.Key).First();
            var result = CalculateFinalResult(key);
            Console.WriteLine("The Overall Result is: " + result);
            Console.ReadLine();
        }

        /// <summary>
        /// Method to CalculateFinalResult from initial key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long CalculateFinalResult(long key)
        {
            long result = 0;
            //Looking into Pre Calculated Value
            if (Result.ContainsKey(key))
            {
                return Result[key];
            }
            if (input.ContainsKey(key))
            {
                string s = input[key];
                string[] sArr = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                if (sArr[0].Equals("Add"))// if the operation is Add
                {
                    for (int i = 1; i < sArr.Length; i++)
                    {
                        result += CalculateFinalResult(Int64.Parse(sArr[i]));
                    }
                }
                else if (sArr[0].Equals("Mult"))// if the operation is Mult
                {
                    result = 1;
                    for (int i = 1; i < sArr.Length; i++)
                    {
                        result *= CalculateFinalResult(Int64.Parse(sArr[i]));
                    }
                }
                else
                {
                    result = Int64.Parse(sArr[1]);
                }
                Result[key] = result;  // saving the Value
            }
            return result;
        }
    }
}
#endregion