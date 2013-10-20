using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Xunit;

namespace _4
{
	public class DataComparer
	{
		public Temprature GetMin (Temprature[] tempratures)
		{
			if (tempratures.Length == 0)
				return null;
			return tempratures[0];
		}
	}
}