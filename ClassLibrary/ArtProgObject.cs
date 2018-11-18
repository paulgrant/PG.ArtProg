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

            var missingList = findMissingList(parsedList, values);
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

        private int[] findMissingList(Dictionary<int, List<int>> parsedList, int[] originalList)
        {
            if (parsedList.Count == 1)
            {
                return null;
            }

            //Tn = a + (n - 1) d
            var commonDifference = parsedList.OrderByDescending(x => x.Value.Count).First().Key;
            var nthValue = originalList[0];
            var endValue = originalList[originalList.Length-1];
            var index = 1;
            var missingList =  new List<int>();
            var ascendingList = nthValue < endValue;

            while (ascendingList ? nthValue < endValue : nthValue > endValue)
            {
                nthValue = nthValue + commonDifference;
                if (nthValue == originalList[index])
                {
                    index++;
                }
                else
                {
                    missingList.Add(nthValue);
                }
            }
            return missingList.ToArray();
        }

        private object List<T>()
        {
            throw new NotImplementedException();
        }
    }
}
