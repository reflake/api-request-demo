using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Weather.Data;

namespace Weather
{
	public enum IconType
	{
		Unknown,
		Sunny, Clear, PartlyCloudy, MostlyClear,
		Rainy, Thunderstorms
	}

	public struct WeatherResponse
	{
		// In fahrenheits
		public int Temperature;
		public IconType IconType;

		public WeatherResponse(int temperature, IconType iconType)
		{
			Temperature = temperature;
			IconType = iconType;
		}
	}
	
	public class Model : IDisposable
	{
		private const string ApiPath = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
		
		private UnityWebRequest _currentRequest = null;

		public async UniTask<WeatherResponse> GetTemperatureAsync()
		{
			TryCancelRequest();
			
			_currentRequest = UnityWebRequest.Get(ApiPath);
			
			var response = await _currentRequest.SendWebRequest();
			var data = JsonUtility.FromJson<WeatherData>(response.downloadHandler.text);
			
			// Get the first period which is indicating weather right now
			Period targetPeriod = data.properties.periods.First();
			IconType iconType = DetermineIconType(targetPeriod);
			
			return new WeatherResponse(targetPeriod.temperature, iconType);
		}

		public void Dispose()
		{
			TryCancelRequest();
		}

		public void TryCancelRequest()
		{
			if (_currentRequest != null && !_currentRequest.isDone)
			{
				_currentRequest.Abort();
			}
		}

		private IconType DetermineIconType(Period period)
		{
			if (period.shortForecast == "Sunny")
			{
				return IconType.Sunny;
			}
			else if (period.shortForecast == "Clear")
			{
				return IconType.Clear;
			}
			else if (period.shortForecast == "Partly Cloudy")
			{
				return IconType.PartlyCloudy;
			}
			else if (period.shortForecast == "Mostly Clear")
			{
				return IconType.MostlyClear;
			}
			else if (period.shortForecast.Contains("Thunderstorms"))
			{
				return IconType.Thunderstorms;
			}
			else if (period.shortForecast.Contains("Showers") || period.shortForecast.Contains("Rain"))
			{
				return IconType.Rainy;
			}

			return IconType.Unknown;
		}
	}
}