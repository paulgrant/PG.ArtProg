using System;
using System.Linq;
using System.Collections.Generic;

namespace PG.AP.Library
{
    public class ArtProgObject : IArtProgObject
    {
        public ArtProgObject()
        {

        }

        public int[] findTheMissing(int[] values)
        {
            if(values == null || values.Length < 1)
            {
                return null;
            }

            var parsedList = parseList(values);

            var missingList = findMissingList(parsedList);
            return missingList;
        }

        private Dictionary<int, List<int>> parseList(int[] values)
        {
            if (values == null || values.Length < 1)
            {
                return null;
            }

            var returnList = new Dictionary<int, List<int>>();
            for(var i = 0; i < values.Length; i++)
            {
                var difference = 0;
                if (i > 0)
                {
                    difference = values[i] - values[i - 1];
                }
                else
                {
                    continue;
                }

                if(returnList.ContainsKey(difference))
                {
                    returnList[difference].Add(values[i]);
                }
                else
                {
                    returnList.Add(difference, new List<int> { values[i] });
                }
            }
            return returnList;
        }

        private int[] findMissingList(Dictionary<int, List<int>> parsedList)
        {
            if (parsedList.Count == 1)
            {
                return null;
            }

            //find the list with the smallest number of items.
            var missingKVP = parsedList.OrderBy(x => x.Value.Count).First();
            var normalKVP = parsedList.OrderByDescending(x => x.Value.Count).First();

            if (missingKVP.Value == null || missingKVP.Value.Count==0) return null;
            for(var i = 0; i < missingKVP.Value.Count(); i++)
            {
                missingKVP.Value[i] = missingKVP.Value[i] - normalKVP.Key;
            }
        
            return missingKVP.Value.ToArray();
        }
    }
}
