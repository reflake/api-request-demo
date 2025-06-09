using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Weather
{
	public class View : MonoBehaviour
	{
		[SerializeField] private TMP_Text label = null;
		[SerializeField] private Button refreshButton = null;
		
		public event Action OnRefreshClick;

		private void Awake()
		{
			refreshButton.onClick.AddListener(Refresh);
		}

		public void ShowWeather(int temperature, IconType iconType)
		{
			string icon = iconType switch
			{
				IconType.Sunny => "<sprite=2>",
				IconType.Clear => "<sprite=1>",
				IconType.PartlyCloudy => "<sprite=5>",
				IconType.MostlyClear => "<sprite=0>",
				IconType.Rainy =>  "<sprite=3>",
				IconType.Thunderstorms => "<sprite=4>",
				_ => "?"
			};
			
			label.color = Color.white;
			label.text = $"{icon} Сегодня {temperature}°F";
		}

		public void ShowError(string message)
		{
			label.text = message;
			label.color = Color.red;
		}

		public void ShowLoading()
		{
			label.text = "Loading...";
			label.color = Color.yellow;
		}

		private void Refresh()
		{
			OnRefreshClick?.Invoke();
		}
	}
}