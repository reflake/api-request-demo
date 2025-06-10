using Zenject;

namespace Breeds.Details
{
	public class DetailsPopup : MonoInstaller
	{
		public class Factory : PlaceholderFactory<string, DetailsPopup> {}

		[Inject] public string Id;
		
		public override void InstallBindings()
		{
			Container.BindInstance(this);

			Container.Bind<View>().FromComponentOnRoot();
			
			// Inject breed Id into model
			Container.BindInstance(Id).WhenInjectedInto<Model>();

			// Bind Model and it's IDisposable interface
			Container.BindInterfacesAndSelfTo<Model>().AsSingle();

			Container.Bind<Presenter>().FromNew().AsSingle().NonLazy();
		}
	}
}