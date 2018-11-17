using System;
using System.Collections.Generic;

namespace PG.AP.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var intArray = new List<int>();
            foreach(string arg in args)
            {
                int intValue = 0;
                if(int.TryParse(arg, out intValue))
                {
                    intArray.Add(intValue);
                }
            }
            var artProg = new PG.AP.Library.ArtProgObject();
            var missingInt = artProg.findTheMissing(intArray.ToArray());
            var result = missingInt == null ? "No missing item found" : "Missing item = " + missingInt.ToString();
        }
    }
}
