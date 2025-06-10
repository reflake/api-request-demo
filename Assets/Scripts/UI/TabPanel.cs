using UnityEngine;

namespace UI
{
	public class TabPanel : MonoBehaviour
	{
		public string Id;
		public string Name;

		public void SetFocused(bool value)
		{
			gameObject.SetActive(value);
		}
	}
}