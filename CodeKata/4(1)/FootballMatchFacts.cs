using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace _4_1_
{
    public class FootballMatchFacts
    {
        [Fact]
        public void should_return_null_when_read_from_null_stream()
        {
            var matches = new DataReader(new MemoryStream()).Read();
            Assert.Equal(0, matches.Count);
        }

        [Fact]
        public void should_return_football_matches_with_one_element_when_data_is_valid()
        {
            var matches = new DataReader(new MemoryStream(Encoding.UTF8.GetBytes("1. Arsenal         38    26   9   3    79  -  36    87"))).Read();
            Assert.Equal(1,matches.Count);
            Assert.Equal("Arsenal", matches[0].Name);
            Assert.Equal(79, matches[0].Win);
            Assert.Equal(36, matches[0].Lose);
        }
    }

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
                var datas = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                matches.Add(new FootballMatch(datas[1], int.Parse(datas[6]), int.Parse(datas[8])));    
            }
            return matches;
        }
    }

    public class FootballMatch
    {
        public FootballMatch(string name, int win, int lose)
        {
            Name = name;
            Win = win;
            Lose = lose;
        }
        public string Name { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
    }
}
