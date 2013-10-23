using System;
using System.Text.RegularExpressions;

namespace _4
{
    public class Temprature
    {
        public int Day;
        public double Max;
        public double Min;

        public Temprature(string line)
        {
            var arr = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Day = Int32.Parse(arr[0]);
            Max = Double.Parse(arr[1]);
            Min = Double.Parse(Regex.Match(arr[2], @"\d+").Value);
        }

        public static Temprature Create(string line)
        {
            Temprature temprature = null;
            try
            {
                temprature = new Temprature(line);
            }
            catch (Exception)
            {
                
            }
            return temprature;
        }

        public double GetSpread ()
        {
            return Max - Min;
        }
    }
}