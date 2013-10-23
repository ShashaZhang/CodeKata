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
        public void should_parse_to_right_temprature()
        {
            var tempratures = new DataReader().Read(
                new MemoryStream(
                    Encoding.UTF8.GetBytes(
                        "9  86    32*   59       6  61.5       0.00         240  7.6 220  12  6.0  78 46 1018.6")));
            Assert.Equal(9, tempratures[0].Day);
            Assert.Equal(86, tempratures[0].Max);
            Assert.Equal(32, tempratures[0].Min);
        }

        [Fact]
        public void should_return_tempratures_when_data_is_validated()
        {
            var tempratures = new DataReader().Read(new MemoryStream(Encoding.UTF8.GetBytes("1 23 8\n2 34 1")));
            Assert.Equal(2, tempratures.Count);
        }

		[Fact]
		public void should_return_null_when_there_is_no_element(){
			var tempratures = new Temprature[] { };
			var minTemprature = new DataComparer ().GetMin(tempratures);
			Assert.Equal (null,minTemprature);
		}

		[Fact]
		public void should_return_the_only_element_when_there_is_only_one_and_only_valid_element(){
			var tempratures = new[] { new Temprature ("1 23 8") };
			var minTemprature = new DataComparer ().GetMin (tempratures);
			Assert.Equal (tempratures [0].Day, minTemprature.Day);
			Assert.Equal (tempratures [0].Max, minTemprature.Max);
			Assert.Equal (tempratures [0].Min, minTemprature.Min);
		}

		[Fact]
		public void should_return_the_min_temprature_spread_when_there_is_more_than_one_valid_element(){
			var tempratures = new[] { new Temprature ("1 23 8"), new Temprature ("2 9 3") };
			var minTemprature = new DataComparer ().GetMin (tempratures);
			Assert.Equal (tempratures [1].Day, minTemprature.Day);
			Assert.Equal (tempratures [1].Max, minTemprature.Max);
			Assert.Equal (tempratures [1].Min, minTemprature.Min);
		}

		[Fact]
		public void should_return_min_temprature_when_read_from_stream(){
			var tempratures = new DataReader().Read(new MemoryStream(Encoding.UTF8.GetBytes("1 23 8\n2 34 1\na b c")));
			var minTemprature = new DataComparer ().GetMin (tempratures);
			Assert.Equal (tempratures [0].Day, minTemprature.Day);
			Assert.Equal (tempratures [0].Max, minTemprature.Max);
			Assert.Equal (tempratures [0].Min, minTemprature.Min);
		}
		
		[Fact]
		public void should_return_min_temprature_spread_from_file(){
			var tempratures = new DataReader().Read(new FileStream("weather.dat", FileMode.Open));
			var minTemprature = new DataComparer ().GetMin (tempratures);
			Assert.Equal (tempratures [13].Day, minTemprature.Day);
			Assert.Equal (tempratures [13].Max, minTemprature.Max);
			Assert.Equal (tempratures [13].Min, minTemprature.Min);
		}
	}
}