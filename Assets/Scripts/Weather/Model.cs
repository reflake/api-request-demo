using Cysharp.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Weather.Data;

namespace Weather
{
	public class Model : IDisposable
	{
		private const string ApiPath = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
		
		private UnityWebRequest _currentRequest = null;

		public async UniTask<int> GetTemperatureAsync()
		{
			TryCancelRequest();
			
			_currentRequest = UnityWebRequest.Get(ApiPath);
			
			var response = await _currentRequest.SendWebRequest();
			var data = JsonUtility.FromJson<WeatherData>(response.downloadHandler.text);
			
			// Get the first period which is indicating weather right now
			var targetPeriod = data.properties.periods.First();
			
			return targetPeriod.temperature;
		}

		public void Dispose()
		{
			TryCancelRequest();
		}

		private void TryCancelRequest()
		{
			if (_currentRequest != null && !_currentRequest.isDone)
			{
				_currentRequest.Abort();
			}
		}
	}
}