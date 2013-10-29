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
            var matches = SetupMatches("");
            Assert.Equal(0, matches.Count);
        }

        [Fact]
        public void should_return_football_matches_with_one_element_when_data_is_valid()
        {
            var dataStr = "1. Arsenal         38    26   9   3    79  -  36    87";
            var matches = SetupMatches(dataStr);

            Assert.Equal(1,matches.Count);
            Assert.Equal("Arsenal", matches[0].Name);
            Assert.Equal(79, matches[0].Win);
            Assert.Equal(36, matches[0].Lose);
        }

        [Fact]
        public void should_be_able_to_return_multiple_matches_when_there_are_multiple_lines()
        {
            var dataStr = @" 1. Arsenal         38    26   9   3    79  -  36    87
    2. Liverpool       38    24   8   6    67  -  30    80
    3. Manchester_U    38    24   5   9    87  -  45    77";

            var matches = SetupMatches(dataStr);

            Assert.Equal(3, matches.Count);
            Assert.Equal("Arsenal", matches[0].Name);
            Assert.Equal(79, matches[0].Win);
            Assert.Equal(36, matches[0].Lose);

            Assert.Equal("Liverpool", matches[1].Name);
            Assert.Equal(67, matches[1].Win);
            Assert.Equal(30, matches[1].Lose);
        }

        [Fact]
        public void should_reject_when_data_is_invalid()
        {
            var matches = SetupMatches("Team            P     W    L   D    F      A     Pts");
            Assert.Equal(0, matches.Count);
        }

        [Fact]
        public void should_be_able_to_parse_footballmatch_when_there_is_valid_data_and_invalid_data()
        {
            var matches = SetupMatches(@"
                   Team            P     W    L   D    F      A     Pts
    1. Arsenal         38    26   9   3    79  -  36    87
    2. Liverpool       38    24   8   6    67  -  30    80
    3. Manchester_U    38    24   5   9    87  -  45    77
            ");

            Assert.Equal(3, matches.Count);

            Assert.Equal("Arsenal", matches[0].Name);
            Assert.Equal(79, matches[0].Win);
            Assert.Equal(36, matches[0].Lose);

            Assert.Equal("Liverpool", matches[1].Name);
            Assert.Equal(67, matches[1].Win);
            Assert.Equal(30, matches[1].Lose);

            Assert.Equal("Manchester_U", matches[2].Name);
            Assert.Equal(87, matches[2].Win);
            Assert.Equal(45, matches[2].Lose);
        }

        [Fact]
        public void should_return_null_when_there_is_no_element_to_compare()
        {
            FootballMatch match = new DataComparor().Compare(new List<FootballMatch>());
            Assert.Equal(null, match);
        }

        [Fact]
        public void should_return_the_only_match_when_there_is_only_one_element_to_compare()
        {
            var matches = new List<FootballMatch>();
            matches.Add(new FootballMatch("Arsenal", 3,6));
            var comparedMatches = new DataComparor().Compare(matches);

            Assert.Equal("Arsenal", comparedMatches.Name);
            Assert.Equal(3, comparedMatches.Win);
            Assert.Equal(6, comparedMatches.Lose);
        }

        private static IList<FootballMatch> SetupMatches(string dataStr)
        {
            return new DataReader(
                new MemoryStream(Encoding.UTF8.GetBytes(dataStr))).Read();
        }
    }
}
