using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Weather
{
	public class Presenter : IDisposable
	{
		private readonly View _view = null;

		public Presenter(View view)
		{
			_view = view;
			
			ShowTemperature();
			
			_view.OnRefreshClick += Refresh;
		}

		public void Dispose()
		{
			_view.OnRefreshClick -= Refresh;
		}

		public async UniTaskVoid ShowTemperature()
		{
			_view.ShowLoading();
			
			await UniTask.Delay(2000);
			
			int temperature = Random.Range(60, 90);
			
			_view.ShowTemperature(temperature);
		}

		private void Refresh()
		{
			ShowTemperature();
		}
	}
}