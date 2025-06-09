using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Weather
{
	public class View : MonoBehaviour
	{
		[SerializeField] private TMP_Text label = null;

		private async UniTask Start()
		{
			ShowTemperature(54);
			
			await UniTask.Delay(5000);
			
			ShowLoading();
			
			await UniTask.Delay(5000);
			
			ShowError("No internet connection");
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
	}
}