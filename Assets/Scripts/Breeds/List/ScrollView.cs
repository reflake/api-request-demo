using System;
using UnityEngine;
using UnityEngine.UI;

namespace Breeds.List
{
	public class ScrollView : MonoBehaviour
	{
		[SerializeField] private GameObject loadingText = null;
		[SerializeField] private Button button = null;

		public event Action OnClickRefresh = null;
		public event Action OnLostFocus = null;
		public event Action OnClear = null;

		private void Awake()
		{
			button.onClick.AddListener(InvokeRefresh);
		}
		
		public void ShowLoading()
		{
			loadingText.SetActive(true);
		}

		public void HideLoading()
		{
			loadingText.SetActive(false);
		}

		private void InvokeRefresh()
		{
			OnClickRefresh?.Invoke();
		}

		private void OnEnable()
		{
			OnClear?.Invoke();
			
			InvokeRefresh();
		}

		public void RefreshDelay()
		{
			CancelInvoke();
			Invoke(nameof(InvokeRefresh), 5.0f);
		}

		private void OnDisable()
		{
			OnLostFocus?.Invoke();
			
			CancelInvoke();
		}
	}
}