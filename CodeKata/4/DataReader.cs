using System.Collections.Generic;
using System.IO;

namespace _4
{
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
}