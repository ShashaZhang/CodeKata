using System.Collections.Generic;
using System.IO;

namespace _4_1_
{
    public class DataReader
    {
        private Stream stream;

        public DataReader(Stream stream)
        {
            this.stream = stream;
        }

        public IList<FootballMatch> Read()
        {
            var matches = new List<FootballMatch>();
            var line = new StreamReader(stream).ReadLine();
            if (line != null)
            {
                var match = FootballMatch.Create(line);
                matches.Add(match);
            }
            return matches;
        }
    }
}