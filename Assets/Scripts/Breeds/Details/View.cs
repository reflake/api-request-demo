using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Breeds.Details
{
	public class View : MonoBehaviour
	{
		[SerializeField] private TMP_Text nameLabel;
		[SerializeField] private TMP_Text descriptionLabel;
		[SerializeField] private Button okButton;
		[SerializeField] private GameObject loadingText;

		public event Action OnOkClick = null;

		private void Awake()
		{
			okButton.onClick.AddListener(InvokeOkClick);
		}

		public void SetName(string nameText)
		{
			nameLabel.text = nameText;
		}

		public void SetDescription(string description)
		{
			descriptionLabel.text = description;
		}

		public void ShowLoading()
		{
			loadingText.SetActive(true);
		}

		public void HideLoading()
		{
			loadingText.SetActive(false);
		}

		private void InvokeOkClick()
		{
			OnOkClick?.Invoke();
		}
	}
}