using System.Collections.Generic;

namespace _4_1_
{
    public class DataComparor
    {
        public FootballMatch Compare(IList<FootballMatch> footballMatches)
        {
            if (footballMatches.Count != 0)
                return footballMatches[0];
            return null;
        }
    }
}