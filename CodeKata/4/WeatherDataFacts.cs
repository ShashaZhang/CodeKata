using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        }
    }

    public class DataReader
    {
        public IList<Temprature> Read(Stream stream)
        {
            var line = new StreamReader(stream).ReadLine();
            if(line != null)
                return new List<Temprature>(){ new Temprature(line)};
            return new List<Temprature>();
        }
    }

    public class Temprature
    {
        public Temprature(string line)
        {
            
        }
    }
}