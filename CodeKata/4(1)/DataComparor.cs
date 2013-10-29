using System.Collections.Generic;

namespace _4_1_
{
    public class DataComparor
    {
        public FootballMatch Compare(IList<FootballMatch> footballMatches)
        {
            if(footballMatches.Count == 0)
                return null;
            
            var minSpread = footballMatches[0];
            foreach (var match in footballMatches)
            {
                if ((minSpread.Win - minSpread.Lose) > (match.Win - match.Lose))
                    minSpread = match;
            }
            return minSpread;
        }
    }
}