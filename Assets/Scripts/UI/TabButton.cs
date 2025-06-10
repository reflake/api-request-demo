using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class TabButton : MonoBehaviour
	{
		public string Id;
		
		[SerializeField] private Color focusedColor;
		[SerializeField] private Color unfocusedColor;
		[SerializeField] private Graphic[] colored;
		[SerializeField] private Button button;
		
		public Action<TabButton> OnClick = null;

		private void Awake()
		{
			button.onClick.AddListener(InvokeClicked);
		}

		private void InvokeClicked()
		{
			OnClick?.Invoke(this);
		}

		public void SetFocusedValue(bool value)
		{
			foreach (var element in colored)
			{
				element.color = value ? focusedColor : unfocusedColor;
			}
		}
	}
}