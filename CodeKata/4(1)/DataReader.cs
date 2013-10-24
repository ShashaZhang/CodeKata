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
            var reader = new StreamReader(stream);

            var line = reader.ReadLine();
            while (line != null)
            {
                var match = FootballMatch.Create(line);
                if(match != null)
                    matches.Add(match);
                line = reader.ReadLine();
            }

            return matches;
        }
    }
}