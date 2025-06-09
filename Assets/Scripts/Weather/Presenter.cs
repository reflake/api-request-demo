using System;
using Cysharp.Threading.Tasks;
using Random = UnityEngine.Random;

namespace Weather
{
	public class Presenter : IDisposable
	{
		private readonly View _view = null;
		private readonly Model _model = null;

		public Presenter(View view, Model model)
		{
			_view = view;
			_model = model;
			
			ShowTemperature();
			
			// Subscriptions
			_view.OnRefreshClick += Refresh;
		}

		public void Dispose()
		{
			_view.OnRefreshClick -= Refresh;
		}

		public async UniTaskVoid ShowTemperature()
		{
			_view.ShowLoading();
			
			int temperature = await _model.GetTemperatureAsync();
			
			_view.ShowTemperature(temperature);
		}

		private void Refresh()
		{
			ShowTemperature();
		}
	}
}