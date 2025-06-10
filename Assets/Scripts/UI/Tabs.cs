using TMPro;
using Zenject;

namespace UI
{
	public class Tabs : MonoInstaller
	{
		public TMP_Text header;
		
		public override void InstallBindings()
		{
			Container.BindInstance(header).WhenInjectedInto<TabController>();
			
			Container.BindInstances(GetComponentsInChildren<TabButton>());
			Container.BindInstances(GetComponentsInChildren<TabPanel>());
			
			Container.BindInterfacesAndSelfTo<TabController>().FromNew().AsSingle().NonLazy();
		}
	}
}