using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Breeds.List
{
	public class ItemView : MonoBehaviour
	{
		[SerializeField] private TMP_Text indexLabel;
		[SerializeField] private TMP_Text nameLabel;
		[SerializeField] private Button button;

		public event Action OnClick;
		
		private void Start()
		{
			button.onClick.AddListener(InvokeClick);
		}

		public void SetIndex(int index)
		{
			indexLabel.text = index.ToString();
		}

		public void SetName(string text)
		{
			nameLabel.text = text;
		}

		private void InvokeClick()
		{
			OnClick?.Invoke();
		}
	}
}