using UnityEngine;

namespace Breeds.List
{
	public class ScrollView : MonoBehaviour
	{
		[SerializeField] private GameObject loadingText = null;
		
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