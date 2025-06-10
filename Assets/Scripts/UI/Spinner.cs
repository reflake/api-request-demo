using DG.Tweening;
using UnityEngine;

namespace UI
{
	public class Spinner : MonoBehaviour
	{
		[SerializeField] private RectTransform _icon;
		
		private void OnEnable()
		{
			_icon.rotation = Quaternion.Euler(0, 0, 0);
			_icon.DOLocalRotate(new Vector3(0, 0, 359), 0.5f, RotateMode.FastBeyond360)
				.SetEase(Ease.Linear)
				.SetLoops(-1);
		}

		private void OnDisable()
		{
			_icon.DOKill();
		}
	}
}