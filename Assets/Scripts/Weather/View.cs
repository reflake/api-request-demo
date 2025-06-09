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

		public void ShowTemperature(int temperature)
		{
			label.text = $"{temperature}°F";
			label.color = Color.white;;
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