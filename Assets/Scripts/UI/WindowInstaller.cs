using Breeds.Details;
using UnityEngine;
using Zenject;

namespace UI
{
	public class WindowInstaller : MonoInstaller
	{
		public Transform container;
		public DetailsPopup detailsPopupPrefab;
		
		public override void InstallBindings()
		{
			Container.BindFactory<string, DetailsPopup, DetailsPopup.Factory>()
				.FromSubContainerResolve()
				.ByNewContextPrefab<DetailsPopup>(detailsPopupPrefab)
				.UnderTransform(container);
		}
	}
}