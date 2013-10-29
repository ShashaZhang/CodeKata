using System;

namespace _4_1_
{
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

        public static FootballMatch Create(string line)
        {
            var datas = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var match = new FootballMatch(datas[1], Int32.Parse(datas[6]), Int32.Parse(datas[8]));
                return match;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetSpread()
        {
            return Win - Lose;
        }
    }
}