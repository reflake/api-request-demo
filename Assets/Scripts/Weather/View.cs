using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Weather
{
	public class View : MonoBehaviour
	{
		[SerializeField] private Image iconImage = null;
		[SerializeField] private TMP_Text label = null;
		[SerializeField] private Button refreshButton = null;
		[SerializeField] private Sprite[] iconSprites = null;
		
		public event Action OnLostFocus = null;
		public event Action OnRefreshClick = null;

		private void Awake()
		{
			refreshButton.onClick.AddListener(Refresh);
		}

		private void OnDisable()
		{
			OnLostFocus?.Invoke();
		}

		public void ShowWeather(int temperature, IconType iconType)
		{
			iconImage.enabled = true;
			
			Sprite icon = iconType switch
			{
				IconType.Sunny => iconSprites[0],
				IconType.Clear => iconSprites[1],
				IconType.PartlyCloudy => iconSprites[2],
				IconType.MostlyClear => iconSprites[3],
				IconType.Rainy => iconSprites[4],
				IconType.Thunderstorms => iconSprites[5],
				_ => null
			};
			
			iconImage.sprite = icon;
			label.text = $"Now {temperature}°F";
		}

		public void ShowError(string message)
		{
			label.text = message;
		}

		public void ShowLoading()
		{
			iconImage.enabled = false;
			
			label.text = "Loading...";
		}

		private void Refresh()
		{
			OnRefreshClick?.Invoke();
		}
	}
}