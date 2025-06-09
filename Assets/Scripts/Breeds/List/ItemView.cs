using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Breeds.List
{
	public class ItemView : MonoBehaviour
	{
		[SerializeField] private TMP_Text label;
		[SerializeField] private Button button;

		public event Action OnClick;
		
		private void Start()
		{
			button.onClick.AddListener(InvokeClick);
		}

		public void SetName(string text)
		{
			label.text = text;
		}

		private void InvokeClick()
		{
			OnClick?.Invoke();
		}
	}
}