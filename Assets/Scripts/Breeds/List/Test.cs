using Breeds.List.Data;
using Zenject;

namespace Breeds.List
{
	public class Test : MonoInstaller
	{
		public Item prefab;
		
		public override void InstallBindings()
		{
			Container.BindFactory<Breed, Item, Item.Factory>()
				.FromSubContainerResolve()
				.ByNewContextPrefab<Item>(prefab)
				.UnderTransform(transform);
			
			var factory = Container.Resolve<Item.Factory>();
			factory.Create(new Breed(2, "Poodle"));
		}
	}
}