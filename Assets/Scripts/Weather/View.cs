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
		[SerializeField] private GameObject loadingGO = null;

		public event Action OnClear = null;
		public event Action OnLostFocus = null;
		public event Action OnRefreshClick = null;

		private void Awake()
		{
			refreshButton.onClick.AddListener(InvokeRefresh);
		}

		public void ShowWeather(int temperature, IconType iconType)
		{
			loadingGO.SetActive(false);
			iconImage.enabled = true;
			label.enabled = true;
			
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
			loadingGO.SetActive(false);
			label.text = message;
		}

		public void ShowLoading()
		{
			loadingGO.SetActive(true);
		}

		private void InvokeRefresh()
		{
			OnRefreshClick?.Invoke();
		}

		private void OnEnable()
		{
			OnClear?.Invoke();
			InvokeRefresh();
		}

		public void DelayRefresh()
		{
			CancelInvoke();
			Invoke(nameof(InvokeRefresh), 5.0f);
		}

		private void OnDisable()
		{
			OnLostFocus?.Invoke();
			
			CancelInvoke();
		}

		public void HideWeather()
		{
			iconImage.enabled = false;
			label.enabled = false;
		}
	}
}