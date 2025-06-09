using Zenject;

namespace Weather
{
	public class WeatherPanel : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<View>().FromComponentsOnRoot();
			
			// Bind Presenter and it's IDisposable interface
			Container.BindInterfacesAndSelfTo<Presenter>().FromNew().AsSingle().NonLazy();
		}
	}
}