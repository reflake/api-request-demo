using System;
using UnityEngine;

namespace Breeds.List
{
	public class ScrollView : MonoBehaviour
	{
		[SerializeField] private GameObject loadingText = null;

		public event Action OnLostFocus = null;

		private void OnDisable()
		{
			OnLostFocus?.Invoke();
		}
		
		public void ShowLoading()
		{
			loadingText.SetActive(true);
		}

		public void HideLoading()
		{
			loadingText.SetActive(false);
		}
	}
}