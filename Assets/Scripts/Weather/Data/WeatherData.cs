using System;

namespace Weather.Data
{
	[Serializable]
	public class WeatherData
	{
		public Properties properties = null;
	}

	[Serializable]
	public class Properties
	{
		public Period[] periods = null;
	}

	[Serializable]
	public class Period
	{
		public string name = null;
		public int temperature = 0;
	}
}