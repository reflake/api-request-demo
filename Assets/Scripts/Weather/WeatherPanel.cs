using Zenject;

namespace Weather
{
	public class WeatherPanel : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<View>().FromComponentsOnRoot();
			
			// Bind Model and it's IDisposable interface
			Container.BindInterfacesAndSelfTo<Model>().AsSingle();
			
			// Bind Presenter and it's IDisposable interface
			Container.BindInterfacesAndSelfTo<Presenter>().FromNew().AsSingle().NonLazy();
		}
	}
}