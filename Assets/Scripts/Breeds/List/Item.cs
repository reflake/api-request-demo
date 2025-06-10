using Breeds.Details;
using Zenject;

namespace Breeds.List
{
	public class Item : MonoInstaller
	{
		public class Factory : PlaceholderFactory<Breed, Item> {}

		public DetailsPopup detailsPopupPrefab;
		
		[Inject] public readonly Breed Breed;
		
		public override void InstallBindings()
		{
			Container.Bind<Item>().FromInstance(this);
			
			Container.BindInstance(Breed).WhenInjectedInto<ItemModel>();
			Container.Bind<ItemModel>().AsSingle();
			Container.Bind<ItemPresenter>().FromNew().AsSingle().NonLazy();
			Container.Bind<ItemView>().FromComponentOnRoot();
		}

		public void Remove()
		{
			Destroy(gameObject);
		}
	}
}