using System;
using System.Collections.Generic;
using System.IO;
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
    }

    public class DataReader
    {
        public IList<Temprature> Read(Stream stream)
        {
            return new List<Temprature>();
        }
    }

    public class Temprature
    {
    }
}