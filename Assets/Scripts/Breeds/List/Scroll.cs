using Breeds.List.Data;
using UnityEngine;
using Zenject;

namespace Breeds.List
{
	public class Scroll : MonoInstaller
	{
		public Item prefab;
		public Transform container;
		
		public override void InstallBindings()
		{
			Container.BindFactory<Breed, Item, Item.Factory>()
				.FromSubContainerResolve()
				.ByNewContextPrefab<Item>(prefab)
				.UnderTransform(container);

			Container.Bind<ScrollView>().FromComponentOnRoot();

			// Bind Model and it's IDisposable interface
			Container.BindInterfacesAndSelfTo<ScrollModel>().AsSingle();
			
			// Bind Presenter and it's IDisposable interface
			Container.BindInterfacesAndSelfTo<ScrollPresenter>().FromNew().AsSingle().NonLazy();
		}
	}
}