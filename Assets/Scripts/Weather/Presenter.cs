using System;
using Cysharp.Threading.Tasks;

namespace Weather
{
	public class Presenter
	{
		private readonly View _view = null;
		private readonly Model _model = null;

		public Presenter(View view, Model model)
		{
			_view = view;
			_model = model;
			
			ShowTemperature().Forget();
			
			// Subscriptions
			_view.OnLostFocus += CancelRequest;
			_view.OnRefreshClick += Refresh;
		}

		private void CancelRequest()
		{
			_model.TryCancelRequest();
		}

		private async UniTaskVoid ShowTemperature()
		{
			_view.ShowLoading();
			
			// Simulate loading: await UniTask.Delay(1500);
			
			WeatherResponse response = await _model.GetTemperatureAsync();
			
			_view.ShowWeather(response.Temperature, response.IconType);
		}

		private void Refresh()
		{
			ShowTemperature().Forget();
		}
	}
}