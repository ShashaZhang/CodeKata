using System;
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

        [Fact]
        public void should_be_able_to_return_multiple_matches_when_there_are_multiple_lines()
        {
            var matches = new DataReader(new MemoryStream(Encoding.UTF8.GetBytes(@" 1. Arsenal         38    26   9   3    79  -  36    87
    2. Liverpool       38    24   8   6    67  -  30    80
    3. Manchester_U    38    24   5   9    87  -  45    77"))).Read();

            Assert.Equal(3, matches.Count);
            Assert.Equal("Arsenal", matches[0].Name);
            Assert.Equal(79, matches[0].Win);
            Assert.Equal(36, matches[0].Lose);

            Assert.Equal("Liverpool", matches[1].Name);
            Assert.Equal(67, matches[1].Win);
            Assert.Equal(30, matches[1].Lose);
        }
    }
}
