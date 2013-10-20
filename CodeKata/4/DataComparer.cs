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
			var min = tempratures [0];
			foreach(var temprature in tempratures){
				if (min.GetSpread () > temprature.GetSpread ()) {
					min = temprature;
				}
			}			
			return min;
		}
	}
}