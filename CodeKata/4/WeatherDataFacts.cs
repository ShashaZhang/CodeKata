using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace _4
{
    public class WeatherDataFacts
    {
        [Fact]
        public void should_return_empty_list_when_data_is_empty()
        {
            IList<Temprature> tempratures = new DataReader().Read(new MemoryStream());
            Assert.Equal(0, tempratures.Count);
        }

        [Fact]
        public void should_return_tempratures_with_one_element_when_data_is_validated()
        {
            var tempratures = new DataReader().Read(new MemoryStream(Encoding.UTF8.GetBytes("1 23 8")));
            Assert.Equal(1, tempratures.Count);
            Assert.Equal(1, tempratures[0].Day);
            Assert.Equal(23.0, tempratures[0].Max);
            Assert.Equal(8.0, tempratures[0].Min);
        }

        [Fact]
        public void should_reject_invalid_data()
        {
            var tempratures = new DataReader().Read(new MemoryStream(Encoding.UTF8.GetBytes("a bc d")));
            Assert.Equal(0, tempratures.Count);
        }

        [Fact]
        public void should_return_tempratures_when_data_is_validated()
        {
            var tempratures = new DataReader().Read(new MemoryStream(Encoding.UTF8.GetBytes("1 23 8\n2 34 1")));
            Assert.Equal(2, tempratures.Count);
        }
    }

    public class DataReader
    {
        public IList<Temprature> Read(Stream stream)
        {
            var reader = new StreamReader(stream);
            var line = reader.ReadLine();
            var tempratures = new List<Temprature>();
            while (line != null)
            {
                if (line != null)
                {
                    Temprature temprature = Temprature.Create(line);
                    if (temprature != null) tempratures.Add(temprature);
                }
                line = reader.ReadLine();
            }
            return tempratures;
        }
    }

    public class Temprature
    {
        public int Day;
        public double Max;
        public double Min;

        public Temprature(string line)
        {
            var arr = line.Split(' ');
            Day = Int32.Parse(arr[0]);
            Max = Double.Parse(arr[1]);
            Min = Double.Parse(arr[2]);
        }

        public static Temprature Create(string line)
        {
            Temprature temprature = null;
            if (Regex.Match(line,@"\d+ \d+(.\d+)? \d+(.\d+)?").Success) temprature = new Temprature(line);
            return temprature;
        }
    }
}