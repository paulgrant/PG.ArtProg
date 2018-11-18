using System;
using System.Collections.Generic;

namespace PG.AP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter your array items separated by commas.");
            var intArray = new List<int>();
            string foo = System.Console.ReadLine();
            string[] tokens = foo.Split(",");
            foreach (string token in tokens)
            {
                int intValue = 0;
                if(int.TryParse(token, out intValue))
                {
                    intArray.Add(intValue);
                }
            }
            var artProg = new PG.AP.Library.ArtProgObject();
            var missingInt = artProg.findTheMissing(intArray.ToArray());
            var result = missingInt == null ? "No missing item found" : "Missing item = " + string.Join(",", missingInt);
            System.Console.WriteLine(result);
        }
    }
}
